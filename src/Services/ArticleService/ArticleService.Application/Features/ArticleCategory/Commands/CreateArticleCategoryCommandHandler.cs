using ArticleService.Application.Interfaces.ArticleCategory;
using AutoMapper;
using MediatR;
using ArticleCategoryModel = ArticleService.Domain.Entities.ArticleCategory;

namespace ArticleService.Application.Features.ArticleCategory.Commands
{
    public class CreateArticleCategoryCommandHandler : IRequestHandler<CreateArticleCategoryCommandRequest, CreateArticleCategoryCommandResponse>
    {
        private readonly IArticleCategoryCommandRepository _articleCategoryCommandRepository;
        private readonly IMapper _Mapper;

        public CreateArticleCategoryCommandHandler(IArticleCategoryCommandRepository articleCategoryCommandRepository, IMapper mapper)
        {
            _articleCategoryCommandRepository = articleCategoryCommandRepository;
            _Mapper = mapper;
        }

        public async Task Handle(ArticleCategoryModel article)
        {
            await _articleCategoryCommandRepository.AddAsync(article);
        }

        public async Task<CreateArticleCategoryCommandResponse> Handle(CreateArticleCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var model = _Mapper.Map<ArticleCategoryModel>(request);
            var result = await _articleCategoryCommandRepository.AddAsync(model);
            var response = _Mapper.Map<CreateArticleCategoryCommandResponse>(result);
            return response;
        }
    }
}

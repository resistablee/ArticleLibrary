using ArticleService.Application.Interfaces.ArticleCategory;
using AutoMapper;
using MediatR;
using ArticleCategoryModel = ArticleService.Domain.Entities.ArticleCategory;

namespace ArticleService.Application.Features.ArticleCategory.Commands
{
    public class RemoveArticleCategoryCommandHandler : IRequestHandler<RemoveArticleCategoryCommandRequest, RemoveArticleCategoryCommandResponse>
    {
        private readonly IArticleCategoryCommandRepository _articleCategoryCommandRepository;
        private readonly IMapper _Mapper;

        public RemoveArticleCategoryCommandHandler(IArticleCategoryCommandRepository articleCategoryCommandRepository, IMapper mapper)
        {
            _articleCategoryCommandRepository = articleCategoryCommandRepository;
            _Mapper = mapper;
        }

        public async Task Handle(ArticleCategoryModel article)
        {
            await _articleCategoryCommandRepository.RemoveAsync(article);
        }

        public async Task<RemoveArticleCategoryCommandResponse> Handle(RemoveArticleCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var model = _Mapper.Map<ArticleCategoryModel>(request);
            var result = await _articleCategoryCommandRepository.RemoveAsync(model);
            var response = _Mapper.Map<RemoveArticleCategoryCommandResponse>(result);
            return response;
        }
    }
}

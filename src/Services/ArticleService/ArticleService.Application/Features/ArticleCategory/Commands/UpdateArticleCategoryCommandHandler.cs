using ArticleService.Application.Interfaces.ArticleCategory;
using AutoMapper;
using MediatR;
using ArticleCategoryModel = ArticleService.Domain.Entities.ArticleCategory;

namespace ArticleService.Application.Features.ArticleCategory.Commands
{
    public class UpdateArticleCategoryCommandHandler : IRequestHandler<UpdateArticleCategoryCommandRequest, UpdateArticleCategoryCommandResponse>
    {
        private readonly IArticleCategoryCommandRepository _articleCategoryCommandRepository;
        private readonly IMapper _Mapper;

        public UpdateArticleCategoryCommandHandler(IArticleCategoryCommandRepository articleCategoryCommandRepository, IMapper mapper)
        {
            _articleCategoryCommandRepository = articleCategoryCommandRepository;
            _Mapper = mapper;
        }

        public async Task Handle(ArticleCategoryModel articleCategory)
        {
            await _articleCategoryCommandRepository.UpdateAsync(articleCategory);
        }

        public async Task<UpdateArticleCategoryCommandResponse> Handle(UpdateArticleCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var model = _Mapper.Map<ArticleCategoryModel>(request);
            var result = await _articleCategoryCommandRepository.UpdateAsync(model);
            var response = _Mapper.Map<UpdateArticleCategoryCommandResponse>(result);
            return response;
        }
    }
}

using ArticleService.Application.Interfaces.ArticleCategory;
using AutoMapper;
using MediatR;
using ArticleCategoryModel = ArticleService.Domain.Entities.ArticleCategory;

namespace ArticleService.Application.Features.ArticleCategory.Queries
{
    public class GetByIdArticleCategoryQueryHandler : IRequestHandler<GetByIdArticleCategoryQueryRequest, IQueryable<GetByIdArticleCategoryQueryResponse>>
    {
        private readonly IArticleCategoryQueryRepository _articleCategoryQueryRepository;
        private readonly IMapper _Mapper;


        public GetByIdArticleCategoryQueryHandler(IArticleCategoryQueryRepository articleCategoryQueryRepository, IMapper mapper)
        {
            _articleCategoryQueryRepository = articleCategoryQueryRepository;
            _Mapper = mapper;
        }

        public async Task<ArticleCategoryModel> Handle(string id)
        {
            return await _articleCategoryQueryRepository.GetByIdAsync(id);
        }

        public async Task<IQueryable<GetByIdArticleCategoryQueryResponse>> Handle(GetByIdArticleCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            //var model = _Mapper.Map<ArticleCategoryModel>(request);
            var result = await _articleCategoryQueryRepository.GetByIdAsync(request.Id);
            var response = _Mapper.Map<IQueryable<GetByIdArticleCategoryQueryResponse>>(result);
            return response;
        }
    }
}

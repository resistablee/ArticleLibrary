using ArticleService.Application.Interfaces.ArticleCategory;
using AutoMapper;
using MediatR;
using ArticleCategoryModel = ArticleService.Domain.Entities.ArticleCategory;

namespace ArticleService.Application.Features.ArticleCategory.Queries
{
    public class GetAllArticleCategoryQueryHandler : IRequestHandler<GetAllArticleCategoryQueryRequest, List<GetAllArticleCategoryQueryResponse>>
    {
        private readonly IArticleCategoryQueryRepository _articleCategoryQueryRepository;
        private readonly IMapper _Mapper;

        public GetAllArticleCategoryQueryHandler(IArticleCategoryQueryRepository articleCategoryQueryRepository, IMapper mapper)
        {
            _articleCategoryQueryRepository = articleCategoryQueryRepository;
            _Mapper = mapper;
        }

        public async Task<List<GetAllArticleCategoryQueryResponse>> Handle(GetAllArticleCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            //var model = _Mapper.Map<ArticleCategoryModel>(request);
            var result = _articleCategoryQueryRepository.GetAll();
            var response = _Mapper.Map<List<GetAllArticleCategoryQueryResponse>>(result);
            return response;
        }
    }
}

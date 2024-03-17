using ArticleService.Application.Interfaces.Article;
using AutoMapper;
using MediatR;
using ArticleModel = ArticleService.Domain.Entities.Article;

namespace ArticleService.Application.Features.Article.Queries
{
    public class GetAllArticleQueryHandler : IRequestHandler<GetAllArticleQueryRequest, List<GetAllArticleQueryResponse>>
    {
        private readonly IArticleQueryRepository _articleQueryRepository;
        private readonly IMapper _Mapper;

        public GetAllArticleQueryHandler(IArticleQueryRepository articleQueryRepository, IMapper mapper)
        {
            _articleQueryRepository = articleQueryRepository;
            _Mapper = mapper;
        }

        public async Task<List<GetAllArticleQueryResponse>> Handle(GetAllArticleQueryRequest request, CancellationToken cancellationToken)
        {
            //var model = _Mapper.Map<ArticleModel>(request);
            var result = _articleQueryRepository.GetAll();
            var response = _Mapper.Map<List<GetAllArticleQueryResponse>>(result);
            return response;
        }
    }
}

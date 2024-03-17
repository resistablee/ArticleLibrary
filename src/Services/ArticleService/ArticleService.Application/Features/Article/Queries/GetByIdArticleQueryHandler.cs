using ArticleService.Application.Interfaces.Article;
using AutoMapper;
using MediatR;
using ArticleModel = ArticleService.Domain.Entities.Article;

namespace ArticleService.Application.Features.Article.Queries
{
    public class GetByIdArticleQueryHandler : IRequestHandler<GetByIdArticleQueryRequest, GetByIdArticleQueryResponse>
    {
        private readonly IArticleQueryRepository _articleQueryRepository;
        private readonly IMapper _Mapper;

        public GetByIdArticleQueryHandler(IArticleQueryRepository articleQueryRepository, IMapper mapper)
        {
            _articleQueryRepository = articleQueryRepository;
            _Mapper = mapper;
        }

        public async Task<ArticleModel> Handle(string id)
        {
            return await _articleQueryRepository.GetByIdAsync(id);
        }

        public async Task<GetByIdArticleQueryResponse> Handle(GetByIdArticleQueryRequest request, CancellationToken cancellationToken)
        {
            //var model = _Mapper.Map<ArticleModel>(request);
            var result = _articleQueryRepository.GetAll();
            var response = _Mapper.Map<GetByIdArticleQueryResponse>(result);
            return response;
        }
    }
}

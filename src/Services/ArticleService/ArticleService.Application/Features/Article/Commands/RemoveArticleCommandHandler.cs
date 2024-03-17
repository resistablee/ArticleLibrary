using ArticleService.Application.Interfaces.Article;
using AutoMapper;
using MediatR;
using ArticleModel = ArticleService.Domain.Entities.Article;

namespace ArticleService.Application.Features.Article.Commands
{
    public class RemoveArticleCommandHandler : IRequestHandler<RemoveArticleCommandRequest, RemoveArticleCommandResponse>
    {
        private readonly IArticleCommandRepository _articleCommandRepository;
        private readonly IMapper _Mapper;

        public RemoveArticleCommandHandler(IArticleCommandRepository articleCommandRepository, IMapper mapper)
        {
            _articleCommandRepository = articleCommandRepository;
            _Mapper = mapper;
        }

        public async Task<RemoveArticleCommandResponse> Handle(RemoveArticleCommandRequest request, CancellationToken cancellationToken)
        {
            var model = _Mapper.Map<ArticleModel>(request);
            var result = await _articleCommandRepository.RemoveAsync(model);
            var response = _Mapper.Map<RemoveArticleCommandResponse>(result);
            return response;
        }
    }
}

using ArticleService.Application.Interfaces.Article;
using AutoMapper;
using MediatR;
using ArticleModel = ArticleService.Domain.Entities.Article;

namespace ArticleService.Application.Features.Article.Commands
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommandRequest, UpdateArticleCommandResponse>
    {
        private readonly IArticleCommandRepository _articleCommandRepository;
        private readonly IMapper _Mapper;

        public UpdateArticleCommandHandler(IArticleCommandRepository articleCommandRepository, IMapper mapper)
        {
            _articleCommandRepository = articleCommandRepository;
            _Mapper = mapper;
        }

        public async Task Handle(ArticleModel article)
        {
            await _articleCommandRepository.UpdateAsync(article);
        }

        public async Task<UpdateArticleCommandResponse> Handle(UpdateArticleCommandRequest request, CancellationToken cancellationToken)
        {
            var model = _Mapper.Map<ArticleModel>(request);
            var result = await _articleCommandRepository.UpdateAsync(model);
            var response = _Mapper.Map<UpdateArticleCommandResponse>(result);
            return response;
        }
    }
}

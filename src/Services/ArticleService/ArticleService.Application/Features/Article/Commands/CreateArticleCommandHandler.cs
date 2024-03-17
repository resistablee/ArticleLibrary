using ArticleService.Application.Interfaces.Article;
using AutoMapper;
using MediatR;
using ArticleModel = ArticleService.Domain.Entities.Article;

namespace ArticleService.Application.Features.Article.Commands
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommandRequest, CreateArticleCommandResponse>
    {
        private readonly IArticleCommandRepository _articleCommandRepository;
        private readonly IMapper _Mapper;

        public CreateArticleCommandHandler(IArticleCommandRepository articleCommandRepository, IMapper mapper)
        {
            _articleCommandRepository = articleCommandRepository;
            _Mapper = mapper;
        }

        public async Task<CreateArticleCommandResponse> Handle(CreateArticleCommandRequest request, CancellationToken cancellationToken)
        {
            var model = _Mapper.Map<ArticleModel>(request);
            var result = await _articleCommandRepository.AddAsync(model);
            var response = _Mapper.Map<CreateArticleCommandResponse>(result);
            return response;
        }
    }
}

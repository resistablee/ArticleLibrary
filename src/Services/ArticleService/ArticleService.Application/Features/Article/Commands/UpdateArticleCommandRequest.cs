﻿using MediatR;

namespace ArticleService.Application.Features.Article.Commands
{
    public class UpdateArticleCommandRequest : IRequest<UpdateArticleCommandResponse>
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public Guid AuthorID { get; set; }
        public Guid CategoryID { get; set; }
    }
}

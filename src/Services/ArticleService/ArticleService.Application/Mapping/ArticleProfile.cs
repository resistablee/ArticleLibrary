using ArticleService.Application.Features.Article.Commands;
using ArticleService.Application.Features.Article.Queries;
using ArticleService.Domain.Entities;
using AutoMapper;

namespace ArticleService.Application.Mapping
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            //Create Mapping
            CreateMap<CreateArticleCommandRequest, Article>().ReverseMap();
            CreateMap<Article, CreateArticleCommandResponse>().ReverseMap();
            //Update Mapping
            CreateMap<Article, UpdateArticleCommandResponse>().ReverseMap();
            //Remove Mapping
            CreateMap<Article, RemoveArticleCommandRequest>().ReverseMap();
            CreateMap<Article, RemoveArticleCommandResponse>().ReverseMap();
            //GetById Mapping
            CreateMap<Article, GetByIdArticleQueryResponse>().ReverseMap();
            //GetAll Mapping
            CreateMap<Article, GetAllArticleQueryRequest>().ReverseMap();
            CreateMap<Article, GetAllArticleQueryResponse>().ReverseMap();
        }
    }
}

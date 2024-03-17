using ArticleService.Application.Features.ArticleCategory.Commands;
using ArticleService.Application.Features.ArticleCategory.Queries;
using ArticleService.Domain.Entities;
using AutoMapper;

namespace ArticleService.Application.Mapping
{
    public class ArticleCategoryProfile : Profile
    {
        public ArticleCategoryProfile()
        {
            //Create Mapping
            CreateMap<CreateArticleCategoryCommandRequest, ArticleCategory>().ReverseMap();
            CreateMap<ArticleCategory, CreateArticleCategoryCommandResponse>().ReverseMap();
            //Update Mapping
            CreateMap<ArticleCategory, UpdateArticleCategoryCommandRequest>().ReverseMap();
            CreateMap<ArticleCategory, UpdateArticleCategoryCommandResponse>().ReverseMap();
            //Remove Mapping
            CreateMap<ArticleCategory, RemoveArticleCategoryCommandRequest>().ReverseMap();
            CreateMap<ArticleCategory, RemoveArticleCategoryCommandResponse>().ReverseMap();
            //GetById Mapping
            CreateMap<ArticleCategory, GetByIdArticleCategoryQueryResponse>().ReverseMap();
            //GetAll Mapping
            //CreateMap<ArticleCategory, GetAllArticleCategoryQueryRequest>().ReverseMap();
            CreateMap<ArticleCategory, GetAllArticleCategoryQueryResponse>().ReverseMap();
        }
    }
}

using AuthorService.API.Models.DTO;
using AuthorService.API.Models.Entities;
using AutoMapper;

namespace AuthorService.API.Models.Mapping
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<DtoAuthorAdd, Author>();
            CreateMap<DtoAuthorUpdate, Author>();
        }
    }
}

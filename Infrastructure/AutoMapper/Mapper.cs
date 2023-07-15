using AutoMapper;
using RestFullAPI.Models.DTOs.Category;
using RestFullAPI.Models.DTOs.User;
using RestFullAPI.Models.Entities.Concrete;

namespace RestFullAPI.Infrastructure.AutoMapper
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<AppUser, AuthenticationDTO>().ReverseMap();

            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, GetCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
        }
    }
}

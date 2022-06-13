using AutoMapper;
using mgrapi.Dtos.Category;
using mgrapi.Dtos.Post;
using mgrapi.Dtos.User;
using mgrapi.Models;

namespace mgrapi.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Maps for Categories
            CreateMap<Category, GetCategoryByIdDto>();
            CreateMap<Category, CategoryForGetAllCategoriesDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();

            // Maps for Users
            CreateMap<User, GetUserByIdDto>();
            CreateMap<User, UserForGetAllUsersDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();

            // Maps for Posts
            CreateMap<Post, GetPostByIdDto>();
            CreateMap<Post, PostForGetAllPostsDto>();
            CreateMap<CreatePostDto, Post>();
            CreateMap<UpdatePostDto, Post>();
            

        }
    }
}
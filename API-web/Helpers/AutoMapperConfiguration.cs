using SharedCommonModel.Category;
using SharedCommonModel.Product;
using SharedCommonModel.Rating;
using API_web.Models;
using AutoMapper;
using SharedCommonModel.Admin;

namespace E_Ecommerce_Backend.Mappings
{
    public class AutoMapperConfiguration:Profile
    {
       public AutoMapperConfiguration()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<RatingDto, Rating>().ReverseMap();
            CreateMap<Rating, RatingDto>().ReverseMap();
            CreateMap<Image, ImageDto>().ReverseMap();
            CreateMap<Product, ProductDto>()
                .ForMember(item => item.Ratings, options => options.MapFrom(item => item.Ratings))
                .ReverseMap();
            CreateMap<Product, ProductAdmin>()
                .ReverseMap();
            CreateMap<Image, ImageAdmin>().ReverseMap();
            CreateMap<Category, CategoryAdmin>()
                .ReverseMap();
        }
    }
}

using SharedCommonModel.Category;
using SharedCommonModel.Product;
using SharedCommonModel.Rating;
using API_web.Models;
using AutoMapper;

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
            CreateMap<Product, ProductDto>().ReverseMap();
           
        }
    }
}

using SharedCommonModel.Product;
using SharedCommonModel.Rating;

namespace API_web.Interfaces
{
    public interface IRating
    {
       public Task<ProductDto> PostProductRatingAsync(RatingDto ratingDto);
    }
}

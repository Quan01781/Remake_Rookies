using API_web.Data;
using API_web.Interfaces;
using API_web.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SharedCommonModel.Product;
using SharedCommonModel.Rating;

namespace API_web.Repositories
{
    public class RatingRepository : IRating
    {
        private readonly WebDbContext _context;
        private readonly IMapper _mapper;

        public RatingRepository(WebDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        public async Task<ProductDto> PostProductRatingAsync(RatingDto ratingDto)
        {
            var rating = _mapper.Map<Rating>(ratingDto);
            rating.Product = await _context.Products.Where(e => e.Id == ratingDto.ProductId).FirstAsync();
            _context.Ratings.Add(rating);
            _context.SaveChanges();
            var product = await _context.Products
                .Where(e => e.Id == ratingDto.ProductId)
                //.Include(c => c.Categories)
                .Include(c => c.Images!)
                .Include(c => c.Ratings).FirstOrDefaultAsync();
            var productDto = _mapper.Map<ProductDto>(product);
            
            return productDto ?? new ProductDto();

        }
    }
}

using API_web.Data;
using API_web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedCommonModel.Product;
using SharedCommonModel.Rating;
using System.Reflection.Metadata.Ecma335;

namespace API_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly WebDbContext _context;
        private readonly IRating _ratingService;

        public RatingController(WebDbContext context, IRating ratingService)
        {
            _context = context;
            _ratingService = ratingService;
        }

        [HttpPost("add-rating")]
        public async Task<ActionResult<ProductDto>> PostProductRatingAsync([FromBody] RatingDto ratingDto)
        {
            var product = await _ratingService.PostProductRatingAsync(ratingDto);
            return Ok(product);
        }
    }
}

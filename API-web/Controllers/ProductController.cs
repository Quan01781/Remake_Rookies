using API_web.Data;
using API_web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedCommonModel;
using SharedCommonModel.Product;

namespace API_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly WebDbContext _context;
        private readonly IProduct _productService;

        public ProductController(WebDbContext context, IProduct productService)
        { 
            _context= context;
            _productService= productService;
        }

        [HttpPost("all-products")]
        public async Task<ActionResult<ProductPagingDto>> GetAllProductsPaingAsync([FromBody]PagingRequestDto pagingRequestDto)
        {
                var products = await _productService.GetAllProductsPaingAsync(pagingRequestDto);
                return Ok(products);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductDto>> GetProductByIdAsync(int Id)
        {
            try 
            {
                var product = await _productService.GetProductByIdAsync(Id);
                return Ok(product);
            }
            catch (Exception ex) 
            {
                return BadRequest();
            }
        }

        [HttpPost("search-product")]
        public async Task<ActionResult<ProductPagingDto>> GetProductBySearchAsync([FromBody]PagingRequestDto pagingRequestDto)
        {
            var product = await _productService.GetProductBySearchAsync(pagingRequestDto);
            return Ok(product);
        }

        [HttpPost("category-products")]
        public async Task<ActionResult<ProductPagingDto>> GetProductByCategoryIdAsync(PagingRequestDto pagingRequestDto)
        {
            var products = await _productService.GetProductByCategoryIdAsync(pagingRequestDto);
            return Ok(products);
        }
    }
}

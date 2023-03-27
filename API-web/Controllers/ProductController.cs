using API_web.Data;
using API_web.Interfaces;
using API_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedCommonModel;
using SharedCommonModel.Admin;
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

        //get all products admin
        [HttpGet]
        public async Task<ActionResult<List<ProductAdmin>>> GetAllProductsAdmin()
        {
            try
            {
                var ListPro = await _productService.GetAllProductsAdminAsync();
                return Ok(ListPro);
            }
            catch
            {
                return BadRequest();
            }


        }

        //get all products
        [HttpPost("all-products")]
        public async Task<ActionResult<ProductPagingDto>> GetAllProductsPaingAsync([FromBody]PagingRequestDto pagingRequestDto)
        {
                var products = await _productService.GetAllProductsPaingAsync(pagingRequestDto);
                return Ok(products);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductDto>> GetProductByIdAsync(int Id)
        {
                var product = await _productService.GetProductByIdAsync(Id);

                if (product == null)
                {
                    return NotFound();
                }

                return product;

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


        //admin
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductByIdAsync", new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                    return NotFound();                
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

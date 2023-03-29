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
        public async Task<ActionResult<ProductDto>> GetProductById(int Id)
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
        [HttpGet("get-product-admin/{Id}")]
        public async Task<ActionResult<ProductAdmin>> GetProductByIdAdminAsync(int Id)
        {
            var product = await _productService.GetProductByIdAdminAsync(Id);

            if (product == null)
            {
                return NotFound();
            }

            return product;

        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProductAsync([FromBody] ProductAdmin addProduct)
        {
            var product = await _productService.PostProductAsync(addProduct);

            Category category = _context.Categories.FirstOrDefault(c => c.Id == addProduct.CategoryId);
            CategoryProduct categoryProduct = new CategoryProduct() {
                CategoryId = addProduct.CategoryId,
                ProductId = product.Id,
                Category = category,
                Product = product,

            };
            _context.CategoryProduct.Add(categoryProduct);
            _context.SaveChanges();

            return CreatedAtAction("GetProductById", new { id = product.Id }, product);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutProductAsync(int Id, ProductAdmin updateProduct)
        {
            await _productService.PutProductAsync(Id, updateProduct);
            return NoContent();
        }


        [HttpPost("add-image")]
        public ActionResult UploadFile([FromForm] ImageDto file)
        {
            var result = _productService.UploadFile(file);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProductAsync(int Id)
        {
            var product = await _context.Products.FindAsync(Id);
            if (product == null)
            {
                return NotFound();
            }
            //List<Image> images = await _context.Images.Include(i => i.Product.Id == Id).ToListAsync();

            _context.CategoryProduct.Remove(_context.CategoryProduct.First(cp => cp.ProductId == Id));
            //_context.Images.RemoveRange(await _context.Images.Include(i => i.Products.Where));
            _context.Products.Remove(product);
            await _context.SaveChangesAsync(); 

            return NoContent();
        }
    }
}

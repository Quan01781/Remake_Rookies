using API_web.Data;
using API_web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedCommonModel.Category;

namespace API_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly WebDbContext _context;
        private readonly ICategory _categoryService;

        public CategoryController(WebDbContext context, ICategory categoryService) 
        {
            _context = context;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAllCategoryAsync()
        {
            try 
            {
                var categories = await _categoryService.GetAllCategoryAsync();   
                return Ok(categories);
            }
            catch (Exception ex) 
            {
                return BadRequest();
            }
        }
    }
}

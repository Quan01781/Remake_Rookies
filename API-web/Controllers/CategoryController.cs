using API_web.Data;
using API_web.Interfaces;
using API_web.Models;
using Microsoft.AspNetCore.Mvc;
using SharedCommonModel.Admin;
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


        [HttpGet("admin")]
        public async Task<List<CategoryAdmin>> GetCategoriesAdminAsync()
        {
            var categories = await _categoryService.GetCategoriesAdminAsync();
            return categories;

        }

 
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            var result = await _categoryService.PostCategoryAsync(category);
            if (result == true)
                return Ok(true);
            else
            {
                return BadRequest(false);
            }

        }


        [HttpPut]
        public async Task<IActionResult> PutCategory(Category category)
        {


            var result = await _categoryService.PutCategoryAsync(category);
            if (result == true)
                return Ok(true);
            else
            {
                return BadRequest(false);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeletedCategoryAsync(id);
            if (result == true)
                return Ok(true);
            else
            {
                return BadRequest(false);
            }
        }
    }
}

using API_web.Data;
using API_web.Interfaces;
using API_web.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SharedCommonModel.Category;

namespace API_web.Repositories
{
    public class CategoryRepository : ICategory
    {
        private readonly WebDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(WebDbContext WebDbContext, IMapper mapper)
        {
            _context = WebDbContext;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetAllCategoryAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            var categoriesDto = _mapper.Map<List<Category>,List<CategoryDto>>(categories);
            return categoriesDto;
        }
    }
}

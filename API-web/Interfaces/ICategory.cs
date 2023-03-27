using API_web.Models;
using SharedCommonModel;
using SharedCommonModel.Category;
using SharedCommonModel.Product;

namespace API_web.Interfaces
{
    public interface ICategory
    {
        public Task<List<CategoryDto>> GetAllCategoryAsync();
    }
}

using SharedCommonModel.Category;

namespace Customer.Services.Category
{
    public interface ICategory
    {
        public Task<List<CategoryDto>> GetCategories();
    }
}

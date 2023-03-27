using Customer.Extension;
using SharedCommonModel.Category;

namespace Customer.Services.Category
{
    public class CategoryServices : BaseServices, ICategory
    {
        public CategoryServices(IHttpClientFactory clientFactory, IHttpContextAccessor httpContextAccessor) : base(clientFactory, httpContextAccessor)
        {
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            var categories = await httpClient.GetAsJsonAsync<List<CategoryDto>>("api/category");
            return categories ?? new List<CategoryDto>();
        }
    }
}

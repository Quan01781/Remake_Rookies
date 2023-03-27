﻿using API_web.Models;
using SharedCommonModel;
using SharedCommonModel.Admin;
using SharedCommonModel.Category;
using SharedCommonModel.Product;

namespace API_web.Interfaces
{
    public interface ICategory
    {
        public Task<List<CategoryDto>> GetAllCategoryAsync();
        public Task<List<CategoryAdmin>> GetCategoriesAdminAsync();
        public Task<Boolean> PostCategoryAsync(Category category);
        public Task<Boolean> PutCategoryAsync(Category category);
        public Task<Boolean> DeletedCategoryAsync(int id);
    }
}
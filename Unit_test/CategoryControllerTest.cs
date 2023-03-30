using API_web.Controllers;
using API_web.Interfaces;
using API_web.Models;
using Moq;
using SharedCommonModel.Admin;

namespace Unit_test
{
    public class CategoryControllerTest
    {
        private List<CategoryAdmin> categories = new List<CategoryAdmin>
        {
            new CategoryAdmin(){ Id = 1, Name="Johnny", Description=""},
            new CategoryAdmin(){ Id = 2, Name="Dang", Description=""},
            new CategoryAdmin(){ Id = 3, Name="Khoa", Description=""},
            new CategoryAdmin(){ Id = 4, Name="Pug", Description=""}
        };

        [Fact]
        public async Task GetAllCategories()
        {
            var mockService = new Mock<ICategory>(); //Arrange
            mockService.Setup(x => x.GetCategoriesAdminAsync()).ReturnsAsync(categories);
            var controller = new CategoryController(mockService.Object);


            var result = await controller.GetCategoriesAdminAsync(); //Act

            Assert.IsType<List<CategoryAdmin>>(result.Value); //Assert
            Assert.Equal(categories, result.Value);
        }

        [Fact]
        public async Task CreateCategory()
        {
            CategoryAdmin createCategory = new CategoryAdmin()
            {
                Name = "Johnny",
                Description = "Dang"
            };
            Category return_category = new Category() { Name = "Johnny", Description = "Dang" };
            var mockService = new Mock<ICategory>();
            mockService.Setup(x => x.PostCategoryAsync(createCategory)).ReturnsAsync(return_category);
            var controller = new CategoryController(mockService.Object);


            var result = await controller.PostCategory(createCategory);


            Assert.IsType<Category>(result.Value);
            Assert.Equal(return_category, result.Value);

        }



        //[Fact]
        //public async Task UpdateCategpry() 
        //{
        //    var update_category = new AdminCategoryDTO()
        //    {
        //        Name = "After",
        //        Description = "after"
        //    };


        //    var After_Update = new AdminCategoryDTO() {ID = 1, Name = "After", Description= "after" };

        //    var mockService = new Mock<ICategoryService>();
        //    mockService.Setup(x => x.UpdateCategory(update_category,1)).ReturnsAsync(After_Update);
        //    var controller = new APIcategoryController(mockService.Object);


        //    var result = await controller.UpdateCategory(update_category,1);


        //    Assert.Equal(After_Update,result.Value);
        //}
    }
}
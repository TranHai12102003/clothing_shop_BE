using Clothing_shop.Entities;
using Clothing_shop.VModel;

namespace Clothing_shop.Mappings
{
    public static class CategoryMapping
    {
        public static CategoryGetVModel EntityToVModel(Category category)
        {
            return new CategoryGetVModel
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                ParentCategoryId = category.ParentCategoryId,
                ImageUrl = category.ImageUrl,
                CreatedDate = category.CreatedDate,
                UpdatedDate = category.UpdatedDate,
                IsActive = category.IsActive
            };
        }
        public static Category VModelToEntity(CategoryCreateVModel categoryVModel)
        {
            return new Category
            {
                CategoryName = categoryVModel.CategoryName,
                ParentCategoryId = categoryVModel.ParentCategoryId,
                IsActive = categoryVModel.IsActive
            };
        }
        public static Category VModelToEntity(CategoryUpdateVModel categoryVModel)
        {
            return new Category
            {
                Id = categoryVModel.Id,
                CategoryName = categoryVModel.CategoryName,
                ImageUrl = categoryVModel.ImageUrl,
                ParentCategoryId = categoryVModel.ParentCategoryId,
                UpdatedDate = DateTime.Now,
                IsActive = categoryVModel.IsActive,
            };
        }
    }
}

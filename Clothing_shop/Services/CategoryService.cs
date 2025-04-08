using Clothing_shop.Mappings;
using Clothing_shop.Repositories.IRepositories;
using Clothing_shop.Services.IService;
using Clothing_shop.VModel;
using Microsoft.AspNetCore.Mvc;
using OA.Domain.Common.Models;
using WebPizza_API_BackEnd.Common.Models;

namespace Clothing_shop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryService(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<ResponseResult> CreateCategory(CategoryCreateVModel category, string imageUrl)
        {
            var result = new ResponseResult();
            try
            {
                var categorysaved = CategoryMapping.VModelToEntity(category);
                categorysaved.ImageUrl = imageUrl;
                await _categoryRepo.AddAsync(categorysaved);
                result= new SuccessResponseResult(categorysaved,"Thêm danh mục thành công");
                return result;
            }
            catch(Exception ex)
            {
                return new ErrorResponseResult(ex.Message);
            }
        }

        public async Task<ResponseResult> DeleteCategory(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category == null)
            {
                return new ErrorResponseResult("Không tìm thấy danh mục");
            }

            await _categoryRepo.DeleteAsync(category);
            return new SuccessResponseResult("Xóa danh mục thành công");
        }

        public async Task<ActionResult<PaginationModel<CategoryGetVModel>>> GetAllCategories(CategoryFilterParams parameters)
        {
            var categories= await _categoryRepo.GetAllAsync();
            var ds = categories.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                 .Take(parameters.PageSize).Select(x => CategoryMapping.EntityToVModel(x)).ToList();

            return new PaginationModel<CategoryGetVModel>
            {
                Records = ds,
                TotalRecords = ds.Count
            };
        }

        public async Task<ActionResult<CategoryGetVModel>> GetCategoryById(int id)
        {

            var category = await _categoryRepo.GetByIdAsync(id);
            return category == null ? null : CategoryMapping.EntityToVModel(category);
        }

        public async Task<ResponseResult> UpdateCategory(int id, CategoryUpdateVModel category)
        {
            try
            {
                var entity = await _categoryRepo.GetByIdAsync(id); // Dùng id từ tham số
                if (entity == null)
                {
                    return new ErrorResponseResult("Không tìm thấy danh mục");
                }

                entity.CategoryName = category.CategoryName;
                entity.ParentCategoryId = category.ParentCategoryId;
                entity.UpdatedDate = DateTime.Now;
                entity.IsActive = category.IsActive;
                await _categoryRepo.UpdateAsync(entity);

                return new SuccessResponseResult(category, "Cập nhật danh mục thành công");
            }
            catch (Exception ex)
            {
                return new ErrorResponseResult(ex.Message);
            }
        }
    }
}

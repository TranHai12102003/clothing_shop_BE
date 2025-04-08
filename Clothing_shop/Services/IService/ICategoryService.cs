using Clothing_shop.VModel;
using Microsoft.AspNetCore.Mvc;
using OA.Domain.Common.Models;
using WebPizza_API_BackEnd.Common.Models;

namespace Clothing_shop.Services.IService
{
    public interface ICategoryService
    {
        Task<ActionResult<PaginationModel<CategoryGetVModel>>> GetAllCategories(CategoryFilterParams parameters);
        Task<ActionResult<CategoryGetVModel>> GetCategoryById(int id);
        Task<ResponseResult> CreateCategory(CategoryCreateVModel category, string imageUrl);
        Task<ResponseResult> UpdateCategory(int id, CategoryUpdateVModel category);
        Task<ResponseResult> DeleteCategory(int id);
    }
}

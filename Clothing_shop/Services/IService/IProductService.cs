using Clothing_shop.Entities;
using Clothing_shop.VModel;
using Microsoft.AspNetCore.Mvc;
using OA.Domain.Common.Models;
using WebPizza_API_BackEnd.Common.Models;

namespace Clothing_shop.Services.IService
{
    public interface IProductService
    {
        Task<ActionResult<PaginationModel<ProductGetVModel>>> GetAll(ProductFilterParams parameters);
        Task<ActionResult<ProductGetVModel>> GetById(int id);
        Task<ActionResult<PaginationModel<ProductGetVModel>>> GetByCategoryId(ProductFilterParams parameters, int categoryId);
        Task<ResponseResult> Create(ProductCreateVModel product);
        Task<ResponseResult> Update(ProductUpdateVModel product);
        Task<ResponseResult> Delete(int id);
    }
}

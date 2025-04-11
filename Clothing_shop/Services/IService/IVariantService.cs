using Clothing_shop.VModel;
using Microsoft.AspNetCore.Mvc;
using OA.Domain.Common.Models;
using WebPizza_API_BackEnd.Common.Models;

namespace Clothing_shop.Services.IService
{
    public interface IVariantService
    {
        Task<ActionResult<PaginationModel<VariantGetVModel>>> GetAll(VariantFilterParams parameters);
        Task<ActionResult<VariantGetVModel?>> GetById(int id);
        Task<ResponseResult> Create(VariantCreateVModel model);
        Task<ResponseResult> Update(VariantUpdateVModel model);
        Task<ResponseResult> Delete(int id);
    }
}

using Clothing_shop.VModel;
using Microsoft.AspNetCore.Mvc;
using OA.Domain.Common.Models;
using WebPizza_API_BackEnd.Common.Models;

namespace Clothing_shop.Services.IService
{
    public interface IColorService
    {
        Task<ActionResult<PaginationModel<ColorGetVModel>>> GetAll(ColorFilterParams parameters);
        Task<ActionResult<ColorGetVModel>> GetById(int id);
        Task<ResponseResult> Create(ColorCreateVModel model);
        Task<ResponseResult> Update(ColorUpdateVModel model);
        Task<ResponseResult> Delete(int id);
    }
}

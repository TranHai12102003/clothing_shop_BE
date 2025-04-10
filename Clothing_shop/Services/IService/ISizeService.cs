using Clothing_shop.Entities;
using Clothing_shop.VModel;
using Microsoft.AspNetCore.Mvc;
using OA.Domain.Common.Models;
using WebPizza_API_BackEnd.Common.Models;

namespace Clothing_shop.Services.IService
{
    public interface ISizeService
    {
        Task<ActionResult<PaginationModel<SizeGetVModel>>> GetAll(SizeFilterParams parameters);
        Task<ActionResult<SizeGetVModel?>> GetById(int id);
        Task<ResponseResult> Create(SizeCreateVModel size);
        Task<ResponseResult> Update(SizeUpdateVModel size);
        Task<ResponseResult> Delete(int id);
    }
}

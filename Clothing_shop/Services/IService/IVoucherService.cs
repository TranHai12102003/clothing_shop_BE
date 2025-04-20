using Clothing_shop.VModel;
using Microsoft.AspNetCore.Mvc;
using OA.Domain.Common.Models;
using WebPizza_API_BackEnd.Common.Models;

namespace Clothing_shop.Services.IService
{
    public interface IVoucherService
    {
        Task<ActionResult<PaginationModel<VoucherGetVModel>>> GetAll(VoucherFilterParams parameters);
        Task<ActionResult<VoucherGetVModel>> GetById(int id);
        Task<ResponseResult> Create(VoucherCreateVModel VModel);
        Task<ResponseResult> Update(VoucherUpdateVModel VModel);
        Task<ResponseResult> Delete(int id);
    }
}

using Clothing_shop.VModel;
using Microsoft.AspNetCore.Mvc;
using OA.Domain.Common.Models;
using WebPizza_API_BackEnd.Common.Models;

namespace Clothing_shop.Services.IService
{
    public interface ICustomerTypeService
    {
        Task<ActionResult<PaginationModel<CustomerTypeGetVModel>>> GetAll();
        Task<ActionResult<CustomerTypeGetVModel>> GetById(int id);
        Task<ResponseResult> Create(CustomerTypeCreateVModel vModel);
        Task<ResponseResult> Update(CustomerTypeUpdateVModel vModel);
        Task<ResponseResult> Delete(int id);
    }
}

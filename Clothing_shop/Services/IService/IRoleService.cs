using Clothing_shop.VModel;
using Microsoft.AspNetCore.Mvc;
using OA.Domain.Common.Models;
using WebPizza_API_BackEnd.Common.Models;

namespace Clothing_shop.Services.IService
{
    public interface IRoleService
    {
        Task<ActionResult<PaginationModel<RoleGetVModel>>> GetAll();
        Task<ActionResult<RoleGetVModel?>> GetById(int id);
        Task<ResponseResult> Create(RoleCreateVModel roleCreateVModel);
        Task<ResponseResult> Update(RoleUpdateVModel roleUpdateVModel);
        Task<ResponseResult> Delete(int id);
    }
}

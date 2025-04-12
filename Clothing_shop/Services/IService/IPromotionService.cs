using Clothing_shop.VModel;
using Microsoft.AspNetCore.Mvc;
using OA.Domain.Common.Models;
using WebPizza_API_BackEnd.Common.Models;

namespace Clothing_shop.Services.IService
{
    public interface IPromotionService
    {
        Task<ActionResult<PaginationModel<PromotionGetVModel>>> GetAll(PromotionFilterParams parameters);
        Task<ActionResult<PromotionGetVModel>> GetById(int id);
        Task<ResponseResult> Create(PromotionCreateVModel model);
        Task<ResponseResult> Update(PromotionUpdateVModel model);
        Task<ResponseResult> Delete(int id);
    }
}

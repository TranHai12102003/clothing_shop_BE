using Clothing_shop.Entities;
using Clothing_shop.Mappings;
using Clothing_shop.Repositories;
using Clothing_shop.Repositories.IRepositories;
using Clothing_shop.Services.IService;
using Clothing_shop.VModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OA.Domain.Common.Models;
using WebPizza_API_BackEnd.Common.Models;

namespace Clothing_shop.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepo _promotionRepo;
        public PromotionService(IPromotionRepo promotionRepo)
        {
            _promotionRepo = promotionRepo;
        }
        public async Task<ActionResult<PaginationModel<PromotionGetVModel>>> GetAll(PromotionFilterParams parameters)
        {
            var promotions = await _promotionRepo.GetAll(parameters);
            var ds = promotions.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize).Select(x => PromotionMapping.EntityToVModel(x)).ToList();
            return new PaginationModel<PromotionGetVModel>
            {
                Records = ds,
                TotalRecords = ds.Count
            };
        }
        public async Task<ActionResult<PromotionGetVModel>> GetById(int id)
        {
            var promotion = await _promotionRepo.GetById(id);
            if(promotion == null)
            {
                return new NotFoundObjectResult(new ErrorResponseResult("Không tìm thấy khuyến mãi"));
            }
            return PromotionMapping.EntityToVModel(promotion);
        }
        public async Task<ResponseResult> Create(PromotionCreateVModel model)
        {
            var response = new ResponseResult();
            try
            {
                var promotionSaved = PromotionMapping.VModelToEntity(model);
                await _promotionRepo.Create(promotionSaved);
                response = new SuccessResponseResult(promotionSaved, "Thêm khuyến mãi mới thành công");
                return response;
            }
            catch (Exception ex)
            {
                return new ErrorResponseResult(ex.Message);
            }
        }
        public async Task<ResponseResult> Update(PromotionUpdateVModel model)
        {
            var response = new ResponseResult();
            try
            {
                var promotion = await _promotionRepo.GetById(model.Id);
                if (promotion == null)
                {
                    return new ErrorResponseResult("Không tìm thấy khuyến mãi");
                }
                var promotionSaved = PromotionMapping.VModelToEntity(model);
                promotionSaved.CreatedDate = promotion.CreatedDate; 
                await _promotionRepo.Update(promotionSaved);
                response = new SuccessResponseResult(promotionSaved, "Cập nhật khuyến mãi thành công");
                return response;
            }
            catch (Exception ex)
            {
                return new ErrorResponseResult(ex.Message);
            }
        }
        public async Task<ResponseResult> Delete(int id)
        {
            var response = new ResponseResult();
            try
            {
                var promotion = await _promotionRepo.GetById(id);
                if (promotion == null)
                {
                    return new ErrorResponseResult("Không tìm thấy khuyến mãi");
                }
                await _promotionRepo.Delete(promotion);
                response = new SuccessResponseResult("Xóa khuyến mãi thành công");
                return response;
            }
            catch (Exception ex)
            {
                return new ErrorResponseResult(ex.Message);
            }
        }
    }
}

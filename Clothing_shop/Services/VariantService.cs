using Clothing_shop.Entities;
using Clothing_shop.Mappings;
using Clothing_shop.Repositories;
using Clothing_shop.Repositories.IRepositories;
using Clothing_shop.Services.IService;
using Clothing_shop.VModel;
using Microsoft.AspNetCore.Mvc;
using OA.Domain.Common.Models;
using WebPizza_API_BackEnd.Common.Models;

namespace Clothing_shop.Services
{
    public class VariantService : IVariantService
    {
        private readonly IVariantRepo _variantRepo;
        public VariantService(IVariantRepo variantRepo)
        {
            _variantRepo = variantRepo;

        }
        public async Task<ActionResult<PaginationModel<VariantGetVModel>>> GetAll(VariantFilterParams parameters)
        {
            var variants = await _variantRepo.GetAll(parameters);
            var ds = variants.Skip((parameters.PageNumber - 1) * parameters.PageSize).Take(parameters.PageSize)
                .Select(x=>VariantMapping.EntityToVModel(x))
                .ToList();
            return new PaginationModel<VariantGetVModel>
            {
                Records = ds,
                TotalRecords = ds.Count
            };
        }
        public async Task<ActionResult<VariantGetVModel?>> GetById(int id)
        {
            var variant = await _variantRepo.GetById(id);
            if (variant == null)
                return null;
            return VariantMapping.EntityToVModel(variant);
        }
        public async Task<ResponseResult> Create(VariantCreateVModel model)
        {
            var response = new ResponseResult();
            try
            {
                var variant = VariantMapping.VModelToEntity(model);
                await _variantRepo.Create(variant);
                response = new SuccessResponseResult(variant, "Thêm biến thể mới thành công");
                return response;

            }
            catch (Exception ex)
            {
                return new ErrorResponseResult(ex.Message);
            }
        }
        public async Task<ResponseResult> Update(VariantUpdateVModel model)
        {
            var response = new ResponseResult();
            try
            {
                var variant = VariantMapping.VModelToEntity(model);
                await _variantRepo.Update(variant);
                response = new SuccessResponseResult(variant, "Cập nhật sản phẩm thành công");
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
                var variant = await _variantRepo.GetById(id);
                if (variant == null)
                {
                    return new ErrorResponseResult("Không tìm thấy biến thể");
                }
                await _variantRepo.Delete(variant);
                response = new SuccessResponseResult(variant,"Xóa biến thể thành công");
                return response;
            }
            catch (Exception ex)
            {
                return new ErrorResponseResult(ex.Message);
            }
        }
    }
}

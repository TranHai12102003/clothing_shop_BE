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
    public class VoucherService : IVoucherService
    {
        private readonly IVoucherRepo _voucherRepo;
        public VoucherService(IVoucherRepo voucherRepo)
        {
            _voucherRepo = voucherRepo;
        }

        public async Task<ResponseResult> Create(VoucherCreateVModel VModel)
        {
            var response = new ResponseResult();
            try
            {
                var voucher = VoucherMapping.VModelToEntity(VModel);
                await _voucherRepo.Create(voucher);
                response = new SuccessResponseResult(voucher, "Thêm mã giảm giá mới thành công");
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
                var voucher = await _voucherRepo.GetById(id);
                if (voucher == null)
                    return new ErrorResponseResult("Không tìm thấy mã giảm giá");
                await _voucherRepo.Delete(voucher);
                response = new SuccessResponseResult(voucher, "Xóa mã giảm giá thành công");
                return response;
            }
            catch (Exception ex)
            {
                return new ErrorResponseResult(ex.Message);
            }
        }

        public async Task<ActionResult<PaginationModel<VoucherGetVModel>>> GetAll(VoucherFilterParams parameters)
        {
            var vouchers = await _voucherRepo.GetAll(parameters);
            var ds = vouchers.Skip((parameters.PageNumber - 1) * parameters.PageSize).Take(parameters.PageSize)
                .Select(x => VoucherMapping.EntityGetVModel(x))
                .ToList();
            return new PaginationModel<VoucherGetVModel>
            {
                Records = ds,
                TotalRecords = ds.Count
            };
        }

        public async Task<ActionResult<VoucherGetVModel>> GetById(int id)
        {
            var voucher = await _voucherRepo.GetById(id);
            if (voucher == null)
                return null;
            return VoucherMapping.EntityGetVModel(voucher);
        }

        public async Task<ResponseResult> Update(VoucherUpdateVModel VModel)
        {
            var response = new ResponseResult();
            try
            {
                var voucher = VoucherMapping.VModelToEntity(VModel);
                await _voucherRepo.Update(voucher);
                response = new SuccessResponseResult(voucher, "Cập nhật mã giảm giá thành công");
                return response;
            }
            catch (Exception ex)
            {
                return new ErrorResponseResult(ex.Message);
            }
        }
    }
}

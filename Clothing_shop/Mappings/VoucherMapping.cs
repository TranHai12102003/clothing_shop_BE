using Clothing_shop.Entities;
using Clothing_shop.VModel;

namespace Clothing_shop.Mappings
{
    public static class VoucherMapping
    {
        public static VoucherGetVModel EntityGetVModel(Voucher voucher)
        {
            return new VoucherGetVModel
            {
                Id = voucher.Id,
                VoucherCode = voucher.VoucherCode,
                Description = voucher.Description,
                DiscountType = voucher.DiscountType,
                DiscountValue = voucher.DiscountValue,
                MinOrderAmount = voucher.MinOrderAmount,
                StartDate = voucher.StartDate,
                EndDate = voucher.EndDate,
                MaxUsage = voucher.MaxUsage,
                UsedCount = voucher.UsedCount,
                IsActive = voucher.IsActive,
                CustomerTypeId = voucher.CustomerTypeId,
                CreatedDate = voucher.CreatedDate
            };
        }
        public static Voucher VModelToEntity(VoucherCreateVModel voucherCreateVModel)
        {
            return new Voucher
            {
                VoucherCode = voucherCreateVModel.VoucherCode,
                Description = voucherCreateVModel.Description,
                DiscountType = voucherCreateVModel.DiscountType,
                DiscountValue = voucherCreateVModel.DiscountValue,
                MinOrderAmount = voucherCreateVModel.MinOrderAmount,
                StartDate = voucherCreateVModel.StartDate,
                EndDate = voucherCreateVModel.EndDate,
                MaxUsage = voucherCreateVModel.MaxUsage,
                UsedCount = voucherCreateVModel.UsedCount,
                IsActive = voucherCreateVModel.IsActive,
                CustomerTypeId = voucherCreateVModel.CustomerTypeId,
                CreatedDate = DateTime.Now
            };
        }
        public static Voucher VModelToEntity(VoucherUpdateVModel voucherUpdateVModel)
        {
            return new Voucher
            {
                Id = voucherUpdateVModel.Id,
                VoucherCode = voucherUpdateVModel.VoucherCode,
                Description = voucherUpdateVModel.Description,
                DiscountType = voucherUpdateVModel.DiscountType,
                DiscountValue = voucherUpdateVModel.DiscountValue,
                MinOrderAmount = voucherUpdateVModel.MinOrderAmount,
                StartDate = voucherUpdateVModel.StartDate,
                EndDate = voucherUpdateVModel.EndDate,
                MaxUsage = voucherUpdateVModel.MaxUsage,
                UsedCount = voucherUpdateVModel.UsedCount,
                IsActive = voucherUpdateVModel.IsActive,
                CustomerTypeId = voucherUpdateVModel.CustomerTypeId,
                CreatedDate = voucherUpdateVModel.CreatedDate,
                UpdatedDate = DateTime.Now
            };
        }
    }
}

using Clothing_shop.Entities;
using Clothing_shop.VModel;

namespace Clothing_shop.Mappings
{
    public static class PromotionMapping
    {
        public static Promotion VModelToEntity(PromotionCreateVModel model)
        {
            return new Promotion
            {
                PromotionName = model.PromotionName,
                PercentDiscount = model.PercentDiscount,
                DiscountValue = model.DiscountValue,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                IsActive = model.IsActive,
                CreatedDate = model.CreatedDate
            };
        }
        public static Promotion VModelToEntity(PromotionUpdateVModel model)
        {
            return new Promotion
            {
                Id = model.Id,
                PromotionName = model.PromotionName,
                PercentDiscount = model.PercentDiscount,
                DiscountValue = model.DiscountValue,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                IsActive = model.IsActive,
                UpdatedDate = model.UpdatedDate
            };
        }
        public static PromotionGetVModel EntityToVModel(Promotion entity)
        {
            return new PromotionGetVModel
            {
                Id = entity.Id,
                PromotionName = entity.PromotionName,
                PercentDiscount = entity.PercentDiscount,
                DiscountValue = entity.DiscountValue,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                IsActive = entity.IsActive,
                CreatedDate = entity.CreatedDate,
                UpdatedDate = entity.UpdatedDate
            };
        }
    }
}

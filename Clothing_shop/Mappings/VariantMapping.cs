using Clothing_shop.Common.Contansts;
using Clothing_shop.Entities;
using Clothing_shop.VModel;

namespace Clothing_shop.Mappings
{
    public static class VariantMapping
    {
        public static Variant VModelToEntity(VariantCreateVModel model)
        {
            return new Variant
            {
                ProductId = model.ProductId,
                SizeId = model.SizeId,
                ColorId = model.ColorId,
                Price = model.Price,
                SalePrice = model.SalePrice,
                QuantityInStock = model.QuantityInStock,
                CreatedDate = DateTime.Now,
                UpdatedDate = null
            };
        }
        public static Variant VModelToEntity(VariantUpdateVModel model)
        {
            return new Variant
            {
                Id = model.Id,
                ProductId = model.ProductId,
                SizeId = model.SizeId,
                ColorId = model.ColorId,
                Price = model.Price,
                SalePrice = model.SalePrice,
                QuantityInStock = model.QuantityInStock,
                CreatedDate = model.CreatedDate,
                UpdatedDate = DateTime.Now
            };
        }
        public static VariantGetVModel EntityToVModel(Variant entity)
        {
            var variant = new VariantGetVModel
            {
                Id = entity.Id,
                ProductId = entity.ProductId,
                SizeId = entity.SizeId,
                ColorId = entity.ColorId,
                Price = entity.Price,
                SalePrice = entity.SalePrice,
                QuantityInStock = entity.QuantityInStock,
                CreatedDate = entity.CreatedDate,
                UpdatedDate = entity.UpdatedDate
            };
            if (entity.Product != null)
            {
                variant.Product = new IdNameVModel
                {
                    Id = entity.Product.Id,
                    Name = entity.Product.ProductName
                };
            }
            if (entity.Size != null)
            {
                variant.Size = new IdNameVModel
                {
                    Id = entity.Size.Id,
                    Name = entity.Size.SizeName
                };
            }
            if (entity.Color != null)
            {
                variant.Color = new IdNameVModel
                {
                    Id = entity.Color.Id,
                    Name = entity.Color.ColorName
                };
            }
            return variant;
        }
    }
}

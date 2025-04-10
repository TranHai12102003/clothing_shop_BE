using Clothing_shop.Common.Contansts;
using Clothing_shop.Entities;
using Clothing_shop.VModel;

namespace Clothing_shop.Mappings
{
    public static class ProductMapping
    {
        public static Product VModelToEntity(ProductCreateVModel model)
        {
            return new Product
            {
                ProductName = model.ProductName,
                Description = model.Description,
                CategoryId = model.CategoryId,
                CreatedDate = model.CreatedDate,
                UpdatedDate = model.UpdatedDate
            };
        }
        public static Product VModelToEntity(ProductUpdateVModel model)
        {
            return new Product
            {
                Id = model.Id,
                ProductName = model.ProductName,
                Description = model.Description,
                CategoryId = model.CategoryId,
                CreatedDate = model.CreatedDate,
                UpdatedDate = model.UpdatedDate
            };
        }
        public static ProductGetVModel EntityToVModel(Product entity)
        {
            var product = new ProductGetVModel
            {
                Id = entity.Id,
                ProductName = entity.ProductName,
                Description = entity.Description,
                CategoryId = entity.CategoryId,
                CreatedDate = entity.CreatedDate,
                UpdatedDate = entity.UpdatedDate
            };
            if (entity.Category != null)
            {
                product.Category = new IdNameVModel
                {
                    Id = entity.Category.Id,
                    Name = entity.Category.CategoryName
                };
            }
            return product;
        }
    }
}

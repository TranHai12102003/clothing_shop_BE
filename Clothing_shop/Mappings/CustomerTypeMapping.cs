using Clothing_shop.Common.Contansts;
using Clothing_shop.Entities;
using Clothing_shop.VModel;

namespace Clothing_shop.Mappings
{
    public static class CustomerTypeMapping
    {
        public static CustomerTypeGetVModel EntityToVModel(CustomerType model)
        {
            var customerType = new CustomerTypeGetVModel
            {
                Id = model.Id,
                TypeName = model.TypeName,
                Description = model.Description,
                MinOrderCount = model.MinOrderCount,
                MinTotalAmount = model.MinTotalAmount,
                CreatedDate = model.CreatedDate,
                UpdatedDate = model.UpdatedDate
            };
            return customerType;
        }
        public static CustomerType VModelToEntity(CustomerTypeCreateVModel model)
        {
            var customerType = new CustomerType
            {
                TypeName = model.TypeName,
                Description = model.Description,
                MinOrderCount = model.MinOrderCount,
                MinTotalAmount = model.MinTotalAmount,
                CreatedDate = model.CreatedDate,
                UpdatedDate = model.UpdatedDate
            };
            return customerType;
        }
        public static CustomerType VModelToEntity(CustomerTypeUpdateVModel model)
        {
            var customerType = new CustomerType
            {
                Id = model.Id,
                TypeName = model.TypeName,
                Description = model.Description,
                MinOrderCount = model.MinOrderCount,
                MinTotalAmount = model.MinTotalAmount,
                CreatedDate = model.CreatedDate,
                UpdatedDate = model.UpdatedDate
            };
            return customerType;
        }
    }
}

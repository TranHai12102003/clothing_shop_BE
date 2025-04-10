using Clothing_shop.Entities;
using Clothing_shop.VModel;

namespace Clothing_shop.Mappings
{
    public static class SizeMapping
    {
        public static Size VModelToEntity(SizeCreateVModel size)
        {
            return new Size
            {
                SizeName = size.SizeName,
                CreatedDate = size.CreatedDate,
                UpdatedDate = size.UpdatedDate
            };
        }
        public static Size VModelToEntity(SizeUpdateVModel size)
        {
            return new Size
            {
                Id = size.Id,
                SizeName = size.SizeName,
                CreatedDate = size.CreatedDate,
                UpdatedDate = size.UpdatedDate
            };
        }
        public static SizeGetVModel EntityToVmodel(Size size)
        {
            return new SizeGetVModel
            {
                Id = size.Id,
                SizeName = size.SizeName,
                CreatedDate = size.CreatedDate,
                UpdatedDate = size.UpdatedDate
            };
        }
    }
}

using Clothing_shop.Entities;
using Clothing_shop.VModel;

namespace Clothing_shop.Mappings
{
    public static class ColorMapping
    {
        public static ColorGetVModel EntityToVModel(Color color)
        {
            return new ColorGetVModel
            {
                Id = color.Id,
                ColorName = color.ColorName,
                ColorCode = color.ColorCode,
                CreatedDate = color.CreatedDate,
                UpdatedDate = color.UpdatedDate
            };
        }
        public static Color VModelToEntity(ColorCreateVModel colorVModel)
        {
            return new Color
            {
                ColorName = colorVModel.ColorName,
                ColorCode = colorVModel.ColorCode,
                CreatedDate = colorVModel.CreatedDate
            };
        }
        public static Color VModelToEntity(ColorUpdateVModel colorVModel)
        {
            return new Color
            {
                Id = colorVModel.Id,
                ColorName = colorVModel.ColorName,
                ColorCode = colorVModel.ColorCode,
                UpdatedDate = DateTime.Now
            };
        }
    }
}

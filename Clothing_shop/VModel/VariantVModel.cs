using Clothing_shop.Common.Contansts;
using OA.Domain.Common.Constants;

namespace Clothing_shop.VModel
{
    public class VariantCreateVModel
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public decimal Price { get; set; }
        public decimal? SalePrice { get; set; }
        public int QuantityInStock { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
    public class VariantUpdateVModel : VariantCreateVModel
    {
        public int Id { get; set; }
    }
    public class VariantGetVModel : VariantUpdateVModel
    {
        public IdNameVModel Product { get; set; }
        public IdNameVModel Size { get; set; }
        public IdNameVModel Color { get; set; }
    }
    public class VariantFilterParams
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int PageSize { get; set; } = Numbers.Pagination.DefaultPageSize;
        public int PageNumber { get; set; } = Numbers.Pagination.DefaultPageNumber;
    }
}

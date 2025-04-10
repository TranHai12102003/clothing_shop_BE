using Clothing_shop.Common.Contansts;
using OA.Domain.Common.Constants;

namespace Clothing_shop.VModel
{
    public class ProductCreateVModel
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
    public class ProductUpdateVModel : ProductCreateVModel
    {
        public int Id { get; set; }
    }
    public class ProductGetVModel : ProductUpdateVModel
    {
        public IdNameVModel Category { get; set; }
    }
    public class ProductFilterParams
    {
        public string? Name { get; set; }
        public int PageSize { get; set; } = Numbers.Pagination.DefaultPageSize;
        public int PageNumber { get; set; } = Numbers.Pagination.DefaultPageNumber;
    }
}

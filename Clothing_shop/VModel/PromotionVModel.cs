using OA.Domain.Common.Constants;

namespace Clothing_shop.VModel
{
    public class PromotionCreateVModel
    {
        public string PromotionName { get; set; }
        public int PercentDiscount { get; set; }
        public decimal DiscountValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class PromotionUpdateVModel : PromotionCreateVModel
    {
        public int Id { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
    public class PromotionGetVModel : PromotionUpdateVModel
    {
    }
    public class PromotionFilterParams
    {
        public string? PromotionName { get; set; }
        public int? PercentDiscount { get; set; }
        public decimal? DiscountValue { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
        public int PageSize { get; set; } = Numbers.Pagination.DefaultPageSize;
        public int PageNumber { get; set; } = Numbers.Pagination.DefaultPageNumber;
    }
}

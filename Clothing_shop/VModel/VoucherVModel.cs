using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OA.Domain.Common.Constants;

namespace Clothing_shop.VModel
{
    public class VoucherCreateVModel
    {
        public string VoucherCode { get; set; }
        public string Description { get; set; }
        public string DiscountType { get; set; }

        public decimal DiscountValue { get; set; }
        public decimal? MinOrderAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? MaxUsage { get; set; }
        public int UsedCount { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public int? CustomerTypeId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
    public class VoucherUpdateVModel : VoucherCreateVModel
    {
        public int Id { get; set; }
    }
    public class VoucherGetVModel : VoucherUpdateVModel
    {

    }
    public class VoucherFilterParams
    {
        public string? VoucherCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public int PageSize { get; set; } = Numbers.Pagination.DefaultPageSize;
        public int PageNumber { get; set; } = Numbers.Pagination.DefaultPageNumber;
    }
}

using OA.Domain.Common.Constants;

namespace Clothing_shop.VModel
{
    public class SizeCreateVModel
    {
        public string SizeName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; } = null;
    }
    public class SizeUpdateVModel : SizeCreateVModel
    {
        public int Id { get; set; }
    }
    public class SizeGetVModel : SizeUpdateVModel
    {
    }
    public class SizeFilterParams
    {
        public string? SizeName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int PageSize { get; set; } = Numbers.Pagination.DefaultPageSize;
        public int PageNumber { get; set; } = Numbers.Pagination.DefaultPageNumber;
    }
}

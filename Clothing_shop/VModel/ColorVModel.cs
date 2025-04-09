using System.ComponentModel.DataAnnotations;
using OA.Domain.Common.Constants;

namespace Clothing_shop.VModel
{
    public class ColorCreateVModel
    {
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
    public class ColorUpdateVModel : ColorCreateVModel
    {
        public int Id { get; set; }
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
    }
    public class ColorGetVModel : ColorUpdateVModel
    {
    }
    public class ColorFilterParams 
    {
        public string? ColorName { get; set; }
        public string? ColorCode { get; set; }
        public int PageSize { get; set; } = Numbers.Pagination.DefaultPageSize;
        public int PageNumber { get; set; } = Numbers.Pagination.DefaultPageNumber;
    }
}

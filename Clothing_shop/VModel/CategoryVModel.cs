using Clothing_shop.Common.Contansts;
using OA.Domain.Common.Constants;

namespace Clothing_shop.VModel
{
    public class CategoryCreateVModel
    {
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; } = null;
        public string? ImageUrl { get; set; } = null;
        public bool IsActive { get; set; } = true;

    }
    public class CategoryUpdateVModel : CategoryCreateVModel
    {
        public int Id { get; set; }
    }
    public class CategoryGetVModel : CategoryUpdateVModel
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public IdNameVModel ParentCategory { get; set; }
    }
    public class CategoryFilterParams
    {
        public string? Name { get; set; }
        public int PageSize { get; set; } = Numbers.Pagination.DefaultPageSize;
        public int PageNumber { get; set; } = Numbers.Pagination.DefaultPageNumber;
    }
}

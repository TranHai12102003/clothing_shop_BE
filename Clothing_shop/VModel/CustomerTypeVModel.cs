using System.ComponentModel.DataAnnotations;
using Clothing_shop.Common.Contansts;

namespace Clothing_shop.VModel
{
    public class CustomerTypeCreateVModel
    {
        public string TypeName { get; set; }
        public string Description { get; set; }
        public int? MinOrderCount { get; set; }
        public decimal? MinTotalAmount { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
    public class  CustomerTypeUpdateVModel : CustomerTypeCreateVModel
    {
        public int Id { get; set; }    
}
    public class CustomerTypeGetVModel : CustomerTypeUpdateVModel
    {
    }
}

using System.ComponentModel.DataAnnotations;

namespace ProductApp.Models
{
    public class CProductInfo
    {
        [Key]
        public int productId { get; set; }
        public string? productName { get; set; }
        public string? productDescription { get; set; }
        public string? productCategory { get; set;}
        public string? productSubCategory { get; set;}
        public int productStockQty { get; set; }
        public int productAvailQty { get; set; }
        public decimal productPrice { get; set;} 
        public string? productImage { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace ProductApp.Models
{
    public class CCartInfo
    {

        [Key]
        public string? productId { get; set; }
        public string? productName { get; set; }
        public int productQty { get; set; }
        public decimal productPrice { get; set; }
    }
}

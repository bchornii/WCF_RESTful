using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Wcf.DAL
{
    [DataContract]
    public class Product
    {
        [DataMember(Name = "productId")]
        [Required(ErrorMessage = "Product id is required")]
        public int ProductId { get; set; }        

        [DataMember(Name = "productName")]
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Product name should be 2-20 symbols.")]
        public string ProductName { get; set; }

        [DataMember(Name = "supplierId")]
        [Required(ErrorMessage = "Supplier id is required")]
        public int SupplierId { get; set; }

        [DataMember(Name = "categoryId")]
        [Required(ErrorMessage = "Category id is required")]
        public int CategoryId { get; set; }

        [DataMember(Name = "unitPrice")]
        [Required(ErrorMessage = "Unit price is required")]
        [Range(18.0,double.MaxValue, ErrorMessage = "Unit price should be positive value.")]
        public decimal UnitPrice { get; set; }

        [DataMember(Name = "discounted")]
        [Required(ErrorMessage = "Discounted is required")]
        public bool Discounted { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace BikersPortal.Models
{
    [Table(name: "Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }


        #region Directing to Category


        [Display(Name = "Dish Category")]
        public int ProductTypeId { get; set; }
        [ForeignKey(nameof(Product.ProductTypeId))]
        public ProductType ProductType { get; set; }

        #endregion



        [Required(ErrorMessage = "Don't leave {0} Empty!")]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "ProductName")]
        public string ProductName { get; set; }


        [Required]
        [DefaultValue(true)]
        [Display(Name = "In Stock")]
        public bool Available { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public float Price { get; set; }


        [Display(Name = "Product Image")]
        public string ImgUrl { get; set; } 

        #region Navigate Collection to Order
        public ICollection<Order> Orders { get; set; }
        #endregion




    }
}

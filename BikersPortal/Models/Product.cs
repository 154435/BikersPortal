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


        [Display(Name = "Product Category")]
        public int ProductTypeId { get; set; }
        [ForeignKey(nameof(Product.ProductTypeId))]            //Make ForeignKey using Product Type Table(Id)
        public ProductType ProductType { get; set; }            //Bike Company Name

        #endregion



        [Required(ErrorMessage = "Don't leave {0} Empty!")]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "ProductName")]
        public string ProductName { get; set; }                 //Bike Name


        [Required]
        [DefaultValue(true)]
        [Display(Name = "In Stock")]
        public bool Available { get; set; }                     //In stock

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public float Price { get; set; }                        //price of bike


        [Display(Name = "Product Image")]
        public string ImgUrl { get; set; }                     //Image of Bike

        #region Navigate Collection to Order
        public ICollection<Order> Orders { get; set; }        //Collection of Order Table
        #endregion




    }
}

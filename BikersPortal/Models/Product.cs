using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        [Display(Name = "Company Name")]
        public int ProductTypeId { get; set; }
        [ForeignKey(nameof(Product.ProductTypeId))]            //Make ForeignKey using Product Type Table(Id)
        public ProductType ProductType { get; set; }            //Bike Company Name

        #endregion



        [Required(ErrorMessage = "Don't leave {0} Empty!")]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Bike Name")]
        public string ProductName { get; set; }                 //Bike Name


        [Required]
        [DefaultValue(true)]
        [Display(Name = "In Stock")]
        public bool Available { get; set; }                     //In stock

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public float Price { get; set; }                        //price of bike


        [Display(Name = "Bike Image")]
        public string ImgUrl { get; set; }                     //Image of Bike

        #region Navigate Collection to Order
        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }        //Collection of Order Table
        #endregion




    }
}

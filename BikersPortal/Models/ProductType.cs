using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace BikersPortal.Models
{
    [Table(name: "ProductTypes")]
    public class ProductType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Product Type ID")]  
        public int ProductTypeId { get; set; }


        [Required(ErrorMessage = "Don't leave {0} Empty!")]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Company Name")]
        public string ProductTypes { get; set; }                     //Bike Company Name


        #region Navigate Collection to Product\
        [JsonIgnore]
        public ICollection<Product> Product { get; set; }            //Collection of Product Table
        #endregion


    }
}

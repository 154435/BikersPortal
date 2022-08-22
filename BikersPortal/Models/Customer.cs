using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BikersPortal.Models
{
    [Table(name: "Customers")]        //Model For Customers
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }                          //Customer Name Field

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid! Mobile Number XXX-XXX-XXXX")]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }                          //Mobile Number Field

        [Required(ErrorMessage = "Don't leave {0} Address Empty!")]
        [Display(Name = "EMAIL")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Not a valid {0} Address")]
        public string Email { get; set; }                                 //Email Address

     

        [Required(ErrorMessage = "Don't leave {0} Address Cannot be Empty!")]

        public string Address { get; set; }                               //Customer Address


        #region Navigate Collection to Order                             
        public ICollection<Order> Orders { get; set; }                    //Collection Of Order Table
        #endregion








    }
}

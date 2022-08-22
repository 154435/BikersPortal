using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;

namespace BikersPortal.Models
{
    [Table(name: "PaymentMethods")]
    public class PaymentMethod
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Payment Method ID")]
        public int PaymentMethodId { get; set; }

        [Required(ErrorMessage = "{0} Should be Mentioned")]
        [StringLength(50)]                                               //Validations
        [MinLength(2, ErrorMessage = "{0} Should Be Valid")]
        [MaxLength(50, ErrorMessage = "{0} Should Be Valid")]
        [Display(Name = "Payment Method")]                               //Payment Method Name(eg Paytm,Google pay)
        public string PaymentMethodName { get; set; }

        [Required]
        [DefaultValue(true)]
        [Display(Name = "Method Enabled")]
        public bool MethodEnabled { get; set; }

        #region Navigate Collection to Order
        public ICollection<Order> Orders { get; set; }                   //Collection of order Table
        #endregion


    }
}

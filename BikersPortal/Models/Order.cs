using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace BikersPortal.Models
{
    [Table(name: "Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

       







        [Display(Name = "Date")]
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; } = DateTime.Now;







        #region Dish Link 

        [Display(Name = "Product")]
        public int ProductId { get; set; }
        [ForeignKey(nameof(Order.ProductId))]
        public Product Product { get; set;  }

        #endregion


        [Required(ErrorMessage = "Don't leave {0} Empty!")]
        [Display(Name = "Quantity(Number of Product)")]
        [DefaultValue(1)]
        public short NumberOfProduct { get; set; }


        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        [ForeignKey(nameof(Order.CustomerId))]
        public Customer Customer { get; set; }

     



        #region Payment Link

        [Display(Name = "Payment Method")]
        public int PaymentMethodId { get; set; }
        [ForeignKey(nameof(Order.PaymentMethodId))]
        public PaymentMethod PaymentMethods { get; set; }

        #endregion


        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public Double Price { get; set; }

        [Display(Name ="Product Description")]
        public String Description  { get; set; }

        [Required]
        [DefaultValue(true)]
        [Display(Name = "Order Placed")]
        public bool OrderPlaced { get; set; }



    }
}

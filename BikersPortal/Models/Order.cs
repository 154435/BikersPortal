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

       






        //Order Placed Date

        [Display(Name = "Date")]
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; } = DateTime.Now;







        #region  product  Link 

        [Display(Name = "Product")]
        public int ProductId { get; set; }
        [ForeignKey(nameof(Order.ProductId))]          //Make ForeignKey using Product Table(Id)
        public Product Product { get; set;  }

        #endregion


        [Required(ErrorMessage = "Don't leave {0} Empty!")]
        [Display(Name = "Quantity(Number of Product)")]
        [DefaultValue(1)]
        public short NumberOfProduct { get; set; }      //Number Of Product 

         
        [Display(Name = "Customer")]                    //Custome Name
        public int CustomerId { get; set; }
        [ForeignKey(nameof(Order.CustomerId))]          //Make ForeignKey using Customer Table(Id)
        public Customer Customer { get; set; }         

     



        #region Payment Link

        [Display(Name = "Payment Method")]
        public int PaymentMethodId { get; set; }
        [ForeignKey(nameof(Order.PaymentMethodId))]              //Make ForeignKey using Payment Method Table(Id)
        public PaymentMethod PaymentMethods { get; set; }

        #endregion


        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public Double Price { get; set; }                        //Price of Bike in dollars

        [Display(Name ="Product Description")]
        public String Description  { get; set; }                 //Customer can Give Description of product

        [Required]
        [DefaultValue(true)]
        [Display(Name = "Order Placed")]                        //Order Placed
        public bool OrderPlaced { get; set; }



    }
}

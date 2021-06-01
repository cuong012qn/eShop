using eShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Data.Models
{
    [Table("Order")]
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { set; get; }

        [Required]
        public string ShipName { set; get; }

        [Required]
        public string ShipAddress { set; get; }

        [Required]
        public string ShipEmail { set; get; }

        [Required]
        public string ShipPhoneNumber { set; get; }

        [ForeignKey("CustomerId")]
        public string CustomerId { get; set; }

        public Customer Customer { get; set; }

        public OrderStatus Status { set; get; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}

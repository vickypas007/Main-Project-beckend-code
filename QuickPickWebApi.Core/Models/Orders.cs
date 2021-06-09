using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuickPickWebApi.Core.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }

        [ForeignKey("OrderStatusId")]
        public int OrderStatusId { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderDetail { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [ForeignKey("OrderStatusId")]
        public OrderStatus OrderStatus { get; set; }

        [ForeignKey("ProductId")]
        public Products Products { get; set; }

    }
}

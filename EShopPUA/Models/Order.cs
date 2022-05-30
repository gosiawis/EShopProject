using System;
using System.Collections.Generic;

namespace EShopPUA.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int OrderStatusId { get; set; }
        public int PaymentStatusId { get; set; }
        public int PaymentMethodId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual OrderStatus OrderStatus { get; set; } = null!;
        public virtual PaymentMethod PaymentMethod { get; set; } = null!;
        public virtual PaymentStatus PaymentStatus { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}

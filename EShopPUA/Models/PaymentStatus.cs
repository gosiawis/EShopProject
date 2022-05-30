using System;
using System.Collections.Generic;

namespace EShopPUA.Models
{
    public partial class PaymentStatus
    {
        public PaymentStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}

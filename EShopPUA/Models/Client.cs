using System;
using System.Collections.Generic;

namespace EShopPUA.Models
{
    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int DistrictId { get; set; }
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual District District { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace EShopPUA.Models
{
    public partial class Client
    {
        public Client()
        {
            ClientsAddresses = new HashSet<ClientsAddress>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<ClientsAddress> ClientsAddresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}

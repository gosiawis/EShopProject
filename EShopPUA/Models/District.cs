using System;
using System.Collections.Generic;

namespace EShopPUA.Models
{
    public partial class District
    {
        public District()
        {
            Clients = new HashSet<Client>();
            Warehouses = new HashSet<Warehouse>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}

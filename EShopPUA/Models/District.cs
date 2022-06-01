using System;
using System.Collections.Generic;

namespace EShopPUA.Models
{
    public partial class District
    {
        public District()
        {
            Addresses = new HashSet<Address>();
            Warehouses = new HashSet<Warehouse>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}

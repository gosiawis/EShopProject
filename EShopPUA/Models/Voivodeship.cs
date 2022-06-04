using System;
using System.Collections.Generic;

namespace EShopPUA.Models
{
    public partial class Voivodeship
    {
        public Voivodeship()
        {
            Clients = new HashSet<Client>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Client> Clients { get; set; }
    }
}

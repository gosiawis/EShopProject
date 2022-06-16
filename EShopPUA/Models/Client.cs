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
        public string Email { get; set; } = null!;
        public int VoivodeshipId { get; set; }
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int HouseNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public string ZipCode { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string CreatetdBy { get; set; } = null!;
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; } = null!;

        public virtual Voivodeship Voivodeship { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace EShopPUA.Models
{
    public partial class Address
    {
        public Address()
        {
            ClientsAddresses = new HashSet<ClientsAddress>();
        }

        public int Id { get; set; }
        public int DistrictId { get; set; }
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int HouseNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public string ZipCode { get; set; } = null!;

        public virtual District District { get; set; } = null!;
        public virtual ICollection<ClientsAddress> ClientsAddresses { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace EShopPUA.Models
{
    public partial class ClientsAddress
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual Client Client { get; set; } = null!;
    }
}

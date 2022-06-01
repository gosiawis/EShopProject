using System;
using System.Collections.Generic;

namespace EShopPUA.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            Stocks = new HashSet<Stock>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int DistrictId { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int? HouseNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public string? ZipCode { get; set; }

        public virtual District District { get; set; } = null!;
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}

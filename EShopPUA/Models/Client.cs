using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Voivodeship")]
        public int VoivodeshipId { get; set; }
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int HouseNumber { get; set; }

        [Display(Name = "Apartment number")]
        public int? ApartmentNumber { get; set; }

        [Display(Name = "Zip code")]
        public string ZipCode { get; set; } = null!;

        [Display(Name = "Created date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Created by")]
        public string CreatetdBy { get; set; } = null!;

        [Display(Name = "Last modified date")]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "Last modified by")]
        public string LastModifiedBy { get; set; } = null!;

        public virtual Voivodeship? Voivodeship { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}

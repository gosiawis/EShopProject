using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EShopPUA.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        [Display(Name = "Created date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name ="Created by")]
        public string CreatetdBy { get; set; } = null!;

        [Display(Name = "Last modified date")]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "Last modified by")]
        public string LastModifiedBy { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}

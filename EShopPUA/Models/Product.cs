using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EShopPUA.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        [Display(Name = "Brand")]
        public int BrandId { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public byte[]? Picture { get; set; }

        [Display(Name = "Created date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Created by")]
        public string CreatetdBy { get; set; } = null!;

        [Display(Name = "Last modified date")]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "Last modified by")]
        public string LastModifiedBy { get; set; } = null!;

        public virtual Brand? Brand { get; set; } = null!;
        public virtual Category? Category { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}

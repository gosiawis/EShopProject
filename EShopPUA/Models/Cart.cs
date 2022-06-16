using System;
using System.Collections.Generic;

namespace EShopPUA.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}

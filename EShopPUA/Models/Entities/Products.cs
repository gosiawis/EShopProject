namespace EShopPUA.Models.Entities
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        
    }
}

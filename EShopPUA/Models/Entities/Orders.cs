namespace EShopPUA.Models.Entities
{
    public class Orders
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int OrderStatusId { get; set; }
        public int PaymentStatusId { get; set; }
        public int PaymentMethodId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}

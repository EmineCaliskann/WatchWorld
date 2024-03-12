namespace ApplicationCore.Entities
{
    public class Order : BaseEntity
    {
        public string BuyerId { get; set; } = null!;

        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;

        public Address ShipToAddrress { get; set; } = null!;

        public List<OrderItem> Items { get; set; } = [];
    }
}

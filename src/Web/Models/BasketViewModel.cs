using ApplicationCore.Entities;

namespace Web.Models
{
    public class BasketViewModel
    {
        public int Id { get; set; }

        public string BuyerId { get; set; } = null!;

        public List<BasketItemViewModel> Items { get; set; } = [];

        public decimal TotalItems => Items.Sum(x => x.Quantity);

        public decimal TotalPrice  => Items.Sum(x => x.TotalPrice);
    }
}

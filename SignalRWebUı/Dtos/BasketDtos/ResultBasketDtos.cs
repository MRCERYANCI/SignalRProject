namespace SignalRWebUı.Dtos.BasketDtos
{
    public class ResultBasketDtos
    {
        public int BasketId { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductName { get; set; }
    }
}

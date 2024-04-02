namespace SignalR.EntityLayer.Entities
{
    public class Discount //Günün İndirimleri
    {
        public int DiscountID { get; set; }
        public string DiscountTitle { get; set; }
        public string DiscountAmount { get; set; } //Miktar
        public string DiscountDescription { get; set; } //Miktar
        public string DiscountImageUrl { get; set; } //Miktar
        public bool DiscountStatus { get; set; } //Miktar
    }
}

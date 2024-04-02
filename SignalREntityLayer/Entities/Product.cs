using SignalREntityLayer.Entities;

namespace SignalR.EntityLayer.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public bool ProductStatus { get; set; }


        //Category ve Product Arası İlişki
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //Product ve Order Details Arası İlişki
        public ICollection<OrderDetail> OrdeDetails { get; set; }


        //Product ve Basket Arası İlişki
        public ICollection<Basket> Baskets { get; set; }
    }
}

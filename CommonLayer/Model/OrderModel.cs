using Microsoft.VisualBasic;

namespace BookStore.CommonLayer.Model
{
    public class OrderModel
    {
        public long OrderId { get; set; }
        public string OrderDate { get; set; }
        public long CartId { get; set; }
    }
}

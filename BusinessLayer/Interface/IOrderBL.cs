namespace BookStore.BusinessLayer.Interface
{
    public interface IOrderBL
    {
        public bool AddOrder(long CartId);
        public bool DeleteOrder(long OrderId);
    }
}

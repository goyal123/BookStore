using BookStore.CommonLayer.Model;
using System.Collections.Generic;

namespace BookStore.BusinessLayer.Interface
{
    public interface IOrderBL
    {
        public bool AddOrder(string email, long CartId);
        public bool DeleteOrder(long OrderId);
        public List<OrderModel> GetAllOrders(string email);
    }
}

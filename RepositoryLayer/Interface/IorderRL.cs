using BookStore.CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IorderRL
    {
        public bool AddOrder(string email, long CartId);
        public bool DeleteOrder(long OrderId);
        public List<OrderModel> GetAllOrders(string email);
    }
}

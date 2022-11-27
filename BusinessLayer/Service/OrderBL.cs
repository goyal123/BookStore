using BookStore.BusinessLayer.Interface;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;

namespace BookStore.BusinessLayer.Service
{
    public class OrderBL:IOrderBL
    {
        private readonly IorderRL orderRL;
        public OrderBL(IorderRL orderRL)
        {
            this.orderRL = orderRL;
        }

        public bool AddOrder(long CartId)
        {
            try
            {
                return orderRL.AddOrder(CartId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteOrder(long OrderId)
        {
            try
            {
                return orderRL.DeleteOrder(OrderId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

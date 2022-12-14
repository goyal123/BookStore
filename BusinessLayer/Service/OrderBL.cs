using BookStore.BusinessLayer.Interface;
using BookStore.CommonLayer.Model;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;

namespace BookStore.BusinessLayer.Service
{
    public class OrderBL:IOrderBL
    {
        private readonly IorderRL orderRL;
        public OrderBL(IorderRL orderRL)
        {
            this.orderRL = orderRL;
        }

        public bool AddOrder(string email, long CartId)
        {
            try
            {
                return orderRL.AddOrder(email,CartId);
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

        public List<OrderModel> GetAllOrders(string email)
        {
            try
            {
                return orderRL.GetAllOrders(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

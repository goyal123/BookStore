using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class CartBL:ICartBL
    {
        private readonly ICartRL cartRL;

        public CartBL(ICartRL cartRL)
        {
            this.cartRL = cartRL;
        }
        public Cartmodel AddCart(string email, Cartmodel cartmodel)
        {
            try
            {
                return cartRL.AddCart(email, cartmodel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Cartmodel UpdateCart(long CartId, Cartmodel cartmodel)
        {
            try
            {
                return cartRL.UpdateCart(CartId, cartmodel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteCart(long CartId)
        {
            try
            {
                return cartRL.DeleteCart(CartId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        public List<Cartmodel> GetCart(string email)
        {
            try
            {
                return cartRL.GetCart(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}

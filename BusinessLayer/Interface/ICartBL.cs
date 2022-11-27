using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ICartBL
    {
        public Cartmodel AddCart(string email, Cartmodel cartmodel);
        public Cartmodel UpdateCart(long CartId, Cartmodel cartmodel);
        public bool DeleteCart(long CartId);
    }
}

using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICartRL
    {
        public Cartmodel AddCart(string email, Cartmodel cartmodel);
        public Cartmodel UpdateCart(long CartId, Cartmodel cartmodel);
        public bool DeleteCart(long CartId);
        public List<Cartmodel> GetCart(string email);
    }
}

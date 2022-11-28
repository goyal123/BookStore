using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IWishlistRL
    {
        public bool AddItem(string email, long BookId);
        public bool DeleteItem(string email, long BookId);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IorderRL
    {
        public bool AddOrder(long CartId);
        public bool DeleteOrder(long OrderId);
    }
}

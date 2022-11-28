using BookStore.CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IAddressRL
    {
        public AddressModel CreateAddress(string email, long Address_Type,AddressModel addressModel);
        public AddressModel UpdateAddress(string email, long Address_Type, AddressModel addressModel);
        public AddressModel GetAddress(string email, int Address_Type);

    }
}

using BookStore.BusinessLayer.Interface;
using BookStore.CommonLayer.Model;
using RepositoryLayer.Interface;
using System;

namespace BookStore.BusinessLayer.Service
{
    public class AddressBL:IAddressBL
    {
        private readonly IAddressRL addressRL;
        public AddressBL(IAddressRL addressRL)
        {
            this.addressRL = addressRL;
        }

        public AddressModel CreateAddress(string email, long Address_Type, AddressModel addressModel)
        {
            try
            {
                return addressRL.CreateAddress(email, Address_Type,addressModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public AddressModel UpdateAddress(string email, long Address_Type, AddressModel addressModel)
        {
            try
            {
                return addressRL.UpdateAddress(email, Address_Type,addressModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public AddressModel GetAddress(string email,int Address_Type)
        {
            try
            {
                return addressRL.GetAddress(email, Address_Type);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}

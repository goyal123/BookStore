using BookStore.CommonLayer.Model;

namespace BookStore.BusinessLayer.Interface
{
    public interface IAddressBL
    {
        public AddressModel CreateAddress(string email, long Address_Type, AddressModel addressModel);
        public AddressModel UpdateAddress(string email, long Address_Type, AddressModel addressModel);
        public AddressModel GetAddress(string email, int Address_Type);
    }
}

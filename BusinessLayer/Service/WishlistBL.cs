using BookStore.BusinessLayer.Interface;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;

namespace BookStore.BusinessLayer.Service
{
    public class WishlistBL:IWishlistBL
    {
        private readonly IWishlistRL wishlistRL;
        public WishlistBL(IWishlistRL wishlistRL)
        {
            this.wishlistRL = wishlistRL;
        }

        public bool AddItem(string email, long BookId)
        {
            try
            {
                return wishlistRL.AddItem(email, BookId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public bool DeleteItem(string email, long WishlistId)
        {
            try
            {
                return wishlistRL.DeleteItem(email, WishlistId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}

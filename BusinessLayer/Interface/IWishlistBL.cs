namespace BookStore.BusinessLayer.Interface
{
    public interface IWishlistBL
    {
        public bool AddItem(string email, long BookId);
        public bool DeleteItem(string email, long BookId);
    }
}

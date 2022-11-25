using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class BookBL:IBookBL
    {
        private readonly IBookRL bookRL;
        public BookBL(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }

        public Book AddBook(Book bookmodel)
        {
            try
            {
                return bookRL.AddBook(bookmodel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Book UpdateBook(int BookId, Book bookmodel)
        {
            try
            {
                return bookRL.UpdateBook(BookId,bookmodel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Book> GetAllBooks()
        {
            try
            {
                return bookRL.GetAllBooks();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteBook(int BookId)
        {
            try
            {
                return bookRL.DeleteBook(BookId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

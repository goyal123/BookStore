using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IBookBL
    {
        public Book AddBook(Book bookmodel);
        public Book UpdateBook(int BookId, Book bookmodel);

        public List<Book> GetAllBooks();
        public bool DeleteBook(int BookId);
    }
}

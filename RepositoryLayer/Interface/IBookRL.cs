using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IBookRL
    {
        public Book AddBook(Book bookmodel);
        public Book UpdateBook(int BookId, Book bookmodel);
        public List<Book> GetAllBooks();
        public bool DeleteBook(int BookId);
    }
}

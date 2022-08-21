using BookStore_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return GetBookData();
        }

        public BookModel GetBookById(int id)
        {
            return GetBookData().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title, string author)
        {
            return GetBookData().Where(x => x.Title == title && x.Author == author).ToList();
        }

        private List<BookModel> GetBookData()
        {
            return new List<BookModel>()
            {
                new BookModel() { Id = 1, Title="MVC Core", Author="Vikas" },
                new BookModel() { Id = 2, Title="Java", Author="ABC" },
                new BookModel() { Id = 3, Title="C Sharp", Author="XYZ" },
                new BookModel() { Id = 4, Title="Web Api", Author="RST" },
                new BookModel() { Id = 5, Title="SignalR", Author="PQR" }
            };
        }
    }
}

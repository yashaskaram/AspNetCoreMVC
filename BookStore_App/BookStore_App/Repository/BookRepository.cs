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
            return GetBookData().Where(x => x.Title == title || x.Author == author).ToList();
        }

        private List<BookModel> GetBookData()
        {
            return new List<BookModel>()
            {
                new BookModel() { Id = 1, Title="MVC Core", Author="Vikas", Description="This is description for MVC book", Category="Programming", Language="English", TotalPages="310" },
                new BookModel() { Id = 2, Title="Java", Author="Spiderman", Description="This is description for Java book", Category="Programming", Language="English", TotalPages="400" },
                new BookModel() { Id = 3, Title="C Sharp", Author="Avika", Description="This is description for C# book", Category="Programming", Language="English", TotalPages="130" },
                new BookModel() { Id = 4, Title="Web Api", Author="Vivaan", Description="This is description for WebApi book", Category="RESTful", Language="English", TotalPages="800" },
                new BookModel() { Id = 5, Title="SignalR", Author="Flash", Description="This is description for SignalR book", Category="Framework", Language="English", TotalPages="620" }
            };
        }
    }
}

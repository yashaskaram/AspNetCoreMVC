using BookStore_App.Data;
using BookStore_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App.Repository
{
    public class BookRepository
    {
        public readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Title = model.Title,
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow
            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }
        public async  Task<List<BookModel>> GetAllBooks()
        {
            List<BookModel> books = new List<BookModel>();

            var allBooks = await _context.Books.ToListAsync();
            if(allBooks?.Any() == true)
            {
                foreach (var book in allBooks)
                {
                    books.Add(new BookModel()
                    {
                        Id = book.Id,
                        Author = book.Author,
                        Title = book.Title,
                        Description = book.Description,
                        TotalPages = book.TotalPages,
                        Language = book.Language,
                        Category = book.Category
                    });
                }
            }
            
            return books;
        }

        public async Task<BookModel> GetBookById(int id)
        {
         
            var book = await _context.Books.FindAsync(id);
            
            if(book != null)
            {
                var bookDetail = new BookModel()
                {
                    Id = book.Id,
                    Author = book.Author,
                    Title = book.Title,
                    Description = book.Description,
                    TotalPages = book.TotalPages,
                    Language = book.Language,
                    Category = book.Category
                };
                return bookDetail;
            }
            return null;    
        }

        public List<BookModel> SearchBook(string title, string author)
        {
            return GetBookData().Where(x => x.Title == title || x.Author == author).ToList();
        }

        private List<BookModel> GetBookData()
        {
            return new List<BookModel>()
            {
                new BookModel() { Id = 1, Title="MVC Core", Author="Vikas", Description="This is description for MVC book", Category="Programming", Language="English", TotalPages=310 },
                new BookModel() { Id = 2, Title="Java", Author="Spiderman", Description="This is description for Java book", Category="Programming", Language="English", TotalPages=400 },
                new BookModel() { Id = 3, Title="C Sharp", Author="Avika", Description="This is description for C# book", Category="Programming", Language="English", TotalPages=130 },
                new BookModel() { Id = 4, Title="Web Api", Author="Vivaan", Description="This is description for WebApi book", Category="RESTful", Language="English", TotalPages=800 },
                new BookModel() { Id = 5, Title="SignalR", Author="Flash", Description="This is description for SignalR book", Category="Framework", Language="English", TotalPages=620 }
            };
        }
    }
}

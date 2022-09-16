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
                LanguageId = model.LanguageId,
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
                        LanguageId = book.LanguageId,                      
                        //Language = book.Language.Name,
                        Category = book.Category
                    });
                }
            }
            
            return books;
        }

        public async Task<BookModel> GetBookById(int id)
        {

            return await _context.Books.Where(x => x.Id == id)
                 .Select(book => new BookModel()
                 {
                     Id = book.Id,
                     Author = book.Author,
                     Title = book.Title,
                     Description = book.Description,
                     TotalPages = book.TotalPages,
                     LanguageId = book.LanguageId,
                     Language = book.Language.Name,
                     Category = book.Category

                 }).FirstOrDefaultAsync();
 
        }

        public List<BookModel> SearchBook(string title, string author)
        {
            return null;
        }

        
    }
}

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
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverPhotoUrl,
                BookPdfUrl = model.BookPdfUrl
            };

            newBook.bookGallery = new List<BookGallery>();

            foreach (var file in model.Gallery)
            {
                newBook.bookGallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    Url = file.Url
                });
            }
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }
        public async  Task<List<BookModel>> GetAllBooks()
        {

            return await _context.Books.Select(book => new BookModel()
            {
                Id = book.Id,
                Author = book.Author,
                Title = book.Title,
                Description = book.Description,
                TotalPages = book.TotalPages,
                LanguageId = book.LanguageId,
                Language = book.Language.Name,
                Category = book.Category,
                CoverPhotoUrl = book.CoverImageUrl
            }).ToListAsync();
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
                     Category = book.Category,
                     CoverPhotoUrl = book.CoverImageUrl,
                     Gallery = book.bookGallery.Select(b => new GalleryModel()
                     {
                         Id = b.Id,
                         Name = b.Name,
                         Url = b.Url
                     }).ToList(),
                     BookPdfUrl = book.BookPdfUrl
                 }).FirstOrDefaultAsync();
 
        }

        public List<BookModel> SearchBook(string title, string author)
        {
            return null;
        }

        
    }
}

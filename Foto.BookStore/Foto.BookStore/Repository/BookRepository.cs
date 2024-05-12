
using Foto.BookStore.data;
using Foto.BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Foto.BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreDbContext _dbContext = null;
        public BookRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                Title = model.Title,
                Description = model.Description,
                Category = model.Category,
                Language = model.Language,
                TotalPages = model.TotalPages,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
            };
            await _dbContext.Books.AddAsync(newBook);
            await _dbContext.SaveChangesAsync();
            return newBook.Id;

        }

        #region add New Languages
        public async Task<int> AddNewLanguages(LanguageModel model)
        {
            var newLanguages = new LanguageModel()
            {

                LanguageValue = model.LanguageValue,
                LanguageName = model.LanguageName
            };
            await _dbContext.Languages.AddAsync(newLanguages);
            await _dbContext.SaveChangesAsync();
            return newLanguages.Id;

        }
        #endregion

        //Get All Languages

        //public async Task<List<LanguageModel>> GetAllLanguages()
        //{
        //    var languages = new List<LanguageModel>();
        //    var allLanguages = await _dbContext.Languages.ToListAsync();
        //    if (allLanguages.Any() == true)
        //    {
        //        foreach (var language in allLanguages)
        //        {
        //            languages.Add(new LanguageModel
        //            { 
        //                LanguageName=language.LanguageName
        //            });
        //        }
        //    }
        //    return languages;
        //}
        public List<LanguageModel> GetAllLanguages()
        {
            var allLanguages = _dbContext.Languages.ToList();
            var languages = new List<LanguageModel>();

            if (allLanguages.Any() == true)
            {
                foreach (var item in allLanguages)
                {
                    languages.Add(new LanguageModel() { LanguageValue=item.LanguageValue, LanguageName = item.LanguageName });
                };
            }
            return languages;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allBooks = await _dbContext.Books.ToListAsync();
            if (allBooks.Any() == true)
            {
                foreach (var book in allBooks)
                {
                    books.Add(new BookModel
                    {
                        Id = book.Id,
                        Author = book.Author,
                        Title = book.Title,
                        Description = book.Description,
                        Category = book.Category,
                        Language = book.Language,
                        TotalPages = book.TotalPages
                    });
                }
            }
            return books;
        }
        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book != null)
            {
                var bookDetails = new BookModel()
                {
                    Id = book.Id,
                    Author = book.Author,
                    Title = book.Title,
                    Description = book.Description,
                    Category = book.Category,
                    Language = book.Language,
                    TotalPages = book.TotalPages
                };
                return bookDetails;
            }
            return null;
        }

        #region Get Language Details
        public async Task<LanguageModel> GetlanguageById(int id)
        {
            var language = await _dbContext.Languages.FindAsync(id);
            if (language != null)
            {
                var languageDetails = new LanguageModel()
                {
                    Id = language.Id,
                    LanguageValue = language.LanguageValue,
                    LanguageName = language.LanguageName
                };
                return languageDetails;
            }
            return null;
        }
        #endregion


        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }


        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
         {
             new BookModel(){Id=1,Title="MVC",Author="Ajay",Description= "This is MVC description",Category="Programming",Language="English",TotalPages=167},
             new BookModel(){Id=2,Title="Sql",Author="Ajay",Description= "This is Sql description",Category="Programming",Language="English",TotalPages=1671},
             new BookModel(){Id=3,Title="Bootstrap",Author="Param",Description= "This is Bootstrap description",Category="Programming",Language="English",TotalPages=1672},
             new BookModel(){Id=4,Title="HTML",Author="Vinay",Description= "This is HTML description",Category="Programming",Language="English",TotalPages=1673},
             new BookModel(){Id=5,Title="Jquery",Author="Param",Description= "This is Jquery description",Category="Programming",Language="English",TotalPages=1674},

             //testing dummy data 
              new BookModel(){Id=6,Title="MVC",Author="Ajay",Description= "This is MVC description",Category="Programming",Language="English",TotalPages=167},
             new BookModel(){Id=7,Title="Sql",Author="Ajay",Description= "This is Sql description",Category="Programming",Language="English",TotalPages=1671},
             new BookModel(){Id=8,Title="Bootstrap",Author="Param",Description= "This is Bootstrap description",Category="Programming",Language="English",TotalPages=1672},
             new BookModel(){Id=9,Title="HTML",Author="Vinay",Description= "This is HTML description",Category="Programming",Language="English",TotalPages=1673},
             new BookModel(){Id=10,Title="Jquery",Author="Param",Description= "This is Jquery description",Category="Programming",Language="English",TotalPages=1674},
              new BookModel(){Id=11,Title="MVC",Author="Ajay",Description= "This is MVC description",Category="Programming",Language="English",TotalPages=167},
             new BookModel(){Id=12,Title="Sql",Author="Ajay",Description= "This is Sql description",Category="Programming",Language="English",TotalPages=1671},
             new BookModel(){Id=13,Title="Bootstrap",Author="Param",Description= "This is Bootstrap description",Category="Programming",Language="English",TotalPages=1672},
             new BookModel(){Id=14,Title="HTML",Author="Vinay",Description= "This is HTML description",Category="Programming",Language="English",TotalPages=1673},
             new BookModel(){Id=15,Title="Jquery",Author="Param",Description= "This is Jquery description",Category="Programming",Language="English",TotalPages=1674},
              new BookModel(){Id=16,Title="MVC",Author="Ajay",Description= "This is MVC description",Category="Programming",Language="English",TotalPages=167},
             new BookModel(){Id=17,Title="Sql",Author="Ajay",Description= "This is Sql description",Category="Programming",Language="English",TotalPages=1671},
             new BookModel(){Id=18,Title="Bootstrap",Author="Param",Description= "This is Bootstrap description",Category="Programming",Language="English",TotalPages=1672},
             new BookModel(){Id=19,Title="HTML",Author="Vinay",Description= "This is HTML description",Category="Programming",Language="English",TotalPages=1673},
             new BookModel(){Id=20,Title="Jquery",Author="Param",Description= "This is Jquery description",Category="Programming",Language="English",TotalPages=1674},

              new BookModel(){Id=21,Title="New Test Book 1",Author="Test 1",Description= "This is Test 1 description",Category="Test Cat 1",Language="English",TotalPages=1674},

               new BookModel(){Id=22,Title="New Test Book 2",Author="Test 2",Description= "This is Test 2 description",Category="test cat 2",Language="English",TotalPages=1674},
         };
        }


        //Test for custom page list
    }
}

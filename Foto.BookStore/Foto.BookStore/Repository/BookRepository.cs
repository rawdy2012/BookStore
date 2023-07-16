using Foto.BookStore.Models;

namespace Foto.BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookById(int id) 
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }
        public  List<BookModel> SearchBook(string title,string authorName) 
        {
        return DataSource().Where(x=>x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }
        private List<BookModel> DataSource() 
        { 
         return new List<BookModel> ()
         { 
             new BookModel(){Id=1,Title="MVC",Author="Ajay"},
             new BookModel(){Id=2,Title="Sql",Author="Ajay"},
             new BookModel(){Id=3,Title="Bootstrap",Author="Param"},
             new BookModel(){Id=4,Title="HTML",Author="Vinay"},
             new BookModel(){Id=5,Title="Jquery",Author="Param"},
         };    
        }
    }
}

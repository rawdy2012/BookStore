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
             new BookModel(){Id=1,Title="MVC",Author="Ajay",Description= "This is MVC description",Category="Programming",Language="English",TotalPages=167},
             new BookModel(){Id=2,Title="Sql",Author="Ajay",Description= "This is Sql description",Category="Programming",Language="English",TotalPages=1671},
             new BookModel(){Id=3,Title="Bootstrap",Author="Param",Description= "This is Bootstrap description",Category="Programming",Language="English",TotalPages=1672},
             new BookModel(){Id=4,Title="HTML",Author="Vinay",Description= "This is HTML description",Category="Programming",Language="English",TotalPages=1673},
             new BookModel(){Id=5,Title="Jquery",Author="Param",Description= "This is Jquery description",Category="Programming",Language="English",TotalPages=1674},
         };    
        }
    }
}

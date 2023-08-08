using Foto.BookStore.Models;
using Microsoft.AspNetCore.Mvc;

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

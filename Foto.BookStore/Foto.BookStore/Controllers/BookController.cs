using Foto.BookStore.Models;
using Foto.BookStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Foto.BookStore.Controllers
{
   
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository=null;
        public BookController()
        {
            _bookRepository= new BookRepository();  
        }
        public List<BookModel> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();  
        }
        public BookModel GetBook(int id)
        {
            return _bookRepository.GetBookById(id);
        }
        public List<BookModel> SearchBooks(string bookName,string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName); /*$"Book with name = {bookName} & author = {authorName}";*/
        }
    }
}

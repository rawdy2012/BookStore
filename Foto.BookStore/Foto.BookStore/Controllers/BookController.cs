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
        public ViewResult GetAllBooks()
        {
            var data = _bookRepository.GetAllBooks();  
            return View(data);  
        }
        public IActionResult getallbookslst(int pg=1)
        {
           List<BookModel> _list = _bookRepository.GetAllBooks(); 
            const int pageSize = 4;
            if (pg < 1)
            {
                pg = 1;
            }
            int recordCount = _list.Count();
            var pager = new Pager(recordCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;//if page no is 2 & page size is 10 then recSkip=(2-1)*10 
            var data = _list.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            return View(data); 
        }
        public ViewResult GetBook(int id)
        {

            var data = _bookRepository.GetBookById(id);
            return View(data);
        }
        public List<BookModel> SearchBooks(string bookName,string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName); /*$"Book with name = {bookName} & author = {authorName}";*/
        }
    }
}

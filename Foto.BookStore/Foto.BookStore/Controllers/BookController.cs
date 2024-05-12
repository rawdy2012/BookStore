

using Foto.BookStore.data;
using Foto.BookStore.Models;
using Foto.BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using System.Configuration;
using System.Data;
using System.Net;

namespace Foto.BookStore.Controllers
{

    public class BookController : Controller
    {

        private readonly BookRepository _bookRepository = null;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            //Configuration = _configuration;
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        //public IActionResult getallbookslst(int pg = 1)
        //{

        //    SqlConnection conn = new SqlConnection();
        //    string connectionString = Configuration.GetConnectionString("BSConn");
        //    conn.ConnectionString = connectionString;
        //    if (conn.State == ConnectionState.Closed)
        //        conn.Open();
        //    var aa = dbcontext.ClsUnitLst.FromSqlRaw("GetUnitList").ToList();

        //    List<SelectListItem> list = new List<SelectListItem>(); 
        //    foreach (var item in aa)
        //    {
        //        list = new()
        //        {
        //        new SelectListItem { Value = Convert.ToString(item.Id), Text = item.UName }
        //        };
        //        }
        //    ViewBag.list = list;





        //    List<SelectListItem> units = new()
        //    {
        //        new SelectListItem { Value = "1", Text = "Latur" },
        //        new SelectListItem { Value = "2", Text = "Solapur" },
        //        new SelectListItem { Value = "3", Text = "Nanded" },
        //        new SelectListItem { Value = "4", Text = "Nashik" },
        //        new SelectListItem { Value = "5", Text = "Nagpur" },
        //        new SelectListItem { Value = "6", Text = "Kolhapur" },
        //        new SelectListItem { Value = "7", Text = "Pune" },
        //        new SelectListItem { Value = "8", Text = "Mumbai" },
        //        new SelectListItem { Value = "9", Text = "Delhi" },
        //        new SelectListItem { Value = "10", Text = "Noida" }
        //    };

        //    SqlDataAdapter adp = new SqlDataAdapter("select Id,UName from Units", conn);
        //    DataTable dt = new DataTable();
        //    var dafillData = adp.Fill(dt);






        //    // ViewBag.DataSource = dafillData;


        //    ViewBag.Units = units;


        //    List<BookModel> _list = _bookRepository.GetAllBooks();

        //    const int pageSize = 4;
        //    if (pg < 1)
        //    {
        //        pg = 1;
        //    }
        //    int recordCount = _list.Count();
        //    var pager = new Pager(recordCount, pg, pageSize);
        //    int recSkip = (pg - 1) * pageSize;//if page no is 2 & page size is 10 then recSkip=(2-1)*10 
        //    var data = _list.Skip(recSkip).Take(pager.PageSize).ToList();
        //    this.ViewBag.Pager = pager;
        //    return View(data);
        //}

        [Route("book-details/{id}", Name = "bookDetailsRoute")]
        public async Task<ViewResult> GetBook(int id)
        {

            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }

        #region Get Language Details
        [Route("language-details/{id}", Name = "languageDetailsRoute")]
        public async Task<ViewResult> GetLanguage(int id)
        {

            var data = await _bookRepository.GetlanguageById(id);
            return View(data);
        }
        #endregion
        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName); /*$"Book with name = {bookName} & author = {authorName}";*/
        }

        private List<LanguageModel> GetLanguagesHardCodeValues()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel(){LanguageValue="h1",LanguageName="Hindi"},
                new LanguageModel(){LanguageValue="h2",LanguageName="English"},
                new LanguageModel(){LanguageValue="h3",LanguageName="Dutch"},
                new LanguageModel(){LanguageValue="h4",LanguageName="Sanskrit"}
            };
        }
        public ViewResult AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            #region different types of dropdown
            ViewBag.AllLanguages = new SelectList(_bookRepository.GetAllLanguages(), "LanguageValue", "LanguageName"); // Using Select List

            //ViewBag.AllLanguages = _bookRepository.GetAllLanguages().Select(x => new SelectListItem() // Using Select List Item
            //{
            //    Value = x.LanguageValue,
            //    Text = x.LanguageName
            //}).ToList();

          

            //var group1 = new SelectListGroup() { Name = "group1" };
            //var group2 = new SelectListGroup() { Name = "group2" };
            //var group3 = new SelectListGroup() { Name = "group3" };
            //ViewBag.AllLanguages = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Text="Hindi",Value="1",Group=group1},
            //    new SelectListItem(){Text="English",Value="2",Group=group1},
            //    new SelectListItem(){Text="Tamil",Value="3",Group=group2},
            //    new SelectListItem(){Text="Telgu",Value="4",Group=group1},
            //    new SelectListItem(){Text="Malyalam",Value="5",Group=group2},
            //    new SelectListItem(){Text="Sanskrit",Value="6",Group=group2},
            //    new SelectListItem(){Text="Dutch",Value="7",Group=group3},
            //    new SelectListItem(){Text="German",Value="8",Group=group1},
            //    new SelectListItem(){Text="French",Value="9",Group=group3},
            //    new SelectListItem(){Text="Japanies",Value="10",Group=group1},
            //    };
            #endregion Group in dropdown

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
            ViewBag.AllLanguages = new SelectList(_bookRepository.GetAllLanguages(), "LanguageValue", "LanguageName");
            ViewBag.IsSuccess = false;
            ViewBag.BookId = 0;

            return View();
        }

        #region Add New Languages
        public ViewResult AddNewLanguages(bool isSuccess = false, int languageId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.LanguageId = languageId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewLanguages(LanguageModel languageModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewLanguages(languageModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewLanguages), new { isSuccess = true, languageId = id });
                }
            }
            ViewBag.IsSuccess = false;
            ViewBag.languageId = 0;

            return View();
        }
        #endregion
    }
}

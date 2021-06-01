using CorePRactice1.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePRactice1.Models;
namespace CorePRactice1.Controllers
{
    public class BookController : Controller
    {
        
        private readonly BookRepository _bookrepository = null;
        public BookController()
        {
            _bookrepository = new BookRepository();
        
        }
        [Route("Book/GetAllBooks")]
        public async Task<ViewResult> GetAllBooks()
        {

                var data=await _bookrepository.getAllbooks();
            return View(data);
        } 
        public async Task<ViewResult> GetBooksById(int id)
        {
              var data= await _bookrepository.getBooksByid(id);
            return View(data);
        }
        public List<bookModel> SearchBooks(string title,string AuthorName)
        {

            return _bookrepository.SearchBook(title, AuthorName);
        }
        public ViewResult AddNewBook(bool isSuccess=false,int Bookid=0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.Id = Bookid;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(bookModel newbook)
        {
            if (ModelState.IsValid) {
                int id = await _bookrepository.AddnewBook(newbook);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, Bookid = id });
                }

            }
            return View();
        }
    }
}

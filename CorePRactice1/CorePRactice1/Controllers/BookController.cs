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
        public List<bookModel> GetAllBooks()
        {

            return _bookrepository.getAllbooks();
        } 
        public bookModel GetBooksById(int id)
        {

            return _bookrepository.getBooksByid(id);
        }
        public List<bookModel> SearchBooks(string title,string AuthorName)
        {

            return _bookrepository.SearchBook(title, AuthorName);
        }
    }
}

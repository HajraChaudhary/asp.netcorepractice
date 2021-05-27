using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePRactice1.Models;
namespace CorePRactice1.Repository
{
    public class BookRepository
    {

        public List<bookModel> getAllbooks()
        {

           return Datasource();
        }
        public bookModel getBooksByid(int id)
        {
            return Datasource().Where(x=>x.id==id).FirstOrDefault();


        }
        public List<bookModel> SearchBook(string title,string authorName)
        {
            return Datasource().Where(x=>x.Name.Contains(title)&& x.Author.Contains(authorName)).ToList();


        }
        private List<bookModel> Datasource()
        {
            return new List<bookModel>()
            {
                new bookModel(){id=1,Name="java",Author="abc" },
                new bookModel(){id=2,Name="C#",Author="abc2" },
                new bookModel(){id=3,Name="Python",Author="abc3" },
                new bookModel(){id=5,Name="Javascript",Author="abc5" },
                new bookModel(){id=4,Name="C++",Author="abc4" },

            };
        
        }

    }
}

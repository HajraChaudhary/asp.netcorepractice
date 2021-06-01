using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePRactice1.Data;
using CorePRactice1.Models;
using Microsoft.EntityFrameworkCore;

namespace CorePRactice1.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext db = null;
        public BookRepository()
        {
            db = new BookStoreContext();
        }
        public async Task<int> AddnewBook(bookModel bm)
        {
            var newbook = new Books();
            newbook.Name = bm.Name;
            newbook.Author = bm.Author;
            newbook.Description = bm.Description;
            newbook.CreatedOn = DateTime.UtcNow;
            newbook.UpdatedOn = DateTime.UtcNow;
            await db.Books.AddAsync(newbook);
           await db.SaveChangesAsync();
            return newbook.id;
        }
        public async Task<List<bookModel>> getAllbooks()
        {
            var bm = new List<bookModel>();
                var data=await db.Books.ToListAsync();
            if (data.Any() == true)
            {
                foreach (var item in data)
                {
                    bm.Add(new bookModel()
                    {
                        Name=item.Name,
                        Author=item.Author,
                        Description=item.Description,
                        id=item.id
                    });


                }
            }
            return bm;

        }
        public async Task<bookModel> getBooksByid(int id)
        {
            var bm = new bookModel();

            var data = await db.Books.Where(x => x.id == id).FirstOrDefaultAsync();

            if (data!=null)
            {

                bm.Name = data.Name;
                bm.Author = data.Author;
                bm.Description = data.Description;
                
            }
            return bm;


        }
        public List<bookModel> SearchBook(string title,string authorName)
        {
            return Datasource().Where(x=>x.Name.Contains(title)&& x.Author.Contains(authorName)).ToList();


        }
        private List<bookModel> Datasource()
        {
            return new List<bookModel>()
            {
                new bookModel(){id=1,Name="java",Author="abc",Description="This is description for java book" },
                new bookModel(){id=2,Name="C#",Author="abc",Description="This is description for C# book" },
                new bookModel(){id=3,Name="Python",Author="abc",Description="This is description for Python book" },
                new bookModel(){id=5,Name="Javascript",Author="abc",Description="This is description for Javascript book" },
                new bookModel(){id=4,Name="C++",Author="abc" ,Description="This is description for C++ book"},

            };
        
        }

    }
}

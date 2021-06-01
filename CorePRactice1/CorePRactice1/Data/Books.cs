using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePRactice1.Data
{
    public class Books
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}

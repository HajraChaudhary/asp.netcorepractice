using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CorePRactice1.Models
{
    public class bookModel
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string  Author { get; set; }
        [Required]
        public string Description { get; set; }

    }
}

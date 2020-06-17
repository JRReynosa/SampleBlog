using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public DateTime SystemChangeDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}

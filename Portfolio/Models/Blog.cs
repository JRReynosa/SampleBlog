using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class Blog
    {
        public int BlogID { get; set; }
        public DateTime SystemChangeDate { get; set; }
        public String Title { get; set; }
        //public String Description { get; set; }
        public String Content { get; set; }
        // Use MarkdownDocument to parse
        public String Tags { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.ViewModels
{
    public class BlogViewModel
    {
        public int BlogID { get; set; }
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime DateSubmitted { get; set; }
        public String Title { get; set; }
        //public String Description { get; set; }
        public String Content { get; set; }
        // Use MarkdownDocument to parse
        public String Tags { get; set; }
        public ICollection<CommentViewModel> Comments { get; set; }
    }
}

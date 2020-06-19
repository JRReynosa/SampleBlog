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
        public int BlogId { get; set; }
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime DateSubmitted { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public ICollection<CommentViewModel> Comments { get; set; }
    }
}

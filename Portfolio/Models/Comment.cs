using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int BlogId { get; set; }
        public DateTime DateSubmitted { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CommentText { get; set; }
        public int Likes { get; set; }
    }
}

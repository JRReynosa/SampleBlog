using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Data;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Services
{
    public class BlogService
    {
        public List<BlogViewModel> RetrieveBlogs()
        {
            var listOfAudits = new List<BlogViewModel>();
            var query = new PortfolioContext().Blog.ToList();
            listOfAudits = query.Select(x => new BlogViewModel
            {
                BlogID = x.BlogID,
                DateSubmitted = x.SystemChangeDate,
                Title = x.Title,
                Content = x.Content,
                Tags = x.Tags,
                Comments = this.RetrieveComments(x.BlogID)
            }).ToList();
            return listOfAudits;
        }

        public List<CommentViewModel> RetrieveComments(int blogId)
        {
            var listOfComments = new List<CommentViewModel>();
            var query = new PortfolioContext().Comment.ToList();
            listOfComments = query.Where(x => x.BlogID == blogId).Select(x => new CommentViewModel
            {
                CommentId = x.CommentId,
                BlogID = x.BlogID,
                DateSubmitted = x.DateSubmitted,
                Name = x.Name,
                Email = x.Email,
                CommentText = x.CommentText,
                Likes = x.Likes
            }).ToList();
            return listOfComments;
        }
    }
}

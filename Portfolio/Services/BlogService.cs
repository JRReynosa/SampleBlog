using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Services
{
    public class BlogService
    {
        public List<BlogViewModel> RetrieveBlogs()
        {
            var context = new PortfolioContext();
            var listOfBlogs = new List<BlogViewModel>();
            var query = context.Blog.ToList();
            listOfBlogs = query.Select(x => new BlogViewModel
            {
                BlogID = x.BlogID,
                DateSubmitted = x.SystemChangeDate,
                Title = x.Title,
                Content = x.Content,
                Tags = x.Tags,
                Comments = this.RetrieveComments(x.BlogID)
            }).ToList();
            return listOfBlogs;
        }

        public BlogViewModel RetrieveBlogVmById(int? id)
        {
            var listOfVmBlogs = new BlogService().RetrieveBlogs();
            var returnBlog = listOfVmBlogs.FirstOrDefault(x => x.BlogID == id);
            return returnBlog;
        }

        public List<CommentViewModel> RetrieveComments(int blogId)
        {
            var context = new PortfolioContext();
            var listOfComments = new List<CommentViewModel>();
            var query = context.Comment.ToList();
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

        public bool CreateBlog(BlogViewModel blog)
        {
            var context = new PortfolioContext();
            var entryBlog = new Blog
            {
                BlogID = blog.BlogID,
                SystemChangeDate = blog.DateSubmitted,
                Title = blog.Title,
                Content = blog.Content,
                Tags = blog.Tags
            };
            context.Add(entryBlog);
            context.SaveChanges();

            if (new BlogService().RetrieveBlogVmById(blog.BlogID) == null) return false;
            return true;
        }

        public bool EditBlog(int id, BlogViewModel blog)
        {
            var context = new PortfolioContext();

            var entryBlog = new Blog
            {
                BlogID = id,
                Title = blog.Title,
                // Fix this when time comes, I don't think it turns the CommentVM to type Comment
                Comments = (List<Comment>) blog.Comments,
                Tags = blog.Tags,
                SystemChangeDate = blog.DateSubmitted,
                Content = blog.Content
            };

            if (entryBlog == null) return false;
            
            try
            {
                context.Update(entryBlog);
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            context.SaveChanges();
            return true;
        }

        public bool DeleteBlogById(int id)
        {           
            var context = new PortfolioContext();
            var entryBlog = context.Blog.FirstOrDefault(x => x.BlogID == id);

            context.Blog.Remove(entryBlog);

            context.SaveChanges();

            if (new BlogService().RetrieveBlogVmById(id) != null) return false;

            return true;
        }
    }
}

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
            var query = context.Blog.AsNoTracking();
            var listOfBlogs = query.Select(x => new BlogViewModel
            {
                BlogId = x.BlogId,
                DateSubmitted = x.SystemChangeDate,
                Title = x.Title,
                Content = x.Content,
                Tags = x.Tags,
                Comments = new BlogService().RetrieveComments(x.BlogId)
            }).ToList();
            return listOfBlogs;
        }

        public BlogViewModel RetrieveBlogVmById(int? id)
        {
            var listOfVmBlogs = new BlogService().RetrieveBlogs();
            var returnBlog = listOfVmBlogs.FirstOrDefault(x => x.BlogId == id);
            return returnBlog;
        }

        public List<CommentViewModel> RetrieveComments(int blogId)
        {
            var context = new PortfolioContext();
            var query = context.Comment.AsNoTracking();
            var listOfComments = query.Where(x => x.BlogId == blogId).Select(x => new CommentViewModel
            {
                CommentId = x.CommentId,
                BlogId = x.BlogId,
                DateSubmitted = x.DateSubmitted,
                Name = x.Name,
                Email = x.Email,
                CommentText = x.CommentText
            }).ToList();
            return listOfComments;
        }

        public void CreateBlog(BlogViewModel blog)
        {
            var context = new PortfolioContext();
            var entryBlog = new Blog
            {
                BlogId = blog.BlogId,
                DateSubmitted = blog.DateSubmitted,
                SystemChangeDate = DateTime.Today,
                Title = blog.Title,
                Content = blog.Content,
                Tags = blog.Tags
            };
            context.Add(entryBlog);
            context.SaveChanges();
        }

        public void EditBlog(int id, BlogViewModel blog)
        {
            var context = new PortfolioContext();

            var entryBlog = new Blog
            {
                BlogId = id,
                Title = blog.Title,
                Tags = blog.Tags,
                DateSubmitted = blog.DateSubmitted,
                SystemChangeDate = DateTime.Today,
                Content = blog.Content
            };

            context.Update(entryBlog);
            context.SaveChanges();
        }

        public void DeleteBlogById(int commentId)
        {           
            var context = new PortfolioContext();
            var entryBlog = context.Blog.FirstOrDefault(x => x.BlogId == commentId);

            context.Blog.Remove(entryBlog);
            context.SaveChanges();
        }

        #region Comments

        public void CreateComment(CommentViewModel comment)
        {
            var context = new PortfolioContext();
            var entryComment = new Comment()
            {
                BlogId = comment.BlogId,
                DateSubmitted = comment.DateSubmitted,
                Name = comment.Name,
                Email = comment.Email,
                CommentText = comment.CommentText
            };
            context.Add(entryComment);
            context.SaveChanges();
        }

        public void DeleteCommentById(int commentId)
        {
            var context = new PortfolioContext();
            var entryComment = context.Comment.FirstOrDefault(x => x.CommentId == commentId);

            context.Comment.Remove(entryComment);
            context.SaveChanges();
        }

        #endregion
    }
}

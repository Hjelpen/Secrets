using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConfessionMaker2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace ConfessionMaker2._0.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            BloggingContext context = new BloggingContext();
            var posts = context.Post.Include("Comments").ToList();
            var sortedList = posts.OrderByDescending(x => x.UpVotes);

            return View(sortedList);
        }

        public IActionResult Create(Post info)
        {
            using (var context = new BloggingContext())
            {

                Post post = new Post();

                post.PostContent = info.PostContent;

                if (string.IsNullOrEmpty(info.UserName))
                {
                    post.UserName = "Anonymous";
                }
                else
                {
                    post.UserName = info.UserName;
                }
                post.Title = info.Title;
                post.DateTime = DateTime.UtcNow;

                context.Post.Add(post);
                context.SaveChanges();

            }

            return RedirectToAction("Index");
        }

        public IActionResult Post(int id)
        {
            BloggingContext context = new BloggingContext();
            var postInfo = context.Post.Where(x => x.Id == id).Include("Comments");

            Post post = new Post();
            foreach (var item in postInfo)
            {
                post.Comments = item.Comments;
                post.DateTime = item.DateTime;
                post.Id = item.Id;
                post.PostContent = item.PostContent;
                post.Title = item.Title;
                post.UserName = item.UserName;
                post.UpVotes = item.UpVotes;
                var sortedList = post.Comments.OrderByDescending(x => x.UpVotes);
                post.Comments = sortedList.ToList();
            }
         
            return View(post);
        }

        public IActionResult Comment(string postComment, int id)
        {

            BloggingContext context = new BloggingContext();
            Post post = context.Post.Find(id);

            Comment comment = new Comment();
            comment.DateTime = DateTime.UtcNow;
            comment.CommentContent = postComment;
            comment.PostId = id;

            context.Comment.Add(comment);
            context.SaveChanges();

            return RedirectToAction("Post", "Home", new { id });
        }

        public IActionResult UpvotePost(int id)
        {
            BloggingContext context = new BloggingContext();
            Post post = context.Post.Find(id);

            post.UpVotes = post.UpVotes + 1;
            context.Post.Update(post);
            context.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public IActionResult UpVoteComment(int commentId, int postId)
        {
            BloggingContext context = new BloggingContext();
            Comment comment = context.Comment.Find(commentId);

            comment.UpVotes = comment.UpVotes + 1;
            context.Comment.Update(comment);
            context.SaveChanges();

            return RedirectToAction("Post", "Home", new { id = postId });
        }

        public IActionResult Sort()
        {
            BloggingContext context = new BloggingContext();
            var posts = context.Post.Include("Comments").ToList();
            var New = posts.OrderByDescending(x => x.DateTime);

            return View("Index", New);
        }

        public IActionResult SortComment(int id)
        {
            BloggingContext context = new BloggingContext();
            var postInfo = context.Post.Where(x => x.Id == id).Include("Comments");

            Post post = new Post();
            foreach (var item in postInfo)
            {
                post.Comments = item.Comments;
                post.DateTime = item.DateTime;
                post.Id = item.Id;
                post.PostContent = item.PostContent;
                post.Title = item.Title;
                post.UserName = item.UserName;
                post.UpVotes = item.UpVotes;
                var sortedList = post.Comments.OrderByDescending(x => x.DateTime);
                post.Comments = sortedList.ToList();
            }

            return View("Post", post);

        }

        public IActionResult CommentReply(string commentReply, int id)
        {



            return RedirectToAction("Post", "Home", new { id });
        }
    }
}

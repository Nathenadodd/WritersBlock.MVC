using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WritersBlock.Data;
using WritersBlock.Models;

namespace WritersBlock.Services
{
    public class CommentService
    {
        private readonly Guid _userId;
        public CommentService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comments()
                {
                    OwnerId = _userId,
                    CommentID = model.CommentID,
                    PostID = model.PostID,                    
                    CommentText = model.CommentText,
                    CreatedUTC = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comment.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //Helper method for Post
        public IEnumerable<SelectListItem> CreatePostSelectList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts.Select(
                                  e =>
                                    new SelectListItem
                                    {
                                        Text = e.PostText,
                                        Value = e.PostID.ToString(),
                                    }
                                    );

                return query.ToArray();
            }
        
        }
        public IEnumerable<CommentListItem> GetComments()
        {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                            .Comment
                            .Where(e => e.OwnerId == _userId)
                            .Select(
                                e =>
                                    new CommentListItem
                                    {
                                        PostID = e.PostID,
                                        CommentID = e.CommentID,
                                        CommentText = e.CommentText,
                                        CreatedUTC = e.CreatedUTC
                                    }
                            );
                    return query.ToArray();
                }
        }
        public CommentDetail GetCommentById(int id)
        {
           using (var ctx = new ApplicationDbContext())
           {
             var entity =
                ctx
                    .Comment
                    .Single(e => e.CommentID == id && e.OwnerId == _userId);
                return
                    new CommentDetail
                    {
                            CommentID = entity.CommentID,
                            PostID = entity.PostID,
                            //UserID = entity.Id,
                            PostText = entity.Post.PostText,
                            CommentText = entity.CommentText,
                            CreatedUTC = entity.CreatedUTC,
                            ModifiedUTC = entity.ModifiedUTC
                    };
           }
           
        }
        public bool UpdateComment(CommentEdit model, int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comment
                        .Single(e => e.CommentID == id && e.OwnerId == _userId);
               
                //entity.CommentID = model.CommentID;
                //entity.PostID = model.PostID;
                //entity.Id = model.UserID;
                entity.CommentText = model.CommentText;
                entity.CreatedUTC = DateTimeOffset.UtcNow;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteComment(int CommentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comment
                        .Single(e => e.CommentID == CommentId && e.OwnerId == _userId);

                ctx.Comment.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

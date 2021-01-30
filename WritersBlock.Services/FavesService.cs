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
   public class FavesService
   {
        private readonly Guid _userId;
        public FavesService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateFave(FaveCreate model)
        {
             
            var entity =
                new Faves()
                {   OwnerId = _userId,                 
                    FaveID = model.FaveID,
                    PostID = model.PostID,  
                    CommentID = model.CommentID,
                    CreatedUTC = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Faves.Add(entity);
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
                                    });
                return query.ToArray();
            }
        }
        public IEnumerable<FaveListItem> GetFaves()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                         .Faves
                         .Where(e => e.OwnerId == _userId)
                         .Select(
                             e =>
                                 new FaveListItem
                                 {
                                     UserID = e.UserID,
                                     FaveID = e.FaveID,
                                     PostID = e.PostID,
                                     CommentID = e.CommentID,
                                     CreatedUTC = e.CreatedUTC
                                 }

                         );
                return query.ToArray();
            }
        }
        public IEnumerable<SelectListItem> CreateCommentSelectList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comment.Select(
                                    e =>
                                        new SelectListItem
                                        {
                                            Text = e.CommentText,
                                            Value = e.CommentID.ToString(),
                                        }
                                        );
                return query.ToArray();
            }
        }
        public FavesDetail GetFavesById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Faves
                        .Single(e => e.FaveID == id && e.OwnerId == _userId);
                return
                    new FavesDetail
                    {
                        FaveID = entity.FaveID,
                        PostID = entity.PostID,                       
                        UserID = entity.UserID,
                        CommentID = entity.CommentID,
                        CreatedUTC = entity.CreatedUTC,
                        ModifiedUTC = entity.ModifiedUTC
                    };
            }
        }
        public bool UpdateFaves(FavesEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Faves
                        .Single(e => e.FaveID == model.FaveID && e.OwnerId == _userId);
                entity.FaveID = model.FaveID;
                entity.PostID = model.PostID;                
                entity.UserID = model.UserID;
                entity.CommentID = model.CommentID;
                entity.CreatedUTC = DateTimeOffset.UtcNow;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteFave(int Faveid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Faves
                        .Single(e => e.FaveID == Faveid && e.OwnerId == _userId);


                ctx.Faves.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

   }
}

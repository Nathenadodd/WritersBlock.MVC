using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritersBlock.Data;
using WritersBlock.Models;

namespace WritersBlock.Services
{
    public class PostService
    {
        private readonly Guid _userId;
        public PostService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    OwnerId = _userId,
                    //PostID = model.PostID,
                    PostText = model.PostText,
                    CreatedUTC = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Posts
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new PostListItem
                        {
                            PostID = e.PostID,
                            PostText = e.PostText,
                            CreatedUTC = e.CreatedUTC
                        }
                         
                        );
                return query.ToArray();
            }
        }
        public PostDetail GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostID == id && e.OwnerId == _userId);
                return
                    new PostDetail
                    {
                        PostID = entity.PostID,
                        PostText = entity.PostText,
                        //UserID = entity.OwnerId,
                        CreatedUTC = entity.CreatedUTC,
                        ModifiedUTC = entity.ModifiedUTC
                    };
            }
        }
        public bool UpdatePost(PostEdit model, int id)//(PostEdit model, int PostID)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostID == id && e.OwnerId == _userId);

                //entity.PostID = model.PostID;
                //entity.OwnerId = model.UserID;
                entity.PostText = model.PostText;
                entity.CreatedUTC = DateTimeOffset.UtcNow;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
        
            }
        }
        public bool DeletePost(int PostId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostID == PostId && e.OwnerId == _userId);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }


}
    

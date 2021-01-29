using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritersBlock.Data
{
   public class Comments
    {
        [Key]
        public int CommentID { get; set; }
        public Guid OwnerId { get; set; }
        [ForeignKey(nameof(Post))]
        public int PostID { get; set; }
        
        public virtual Post Post { get; set; }
        
        [Required]
        public string CommentText { get; set; }
        
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset ModifiedUTC { get; set; }
    }
}

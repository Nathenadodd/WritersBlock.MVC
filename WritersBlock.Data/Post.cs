using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritersBlock.Data
{
   public class Post
   {
        [Key]
        public int PostID { get; set; }
        public Guid OwnerId { get; set; }
        //[ForeignKey(nameof(ApplicationUser))]
        //public string UserID { get; set; }
        [Required]
        public string PostText { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset ModifiedUTC { get; set; }
      
   }
}

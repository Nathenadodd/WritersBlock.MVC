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
        [ForeignKey("User")]
        public int UserID { get; set; }
        [Required]
        public string PostText { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset ModifiedUTC { get; set; }
    }
}

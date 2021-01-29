using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritersBlock.Models
{
   public class CommentCreate
    {
        //[Required]
        
        public int PostID { get; set; }
        public int CommentID { get; set; }
        [MaxLength(8000)]
        public string CommentText { get; set; }
        //public int PostID { get; set; }
    }
}

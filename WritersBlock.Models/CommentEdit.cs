using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritersBlock.Models
{
   public class CommentEdit
    {
        public int CommentID { get; set; }       
        public int PostID { get; set; }        
        public string UserID { get; set; }       
        public string CommentText { get; set; }
    }
}

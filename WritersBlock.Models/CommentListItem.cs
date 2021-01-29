using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritersBlock.Models
{
   public class CommentListItem
    {
        public int CommentID { get; set; }
        public string CommentText { get; set; }
        public int PostID { get; set; }

        public DateTimeOffset CreatedUTC { get; set; }
    }
}

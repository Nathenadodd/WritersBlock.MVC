using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritersBlock.Models
{
   public class FaveListItem
   {
        public int FaveID { get; set; }
        public int PostID { get; set; }
        public int CommentID { get; set; }
        public string UserID { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }

   }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritersBlock.Models
{
   public class FaveCreate
   {
        

        public int FaveID { get; set; }
        public int PostID { get; set; }
        public int CommentID { get; set; }
        public string UserID { get; set; }

   }
}

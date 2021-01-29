using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritersBlock.Models
{
   public class PostEdit
   {
        public int PostID { get; set; }
        public string PostText { get; set; }
        public string UserID { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }

        public DateTimeOffset ModifiedUTC { get; set; }


    }
}

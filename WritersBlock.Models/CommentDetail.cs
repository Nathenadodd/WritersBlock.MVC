using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritersBlock.Models
{
   public class CommentDetail
    {
        public int CommentID { get; set; }      
        public int PostID { get; set; }    
        public string PostText { get; set; }
        public string UserID { get; set; }        
        public string CommentText { get; set; }
        [Display(Name="Created")]
        public DateTimeOffset CreatedUTC { get; set; }
        [Display(Name="Modified")]
        public DateTimeOffset ModifiedUTC { get; set; }
    }
}

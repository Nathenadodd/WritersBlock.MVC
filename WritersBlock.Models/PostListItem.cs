using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritersBlock.Models
{
    public class PostListItem
    {
        public int PostID { get; set; }
        public string PostText { get; set; }
        [Display(Name="Created")]
        public DateTimeOffset CreatedUTC { get; set; }
    }
}

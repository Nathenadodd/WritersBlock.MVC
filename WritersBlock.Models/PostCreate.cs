using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritersBlock.Models
{
   public class PostCreate
    {
        
        //[MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        //[MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
       // public int PostID { get; set; }
        
        [MaxLength(8000)]
        public string PostText { get; set; }
       
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritersBlock.Data
{
    public class Faves
    {
        [Key]
        public int FaveID { get; set; }
        public Guid OwnerId { get; set; }

        public int PostID { get; set; }
        [ForeignKey(nameof(PostID))]
        public virtual Post Post { get; set; }

        //[ForeignKey(nameof(ApplicationUser))]
        //public string UserID { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset ModifiedUTC { get; set; }
    }
}

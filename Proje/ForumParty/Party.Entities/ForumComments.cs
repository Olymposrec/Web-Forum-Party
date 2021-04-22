using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party.Entities
{
    public class ForumComments : EntityBase
    {
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public virtual ForumPosts PostID { get; set; }
        public virtual ForumUsers UserID { get; set; }
    }
}

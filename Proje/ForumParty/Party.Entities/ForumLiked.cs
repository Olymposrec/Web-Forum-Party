using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party.Entities
{
    public class ForumLiked 
    {
        public int Id { get; set; }
        public ForumPosts PostID { get; set; }
        public ForumUsers UserID { get; set; }
    }
}

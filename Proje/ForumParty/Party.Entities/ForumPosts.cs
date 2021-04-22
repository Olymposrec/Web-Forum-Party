using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party.Entities
{
    public class ForumPosts : EntityBase
    {
       
        
        public string Title { get; set; }
        public string  Description { get; set; }
        public int PrivacyID { get; set; }
        public DateTime UploadDate { get; set; }
        public int  Like{ get; set; }

        public int ImageID { get; set; }
        public int CommunityID { get; set; }
        public int CategoryID { get; set; }

        public virtual ForumUsers UserID { get; set; }
        public virtual ForumCategories Category { get; set; }
        public virtual List<ForumLiked> Likes { get; set; }
        public virtual List<ForumComments> ForumComments { get; set; }
    }
}

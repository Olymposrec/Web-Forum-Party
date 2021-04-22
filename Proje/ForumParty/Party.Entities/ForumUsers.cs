using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party.Entities
{
    public class ForumUsers : EntityBase
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserMail { get; set; }
        public int UsersStateID { get; set; }
        public bool IsActive { get; set; }
        public Guid ActivateGuid { get; set; }
        public bool IsAdmin { get; set; }

        public virtual List<ForumPosts> ForumPosts { get; set; }
        public virtual List<ForumComments> ForumComments { get; set; }
        public virtual List<ForumLiked> Likes { get; set; }
        public virtual ForumUsersAddress AdressID { get; set; }
        //public virtual List<ForumCommunity> ForumCommunity { get; set; }

    }
}

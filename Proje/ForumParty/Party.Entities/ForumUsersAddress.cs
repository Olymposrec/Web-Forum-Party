using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party.Entities
{
    public class ForumUsersAddress : EntityBase
    {
        public string Road { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string ApartmenNo { get; set; }
        public string Floor { get; set; }
        public string District { get; set; }
        public string Province { get; set; }

        public virtual ForumUsers UserID { get; set; }
        
    }
}

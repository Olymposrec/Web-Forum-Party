using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party.Entities
{
    public class ForumAboutUsers: EntityBase
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Phone { get; set; }
        
        public virtual ForumUsers UserID { get; set; }
        public virtual ForumUsersAddress AddressID { get; set; }
    }
}

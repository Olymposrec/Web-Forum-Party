using Party.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party.Business
{
    public class RepositoryBase
    {
        protected static ForumPartyEntities1 db;
        private static object _lockSys=new object();

        protected RepositoryBase()
        {
            CreateContext();
        }
        private static void  CreateContext()
        {   
            if (db == null)
            {
                lock (_lockSys)
                {
                    if (db == null)
                    {
                        db = new ForumPartyEntities1();

                    }

                }
            }
        }

    }
}

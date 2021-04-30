using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeData;

namespace Party.Business
{
    public class Users
    {
        
        public List<Party.DataAccess.Users> Listele()
        {
            Party.DataAccess.ForumPartyEntities1 ent = new DataAccess.ForumPartyEntities1();
            var sonuc = ent.Users.ToList();
            return sonuc;
        }
        public IEnumerable<dynamic> PostListele()
        {
            DataAccess.Posts ent2 = new DataAccess.Posts();
            DataAccess.ForumPartyEntities1 data = new DataAccess.ForumPartyEntities1();
                var result = (from p in data.Posts
                              from c in data.Categories
                              from u in data.Users
                              where c.CategoryID == p.CategoryID && p.UserID == u.UserID
                              select new
                              {
                                  Title = p.Title,
                                  Description = p.Description,
                                  UploadData = p.UploadDate,
                                  CategoryID = c.CategoryName,
                                  UserID = u.UserName,
                                  Like=p.Like
                              }).ToList();
            return result ;
        }

        public Party.DataAccess.Users GetByUseName(string userName)
        {
            Party.DataAccess.ForumPartyEntities1 ent = new DataAccess.ForumPartyEntities1();
            var sonuc = ent.Users.Where(p => p.UserName== userName);
            return sonuc.FirstOrDefault();
        }
        public string FindData(Party.DataAccess.Users obje) 
        {
            try
            {
                Party.DataAccess.ForumPartyEntities1 find = new DataAccess.ForumPartyEntities1();
                Party.DataAccess.Users user = new DataAccess.Users();
                user.UserName = obje.UserName;
                user.UserPassword = obje.UserPassword;
                var aranan = find.Users.FirstOrDefault(p => p.UserName == obje.UserName);
                if(aranan!=null)
                {
                    if (aranan.UserName == obje.UserName && aranan.UserPassword == obje.UserPassword)
                        return "1";
                    else
                        return "-1";

                }
                else
                {
                    return "0";
                }
                
            }
            catch(Exception e)
            {
                return e.Message;
            }
           
           
        }

        public string AddData(Party.DataAccess.Users obje)
        {
            Party.DataAccess.ForumPartyEntities1 ekleme = new DataAccess.ForumPartyEntities1();
            Party.DataAccess.Users yeni = new DataAccess.Users();
            yeni.UserName = obje.UserName;
            yeni.UserPassword = obje.UserPassword;
            yeni.UserMail = obje.UserMail;
            yeni.UsersStateID = 5;

            ekleme.Users.Add(yeni);
            ekleme.SaveChanges();

            var getCurrentData = Listele();
            return "1";
        }
        public string UpdateData(int UserID,  Party.DataAccess.Users obje)
        {
            Party.DataAccess.ForumPartyEntities1 ekleme = new DataAccess.ForumPartyEntities1();
            Party.DataAccess.Users yeni = new DataAccess.Users();
            var aranan = ekleme.Users.Where(p => p.UserID == UserID).FirstOrDefault();


            aranan.UserName = obje.UserName;
            aranan.UserPassword = obje.UserPassword;
            aranan.UserMail = obje.UserMail;
            aranan.UsersStateID = 5;

            //ekleme.Users.Add(aranan);
            ekleme.SaveChanges();

            var getCurrentData = Listele();
            return "1";
        }
        public string DeleteData(int UserID)
        {
            Party.DataAccess.ForumPartyEntities1 sil = new DataAccess.ForumPartyEntities1();
            var aranan = sil.Users.Where(p => p.UserID == UserID).FirstOrDefault();
            sil.Users.Remove(aranan);
            sil.SaveChanges();

            var getCurrentData = Listele();
            return "1";
        }

    }
}

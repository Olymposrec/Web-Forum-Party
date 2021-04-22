using System;
using System.Collections.Generic;
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

        public Party.DataAccess.Users GetByUseName(string userName)
        {
            Party.DataAccess.ForumPartyEntities1 ent = new DataAccess.ForumPartyEntities1();
            var sonuc = ent.Users.Where(p => p.UserName== userName);
            return sonuc.FirstOrDefault();
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

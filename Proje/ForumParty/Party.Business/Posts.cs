using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party.Business
{
    public class Posts
    {
        public  Repository<DataAccess.Posts> repo_post = new Repository<DataAccess.Posts>();
        public IEnumerable<dynamic> SpecificGetPosts()
        {
            DataAccess.Posts ent2 = new DataAccess.Posts();
            DataAccess.ForumPartyEntities1 data = new DataAccess.ForumPartyEntities1();
            var result = (from p in data.Posts
                          from c in data.Categories
                          from u in data.Users
                          where c.CategoryID == p.CategoryID && p.UserID == u.UserID
                          select new
                          {
                              PostID=p.PostID,
                              Title = p.Title,
                              Description = p.Description,
                              UploadData = p.UploadDate,
                              CategoryID = c.CategoryName,
                              UserID = u.UserName,
                              PostImage=p.PostImage,
                              Like = p.Like
                          }).OrderByDescending(x=> x.PostID).ToList();
            return result;
        }

        public IQueryable<DataAccess.Posts> GetAllPostsQueryable()
        {
            return repo_post.ListQueyable();
        }
    }
}

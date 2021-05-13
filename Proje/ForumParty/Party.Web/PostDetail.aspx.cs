using Party.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Party.Web
{
    public partial class PostDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int postID = int.Parse(RouteData.Values["PostID"].ToString());
            var userID = RouteData.Values["UserID"].ToString();

            DataAccess.ForumPartyEntities1 data = new DataAccess.ForumPartyEntities1();

            var result = (from p in data.Posts
                          from u in data.Users
                          where p.PostID == postID && u.UserName == userID
                          select new
                          {
                              Title = p.Title,
                              Description = p.Description,
                              UploadDate = p.UploadDate,
                              UserID = u.UserName,
                              PostImage = p.PostImage,
                              postID=p.PostID,
                              Like = p.Like
                          }).ToList();
            Repeater2.DataSource = result;
            Repeater2.DataBind();


            if (RouteData.Values["PostID"] != null && RouteData.Values["UserID"] != null)
            {
                if (Session["UserName"] == null)
                {
                    Response.Redirect("/HomePage");
                }
            }
        }

        protected void lbl_upvote_Click(object sender, EventArgs e)
        {

            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Label post = (Label)item.FindControl("Label1") as Label;
            Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();
            int postID = int.Parse(post.Text);
            var result = data.Find(x => x.PostID == postID);
            result.Like++;
            data.Update(result);
            Response.Redirect(Request.RawUrl);
        }

        protected void lbl_downvote_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Label post = (Label)item.FindControl("Label1") as Label;
            Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();
            int postID = int.Parse(post.Text);
            var result = data.Find(x => x.PostID == postID);
            result.Like--;
            data.Update(result);
            Response.Redirect(Request.RawUrl);
        }
    }
}
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
            var userName = RouteData.Values["UserName"].ToString();

            DataAccess.ForumPartyEntities1 data = new DataAccess.ForumPartyEntities1();

            var result = (from p in data.Posts
                          from u in data.Users
                          where p.PostID == postID && u.UserName == userName
                          select new
                          {
                              Title = p.Title,
                              Description = p.Description,
                              UploadDate = p.UploadDate,    
                              UserID = u.UserID,
                              UserName=u.UserName,
                              PostImage = p.PostImage,
                              postID=p.PostID,
                              Like = p.Like
                          }).ToList();
            Repeater2.DataSource = result;
            Repeater2.DataBind();

            DataAccess.ForumPartyEntities1 comment = new DataAccess.ForumPartyEntities1();

            var comResult= (from p in comment.PostCommnets
                            where p.PostID==postID
                            select new
                            {
                                CommentID=p.CommentID,
                                PostID=p.Posts.PostID,
                                CommentDate=p.PostDate,
                                Content=p.Content,
                                NickName=p.Users.UserName

                            }).ToList();
            Repeater1.DataSource = comResult;
            Repeater1.DataBind();

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
            Label post = (Label)item.FindControl("Label1");
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
            Label post = (Label)item.FindControl("Label1");
            Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();
            int postID = int.Parse(post.Text);
            var result = data.Find(x => x.PostID == postID);
            result.Like--;
            data.Update(result);
            Response.Redirect(Request.RawUrl);
        }

        protected void btn_comment_Click(object sender, EventArgs e)
        {
            int postID = Convert.ToInt32(RouteData.Values["PostID"].ToString());
            int userID = Convert.ToInt32(Session["UserID"].ToString());
            Repository<DataAccess.PostCommnets> repo = new Repository<DataAccess.PostCommnets>();
            DataAccess.PostCommnets commentInsert = new DataAccess.PostCommnets()
            {
                PostID = postID,
                PostDate = DateTime.Today.ToShortDateString(),
                Content = txt_Comment.Text,
                UserID=userID
            };

            repo.Insert(commentInsert);

            string userName = RouteData.Values["UserName"].ToString();
                Session["ClickedPostID"] = postID;
            Response.Redirect("/PostDetail/" + postID + "/" + userName);
        }

        protected void lb_routeProfile_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {

                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                Label userIDLabel = (Label)item.FindControl("Label2");
                LinkButton user = (LinkButton)item.FindControl("lb_routeProfile");
                Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();
                int UserID = int.Parse(userIDLabel.Text.ToString());
                string userName = user.Text;
                Response.Redirect("/Profile/" + UserID + "/" + userName);
            }
            else
            {
                Response.Redirect("/LogInPage");
            }
        }
    }
}
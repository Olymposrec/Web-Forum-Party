using Party.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Party.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RouteData.Values["CategoryName"] != null)
            {
                string specificCategory = RouteData.Values["CategoryName"].ToString();
                DataAccess.ForumPartyEntities1 homePageData = new DataAccess.ForumPartyEntities1();
                var result = (from p in homePageData.Posts
                              where p.Categories.CategoryID == p.CategoryID && p.UserID == p.Users.UserID && p.PrivacyID != 1 && 
                              p.Categories.CategoryName==specificCategory
                              select new
                              {
                                  PostID = p.PostID,
                                  Title = p.Title,
                                  Description = p.Description,
                                  UploadDate = p.UploadDate,
                                  CategoryID = p.Categories.CategoryID,
                                  UserName = p.Users.UserName,
                                  PostImage = p.PostImage,
                                  Like = p.Like,
                                  UserID = p.Users.UserID,
                                  CommunityName = p.Communities.CommunityName,
                                  CommunityID = p.Communities.CommunityID

                              }).OrderByDescending(x => x.PostID).ToList();


                Repeater1.DataSource = result;
                Repeater1.DataBind();
            }else
            {

                DataAccess.ForumPartyEntities1 homePageData = new DataAccess.ForumPartyEntities1();
                var result = (from p in homePageData.Posts
                              where p.Categories.CategoryID == p.CategoryID && p.UserID == p.Users.UserID && p.PrivacyID != 1
                              select new
                              {
                                  PostID = p.PostID,
                                  Title = p.Title,
                                  Description = p.Description,
                                  UploadDate = p.UploadDate,
                                  CategoryID = p.Categories.CategoryID,
                                  UserName = p.Users.UserName,
                                  PostImage = p.PostImage,
                                  Like = p.Like,
                                  UserID = p.Users.UserID,
                                  CommunityName = p.Communities.CommunityName,
                                  CommunityID= p.Communities.CommunityID
                              }).OrderByDescending(x => x.PostID).ToList();


                Repeater1.DataSource = result;
                Repeater1.DataBind();
            }

           
        }

        protected void lbl_upvote_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                Label post = (Label)item.FindControl("Label1") as Label;
                Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();
                int postID = int.Parse(post.Text.ToString());
                var result = data.Find(x => x.PostID == postID);
                result.Like++;
                data.Update(result);
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Response.Redirect("/LogInPage");
            }


        }
        protected void lb_Comment_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("/LogInPage");
            }
            else
            {
                //RepeaterItem item = (sender as Repeater).Parent as RepeaterItem;
                RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
                Label post = (Label)item.FindControl("Label1") as Label;
                LinkButton user = (LinkButton)item.FindControl("lb_UserProfile");
                Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();
                int postID = int.Parse(post.Text);
                string userName = user.Text;
                Session["ClickedPostID"] = postID;
                Response.Redirect("/PostDetail/" + postID + "/" + userName);
            }

        }

        protected void lbl_downvote_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
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
            else
            {
                Response.Redirect("/LogInPage");
            }

        }



        protected void lb_Detail_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("/LogInPage");
            }
            else
            {
                //RepeaterItem item = (sender as Repeater).Parent as RepeaterItem;
                RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
                Label post = (Label)item.FindControl("Label1") as Label;
                LinkButton user = (LinkButton)item.FindControl("lb_UserProfile");
                Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();
                int postID = int.Parse(post.Text);
                string userName = user.Text;
                Session["ClickedPostID"] = postID;
                Response.Redirect("/PostDetail/" + postID + "/" + userName);
            }

        }


        protected void lb_UserProfile_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {

                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                Label userIDLabel = (Label)item.FindControl("Label2") ;
                LinkButton user = (LinkButton)item.FindControl("lb_UserProfile");
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

        protected void community_Linkbtn_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {

                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                LinkButton communityNameIndex = (LinkButton)item.FindControl("community_Linkbtn");
                LinkButton communityIDIndex = (LinkButton)item.FindControl("lb_CommunityID");
                string communityName = communityNameIndex.Text.ToString();
                int communityID = Convert.ToInt32(communityIDIndex.Text.ToString());
                Response.Redirect("/Community/" + communityID + "/" + communityName);
            }
            else
            {
                Response.Redirect("/LogInPage");
            }


        }


       
    }
}
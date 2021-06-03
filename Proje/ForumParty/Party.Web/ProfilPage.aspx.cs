using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Party.Business;

namespace Party.Web
{
    public partial class ProfilPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserName"] == null)
            {
                Response.Redirect("/LogInPage");
            }
            else
            {
                string profileOwner = Session["UserName"].ToString();



                if (RouteData.Values["UserID"] == null || RouteData.Values["UserName"].ToString() == Session["UserName"].ToString())
                {
                    if (!IsPostBack)
                    {


                        string user = Session["UserName"].ToString();
                        DataAccess.ForumPartyEntities1 data = new DataAccess.ForumPartyEntities1();

                        var res = (from p in data.Posts
                                   from u in data.Users
                                   where p.UserID == u.UserID && u.UserName == user
                                   select new
                                   {
                                       Title = p.Title,
                                       Description = p.Description,
                                       UploadDate = p.UploadDate,
                                       UserID = u.UserID,
                                       UserName = u.UserName,
                                       PostImage = p.PostImage,
                                       Like = p.Like,
                                       PostID = p.PostID
                                   }).OrderByDescending(x => x.PostID).ToList();

                        Repeater1.DataSource = res;
                        Repeater1.DataBind();




                        int userID = int.Parse(Session["UserID"].ToString());

                        DataAccess.ForumPartyEntities1 data2 = new DataAccess.ForumPartyEntities1();
                        var result2 = (
                                       from a in data2.AboutUsers
                                       where a.UserID == userID && a.Users.UserName == user
                                       select new
                                       {
                                           UserID = a.UserID,
                                           AboutMe = a.AboutMe,
                                           Name = a.Name,
                                           Surname = a.SurName,
                                           UserName = a.Users.UserName,
                                           Followers = a.Users.UserFollowers.Count
                                       }).ToList();



                        DataList1.DataSource = result2;
                        DataList1.DataBind();



                    }

                }
                else if (RouteData.Values["UserID"] != null && RouteData.Values["UserName"] != null)
                {
                    if (!IsPostBack)
                    {

                        if (RouteData.Values["UserName"].ToString() != profileOwner)
                        {
                            string user = RouteData.Values["UserName"].ToString();
                            int guestuserID = int.Parse(RouteData.Values["UserID"].ToString());
                            DataAccess.ForumPartyEntities1 guestData = new DataAccess.ForumPartyEntities1();

                            var result = (from p in guestData.Posts
                                          where p.UserID == p.Users.UserID && p.Users.UserName == user && p.PrivacyID != 1
                                          select new
                                          {
                                              Title = p.Title,
                                              Description = p.Description,
                                              UploadDate = p.UploadDate,
                                              UserID = p.UserID,
                                              UserName = p.Users.UserName,
                                              PostImage = p.PostImage,
                                              Like = p.Like,
                                              PostID = p.PostID
                                          }).OrderByDescending(x => x.PostID).ToList();



                            Repeater1.DataSource = result;
                            Repeater1.DataBind();

                            DataAccess.ForumPartyEntities1 data3 = new DataAccess.ForumPartyEntities1();
                            var result3 = (from a in data3.AboutUsers
                                           where a.Users.UserName == user && a.UserID == guestuserID
                                           select new
                                           {
                                               UserID = a.UserID,
                                               AboutMe = a.AboutMe,
                                               ProfilImage = a.ProfilImage,
                                               Name = a.Name,
                                               SurName = a.SurName,
                                               UserName = a.Users.UserName,
                                               Followers = a.Users.UserFollowers.Count
                                           }).ToList();

                            DataList1.DataSource = result3;
                            DataList1.DataBind();
                        }
                    }
                }

            }


        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (RouteData.Values["UserName"].ToString() != Session["UserName"].ToString())
            {

                LinkButton post = (LinkButton)e.Item.FindControl("LinkButton2") as LinkButton;
                post.Visible = false;
            }
            else
            {
                LinkButton post = (LinkButton)e.Item.FindControl("LinkButton2") as LinkButton;
                post.Visible = true;
            }
        }

        protected void lbl_upvote_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                Label post = (Label)item.FindControl("Label5") as Label;
                Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();
                int postID = int.Parse(post.Text);
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

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (RouteData.Values["UserName"] != null)
            {
                if (RouteData.Values["UserName"].ToString() != Session["UserName"].ToString())
                {

                    LinkButton post = (LinkButton)e.Item.FindControl("delete_PostLink") as LinkButton;
                    post.Visible = false;
                }
                else
                {
                    LinkButton post = (LinkButton)e.Item.FindControl("delete_PostLink") as LinkButton;
                    post.Visible = true;
                }
            }

        }

        protected void btn_follow_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                int mainUserID = Convert.ToInt32(Session["UserID"].ToString());
                int routeID = Convert.ToInt32(RouteData.Values["UserID"].ToString());
                DataAccess.ForumPartyEntities1 follower = new DataAccess.ForumPartyEntities1();
                var followRes = (from p in follower.UserFollowers
                                 where p.FollowerID == mainUserID && p.UserID == routeID
                                 select new
                                 {
                                     UserID = p.UserID,
                                     FollowerID = p.FollowerID
                                 }).FirstOrDefault();
                if (followRes != null)
                {
                    int getID = Convert.ToInt32(Session["UserID"].ToString());
                    int UserID = int.Parse(RouteData.Values["UserID"].ToString());

                    DataAccess.UserFollowers deleteFollower = new DataAccess.UserFollowers();
                    Repository<DataAccess.UserFollowers> repo = new Repository<DataAccess.UserFollowers>();
                    var result = repo.Find(x => x.FollowerID == getID && x.UserID == UserID);
                    repo.Delete(result);
                    Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
                }
                else if (followRes == null)
                {

                    int getID = Convert.ToInt32(Session["UserID"].ToString());
                    DataAccess.UserFollowers newFollower = new DataAccess.UserFollowers()
                    {
                        UserID = int.Parse(RouteData.Values["UserID"].ToString()),
                        FollowerID = getID
                    };
                    Repository<DataAccess.UserFollowers> repo = new Repository<DataAccess.UserFollowers>();
                    repo.Insert(newFollower);

                    Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
                }
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

                RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
                Label post = (Label)item.FindControl("Label5") as Label;
                LinkButton user = (LinkButton)item.FindControl("lb_profilRoute");
                Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();
                int postID = int.Parse(post.Text);
                string userName = user.Text;
                Session["ClickedPostID"] = postID;
                Response.Redirect("/PostDetail/" + postID + "/" + userName);
            }

        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DataList1_ItemCreated(object sender, DataListItemEventArgs e)
        {
            if (RouteData.Values["UserID"] == null || RouteData.Values["UserName"].ToString() == Session["UserName"].ToString())
            {
                e.Item.FindControl("btn_follow").Visible = false;
                e.Item.FindControl("btn_chat").Visible = false;
                e.Item.FindControl("btn_editProfil").Visible = true;
                e.Item.FindControl("btn_editCommunity").Visible = true;
            }
            else
            {
                int UserID = int.Parse(RouteData.Values["UserID"].ToString());
                int mainUserID = Convert.ToInt32(Session["UserID"].ToString());
                DataAccess.ForumPartyEntities1 follower = new DataAccess.ForumPartyEntities1();
                var followRes = (from p in follower.UserFollowers
                                 where p.FollowerID == mainUserID && p.UserID == UserID
                                 select new
                                 {
                                     UserID = p.UserID,
                                     FollowerID = p.FollowerID
                                 }).FirstOrDefault();

                if (followRes != null)
                {
                    Button followButton = e.Item.FindControl("btn_follow") as Button;
                    followButton.Text = "Followed";
                }
                else
                {
                    Button followButton = e.Item.FindControl("btn_follow") as Button;
                    followButton.Text = "Follow";
                }


                e.Item.FindControl("btn_chat").Visible = true;
                e.Item.FindControl("btn_editProfil").Visible = false;
                e.Item.FindControl("btn_editCommunity").Visible = false;

            }

        }

        protected void btn_editProfil_Click(object sender, EventArgs e)
        {

            Response.Redirect("/AboutUser");
        }

        protected void lbl_downvote_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                Label post = (Label)item.FindControl("Label5") as Label;
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

        protected void delete_PostLink_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                Label post = (Label)item.FindControl("Label5") as Label;
                Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();
                int postID = int.Parse(post.Text);
                var result = data.Find(x => x.PostID == postID);
                data.Delete(result);
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Response.Redirect("/LogInPage");
            }
        }

        protected void post_DetailLink_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("/LogInPage");
            }
            else
            {

                RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
                Label post = (Label)item.FindControl("Label5") as Label;
                LinkButton user = (LinkButton)item.FindControl("lb_profilRoute");
                Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();
                int postID = int.Parse(post.Text);
                string userName = user.Text;
                Session["ClickedPostID"] = postID;
                Response.Redirect("/PostDetail/" + postID + "/" + userName);
            }
        }

        protected void btn_editCommunity_Click(object sender, EventArgs e)
        {
            Response.Redirect("/EditCommunity");
        }

        protected void lb_profilRoute_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {

                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                Label userIDLabel = (Label)item.FindControl("Label2");
                LinkButton user = (LinkButton)item.FindControl("lb_profilRoute");
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

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            string user = Session["UserName"].ToString();
            int userID = int.Parse(Session["UserID"].ToString());
            DataAccess.ForumPartyEntities1 profilImage = new DataAccess.ForumPartyEntities1();

            var image = (from a in profilImage.AboutUsers
                         where a.UserID == userID && a.Users.UserName == user
                         select new
                         {
                             ProfilImage = a.ProfilImage
                         }).FirstOrDefault();

                Image pImage = (Image)e.Item.FindControl("Image1");
            if (image.ProfilImage == null)
            {
                pImage.ImageUrl = "~/Resource/images/profilDefaultImage.png";
            }
            else
            {
                pImage.ImageUrl = "<%# 'data: image / jpeg; base64,'"+ Convert.ToBase64String((byte[])image.ProfilImage)+"%>";
            }
        }

        protected void btn_chat_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Messages/"+Session["UserName"].ToString());
        }
    }
}
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
                                       UserID = u.UserName,
                                       PostImage = p.PostImage,
                                       Like = p.Like,
                                       PostID = p.PostID
                                   }).OrderBy(x => x.UploadDate).ToList();

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
                                           ProfilImage = a.ProfilImage,
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
                                          from u in guestData.Users
                                          where p.UserID == u.UserID && u.UserName == user && p.PrivacyID != 1
                                          select new
                                          {
                                              Title = p.Title,
                                              Description = p.Description,
                                              UploadDate = p.UploadDate,
                                              UserID = u.UserName,
                                              PostImage = p.PostImage,
                                              Like = p.Like,
                                              PostID=p.PostID
                                          }).OrderBy(x => x.UploadDate).ToList();

                            Repeater1.DataSource = result;
                            Repeater1.DataBind();

                            DataAccess.ForumPartyEntities1 data3 = new DataAccess.ForumPartyEntities1();
                            var result3 = (from u in data3.Users
                                           from a in data3.AboutUsers
                                           where u.UserName == user && a.UserID == guestuserID
                                           select new
                                           {
                                               UserID = a.UserID,
                                               AboutMe = a.AboutMe,
                                               ProfilImage = a.ProfilImage,
                                               Name = a.Name,
                                               SurName = a.SurName,
                                               UserName = u.UserName,
                                               Followers = u.UserFollowers.Count
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
                Label post = (Label)item.FindControl("Label1") as Label;
                Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();
                int postID = int.Parse(post.Text);
                var result = data.Find(x => x.PostID == postID);
                result.Like++;
                data.Update(result);
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

                    LinkButton post = (LinkButton)e.Item.FindControl("LinkButton2") as LinkButton;
                    post.Visible = false;
                }
                else
                {
                    LinkButton post = (LinkButton)e.Item.FindControl("LinkButton2") as LinkButton;
                    post.Visible = true;
                }
            }
           
        }

        protected void btn_follow_Click(object sender, EventArgs e)
        {
            int getID = Convert.ToInt32(value: Session["UserID"]);

            DataAccess.UserFollowers newFollower = new DataAccess.UserFollowers()
            {
                UserID = int.Parse(RouteData.Values["UserID"].ToString()),
                FollowerID = getID
            };
            Repository<DataAccess.UserFollowers> repo = new Repository<DataAccess.UserFollowers>();
            repo.Insert(newFollower);
            
            

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
                Label post = (Label)item.FindControl("Label5") as Label;
                LinkButton user = (LinkButton)item.FindControl("LinkButton1");
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
            }
            else
            {
                e.Item.FindControl("btn_follow").Visible = true;
                e.Item.FindControl("btn_chat").Visible = true;
                e.Item.FindControl("btn_editProfil").Visible = false;
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
                Label post = (Label)item.FindControl("Label1") as Label;
                Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();
                int postID = int.Parse(post.Text);
                var result = data.Find(x => x.PostID == postID);
                result.Like--;
                data.Update(result);
            }
            else
            {
                Response.Redirect("/LogInPage");
            }
        }

        protected void delete_PostLink_Click(object sender, EventArgs e)
        {

        }

        protected void post_DetailLink_Click(object sender, EventArgs e)
        {

        }

        //protected void UpdatePanel1_PreRender(object sender, EventArgs e)
        //{
        //    if(RouteData.Values["UserID"] == null || RouteData.Values["UserName"].ToString() == Session["UserName"].ToString())
        //    {
        //        UpdatePanel item = (sender as LinkButton).Parent as UpdatePanel;
        //        Button btn = (Button)item.FindControl("btn_follow") as Button;
        //        Button btn2 = (Button)item.FindControl("btn_chat") as Button;
        //        btn.Visible = false;
        //        btn2.Visible = false;
        //    }
        //    else
        //    {
        //        UpdatePanel item = (sender as Button).Parent as UpdatePanel;
        //        Button btn = (Button)item.FindControl("btn_follow") as Button;
        //        Button btn2 = (Button)item.FindControl("btn_chat") as Button;
        //        btn.Visible = true;
        //        btn2.Visible = true;
        //    }




        //}
    }
}
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

                if(RouteData.Values["UserID"] == null || RouteData.Values["UserName"].ToString() == Session["UserName"].ToString())
                {
                    string user = Session["UserName"].ToString();
                    DataAccess.ForumPartyEntities1 data = new DataAccess.ForumPartyEntities1();

                    var result = (from p in data.Posts
                                  from u in data.Users
                                  where p.UserID == u.UserID && u.UserName == profileOwner
                                  select new
                                  {
                                      Title = p.Title,
                                      Description = p.Description,
                                      UploadDate = p.UploadDate,
                                      UserID = u.UserName,
                                      PostImage = p.PostImage,
                                      Like = p.Like
                                  }).ToList();
                    Repeater1.DataSource = result;
                    Repeater1.DataBind();
                }
                else if (RouteData.Values["UserID"] != null && RouteData.Values["UserName"] != null)
                {
                    if(RouteData.Values["UserName"].ToString()!= profileOwner)
                    {
                        string user = RouteData.Values["UserName"].ToString();
                        DataAccess.ForumPartyEntities1 data = new DataAccess.ForumPartyEntities1();

                        var result = (from p in data.Posts
                                      from u in data.Users
                                      where p.UserID == u.UserID && u.UserName == user
                                      select new
                                      {
                                          Title = p.Title,
                                          Description = p.Description,
                                          UploadDate = p.UploadDate,
                                          UserID = u.UserName,
                                          PostImage = p.PostImage,
                                          Like = p.Like
                                      }).ToList();

                        Repeater1.DataSource = result;
                        Repeater1.DataBind();
                        
                    }
                }
            }
           
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(RouteData.Values["UserName"].ToString() != Session["UserName"].ToString())
            {
               
                LinkButton post = (LinkButton)e.Item.FindControl("Label1") as LinkButton;
                post.Visible = false;
            }
            else
            {
                LinkButton post = (LinkButton)e.Item.FindControl("Label1") as LinkButton;
                post.Visible = true;
            }
        }

        protected void lbl_upvote_Click(object sender, EventArgs e)
        {

        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
             if(RouteData.Values["UserName"].ToString() != Session["UserName"].ToString())
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
}
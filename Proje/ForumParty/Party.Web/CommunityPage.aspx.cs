using Party.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Party.Web
{
    public partial class CommunityPage : System.Web.UI.Page
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
                string commNameValue = RouteData.Values["CommunityName"].ToString();
                int commIDValue = Convert.ToInt32(RouteData.Values["CommunityID"].ToString());
                if (!IsPostBack)
                {


                    string user = Session["UserName"].ToString();
                    DataAccess.ForumPartyEntities1 data = new DataAccess.ForumPartyEntities1();

                    var res = (from p in data.Posts
                               where p.Communities.CommunityID == commIDValue && p.Communities.CommunityName== commNameValue
                               select new
                               {
                                   Title = p.Title,
                                   Description = p.Description,
                                   UploadDate = p.UploadDate,
                                   UserID = p.UserID,
                                   PostImage = p.PostImage,
                                   Like = p.Like,
                                   CommunityName = p.Communities.CommunityName,
                                   CommunityID = p.Communities.CommunityID,
                                   PostID = p.PostID
                               }).OrderBy(x => x.UploadDate).ToList();

                    Repeater1.DataSource = res;
                    Repeater1.DataBind();



                    DataAccess.ForumPartyEntities1 data2 = new DataAccess.ForumPartyEntities1();
                    var result2 = (
                                   from a in data2.Communities
                                   where a.CommunityName == commNameValue && a.CommunityID==commIDValue
                                   select new
                                   {
                                       ProfilImage = a.CommunityImage,
                                       CommunityName = a.CommunityName,
                                       Members = a.MembersCount,
                                       AboutMe = a.Description
                                   }).ToList();

                    DataList1.DataSource = result2;
                    DataList1.DataBind();
                }


                //if (!IsPostBack)
                //{
                   

                //    DataAccess.ForumPartyEntities1 guestData = new DataAccess.ForumPartyEntities1();

                //    var result = (from p in guestData.Posts
                //                  from u in guestData.Users
                //                  where p.Communities.CommunityID == commNameValue && p.Communities.CommunityName == commIDValue && p.PrivacyID != 1
                //                  select new
                //                  {
                //                      Title = p.Title,
                //                      Description = p.Description,
                //                      UploadDate = p.UploadDate,
                //                      UserID = u.UserName,
                //                      PostImage = p.PostImage,
                //                      Like = p.Like,
                //                      PostID = p.PostID
                //                  }).OrderBy(x => x.UploadDate).ToList();

                //    Repeater1.DataSource = result;
                //    Repeater1.DataBind();

                //    DataAccess.ForumPartyEntities1 data3 = new DataAccess.ForumPartyEntities1();
                //    var result3 = (from a in data3.Communities
                //                   from d in data3.UsersCommunity
                //                   where a.CommunityName == commNameValue
                //                   select new
                //                   {
                //                       ProfilImage = a.CommunityImage,
                //                       CommunityName = a.CommunityName,
                //                       Members = a.MembersCount,
                //                       AboutMe = a.Description
                //                   }).ToList();

                //    DataList1.DataSource = result3;
                //    DataList1.DataBind();
                //}

            }
        }
        protected void lbl_upvote_Click(object sender, EventArgs e)
        {
            //if (Session["UserName"] != null)
            //{
            //    RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            //    Label post = (Label)item.FindControl("Label1") as Label;
            //    Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();
            //    int postID = int.Parse(post.Text.ToString());
            //    var result = data.Find(x => x.PostID == postID);
            //    result.Like++;
            //    data.Update(result);
            //}
            //else
            //{
            //    Response.Redirect("/LogInPage");
            //}


        }
        protected void btn_join_Click(object sender, EventArgs e)
        {
            //if (Session["UserName"] != null)
            //{
            //    RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            //    Label post = (Label)item.FindControl("Label1") as Label;
            //    Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();
            //    int postID = int.Parse(post.Text.ToString());
            //    var result = data.Find(x => x.PostID == postID);
            //    result.Like++;
            //    data.Update(result);
            //}
            //else
            //{
            //    Response.Redirect("/LogInPage");
            //}


        }
        protected void lb_Comment_Click(object sender, EventArgs e)
        {
            //if (Session["UserName"] == null)
            //{
            //    Response.Redirect("/LogInPage");
            //}
            //else
            //{
            //    //RepeaterItem item = (sender as Repeater).Parent as RepeaterItem;
            //    RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            //    Label post = (Label)item.FindControl("Label1") as Label;
            //    LinkButton user = (LinkButton)item.FindControl("lb_UserProfile");
            //    Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();
            //    int postID = int.Parse(post.Text);
            //    string userName = user.Text;
            //    Session["ClickedPostID"] = postID;
            //    Response.Redirect("/PostDetail/" + postID + "/" + userName);
            //}

        }

        protected void lbl_downvote_Click(object sender, EventArgs e)
        {
            //if (Session["UserName"] != null)
            //{
            //    RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            //    Label post = (Label)item.FindControl("Label1") as Label;
            //    Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();
            //    int postID = int.Parse(post.Text);
            //    var result = data.Find(x => x.PostID == postID);
            //    result.Like--;
            //    data.Update(result);
            //}
            //else
            //{
            //    Response.Redirect("/LogInPage");
            //}

        }



        protected void lb_Detail_Click(object sender, EventArgs e)
        {
            //if (Session["UserName"] == null)
            //{
            //    Response.Redirect("/LogInPage");
            //}
            //else
            //{
            //    //RepeaterItem item = (sender as Repeater).Parent as RepeaterItem;
            //    RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            //    Label post = (Label)item.FindControl("Label1") as Label;
            //    LinkButton user = (LinkButton)item.FindControl("lb_UserProfile");
            //    Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();
            //    int postID = int.Parse(post.Text);
            //    string userName = user.Text;
            //    Session["ClickedPostID"] = postID;
            //    Response.Redirect("/PostDetail/" + postID + "/" + userName);
            //}

        }


        protected void lb_UserProfile_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {

                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                LinkButton userIDLabel = (LinkButton)item.FindControl("LinkButton1") as LinkButton;
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
            //if (Session["UserName"] != null)
            //{

            //    RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            //    Label userIDLabel = (Label)item.FindControl("Label2") as Label;
            //    LinkButton user = (LinkButton)item.FindControl("lb_UserProfile");
            //    Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();
            //    int UserID = int.Parse(userIDLabel.Text.ToString());
            //    string userName = user.Text;
            //    Response.Redirect("/Profile/" + CommunityName + "/" + userName);
            //}
            //else
            //{
            //    Response.Redirect("/LogInPage");
            //}


        }

        protected void btn_editProfil_Click(object sender, EventArgs e)
        {

        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DataList1_ItemCreated(object sender, DataListItemEventArgs e)
        {

        }

        protected void delete_PostLink_Click(object sender, EventArgs e)
        {

        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}
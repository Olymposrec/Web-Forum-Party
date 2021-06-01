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
            int userPerm = Convert.ToInt32(Session["UserID"].ToString());
            int commIDValue = Convert.ToInt32(RouteData.Values["CommunityID"].ToString());

            if (Session["UserName"] == null)
            {
                Response.Redirect("/LogInPage");
            }
            else
            {
                string profileOwner = Session["UserName"].ToString();
                string commNameValue = RouteData.Values["CommunityName"].ToString();
                if (!IsPostBack)
                {
                    DataAccess.ForumPartyEntities1 data = new DataAccess.ForumPartyEntities1();

                    var res = (from p in data.Posts
                               where p.Communities.CommunityID == commIDValue && p.Communities.CommunityName == commNameValue
                               select new
                               {
                                   Title = p.Title,
                                   Description = p.Description,
                                   UploadDate = p.UploadDate,
                                   UserID = p.Users.UserName,
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
                                   where a.CommunityName == commNameValue && a.CommunityID == commIDValue
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

            }
        }
        protected void lbl_upvote_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                Label post = (Label)item.FindControl("Label5");
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
        protected void btn_join_Click(object sender, EventArgs e)
        {
            string commNameValue = RouteData.Values["CommunityName"].ToString();
            if (Session["UserName"] != null)
            {
                int userPerm = Convert.ToInt32(Session["UserID"].ToString());
                int commIDValue = Convert.ToInt32(RouteData.Values["CommunityID"].ToString());
                DataAccess.ForumPartyEntities1 perm = new DataAccess.ForumPartyEntities1();
                var permResult = (from p in perm.UsersCommunity
                                  where p.UserID == userPerm && p.CommunityID == commIDValue
                                  select new
                                  {
                                      CommunityStateID = p.CommunityStateID
                                  }).FirstOrDefault();
                if (permResult == null)
                {
                    int commID = Convert.ToInt32(RouteData.Values["CommunityID"].ToString());
                    Repository<DataAccess.Communities> data = new Repository<DataAccess.Communities>();

                    var result = data.Find(x => x.CommunityID == commID);
                    result.MembersCount++;
                    data.Update(result);

                    Repository<DataAccess.UsersCommunity> repo = new Repository<DataAccess.UsersCommunity>();
                    int UserID = Convert.ToInt32(Session["UserID"].ToString());
                    DataAccess.UsersCommunity newUserComm = new DataAccess.UsersCommunity
                    {
                        CommunityID = commID,
                        UserID = UserID,
                        CommunityStateID=2
                    };
                    repo.Insert(newUserComm);

                    Response.Redirect("/Community/" + commIDValue + "/" + commNameValue);
                }
                else
                {
                    int commID = Convert.ToInt32(RouteData.Values["CommunityID"].ToString());
                    Repository<DataAccess.Communities> data = new Repository<DataAccess.Communities>();

                    var result = data.Find(x => x.CommunityID == commID);
                    result.MembersCount--;
                    data.Update(result);

                    int UserID = Convert.ToInt32(Session["UserID"].ToString());
                    Repository<DataAccess.UsersCommunity> repo = new Repository<DataAccess.UsersCommunity>();
                    var resul2 = repo.Find(x => x.CommunityID == commID && x.UserID == UserID);
                    repo.Delete(resul2);
                    Response.Redirect("/Community/" + commIDValue + "/" + commNameValue);
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
                LinkButton user = (LinkButton)item.FindControl("LinkButton1");
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
                Label post = (Label)item.FindControl("Label5") as Label;
                Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();
                int postID = int.Parse(post.Text.ToString());
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
            if (Session["UserName"] != null)
            {
                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                LinkButton commName = (LinkButton)item.FindControl("community_Linkbtn");
                int commId = Convert.ToInt32(RouteData.Values["CommunityID"].ToString());
                string commNameRes = commName.Text;
                Response.Redirect("/Community/" + commId + "/" + commNameRes);
            }
            else
            {
                Response.Redirect("/LogInPage");
            }


        }

        protected void btn_editProfil_Click(object sender, EventArgs e)
        {

        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DataList1_ItemCreated(object sender, DataListItemEventArgs e)
        {
            int userPerm = Convert.ToInt32(Session["UserID"].ToString());
            int commIDValue = Convert.ToInt32(RouteData.Values["CommunityID"].ToString());
            DataAccess.ForumPartyEntities1 perm = new DataAccess.ForumPartyEntities1();
            var permResult = (from p in perm.UsersCommunity
                              where p.UserID == userPerm && p.CommunityID == commIDValue
                              select new
                              {
                                  CommunityStateID = p.CommunityStateID
                              }).FirstOrDefault();
            Button btn_join = (Button)e.Item.FindControl("btn_Join");
            Button btn_edit = (Button)e.Item.FindControl("btn_editProfil");
            Button btn_delete = (Button)e.Item.FindControl("btn_delete");
            if (permResult != null)
            {
                int userPrmRes = int.Parse(permResult.CommunityStateID.ToString());
                if (userPrmRes == 2)
                {
                    btn_edit.Visible = false;
                    btn_delete.Visible = false;
                    btn_join.Text = "Joined";
                }
                else if (userPrmRes == 1)
                {
                    btn_edit.Visible = true;
                    btn_delete.Visible = true;
                    btn_join.Text = "Founder";
                    btn_join.Enabled = false;
                }
                else if (userPrmRes == 3)
                {
                    btn_edit.Visible = true;
                    btn_delete.Visible = false;
                    btn_join.Text = "Manager";
                    btn_join.Enabled = true;
                }
            }
            else
            {
                btn_edit.Visible = false;
                btn_delete.Visible = false;
                btn_join.Text = "Join";
                btn_join.Enabled = true;
            }
        }

        protected void delete_PostLink_Click(object sender, EventArgs e)
        {

        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string userPerm = Session["UserName"].ToString();
            LinkButton postUser = e.Item.FindControl("LinkButton1") as LinkButton;

            string postUserName = postUser.Text.ToString();

            if (userPerm == postUserName)
            {

                LinkButton btn_delete = (LinkButton)e.Item.FindControl("delete_PostLink");
                btn_delete.Visible = true;
            }
            else
            {
                LinkButton btn_delete = (LinkButton)e.Item.FindControl("delete_PostLink");
                btn_delete.Visible = false;
            }
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {

        }

        protected void Repeater1_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            

        }
    }
}
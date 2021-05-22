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


            if (Session["UserName"] != null)
            {
                DataAccess.ForumPartyEntities1 homePageData = new DataAccess.ForumPartyEntities1();
                var result = (from p in homePageData.Posts
                              from c in homePageData.Categories
                              from u in homePageData.Users
                              where c.CategoryID == p.CategoryID && p.UserID == u.UserID && p.PrivacyID != 1
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

                              }).OrderBy(x => x.UploadDate).ToList();


                Repeater1.DataSource = result;
                Repeater1.DataBind();
            }
            else
            {

                DataAccess.ForumPartyEntities1 homePageData = new DataAccess.ForumPartyEntities1();
                var result = (from p in homePageData.Posts
                              from c in homePageData.Categories
                              from u in homePageData.Users
                              where c.CategoryID == p.CategoryID && p.UserID == u.UserID && p.PrivacyID != 1
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
                              }).OrderBy(x => x.UploadDate).ToList();


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
                Label userIDLabel = (Label)item.FindControl("Label2") as Label;
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


        //protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    if (e.CommandName == "UpVote")
        //    {
        //        int getPostID = Convert.ToInt32(e.CommandArgument.ToString());
        //        Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();
        //        var result = data.Find(x => x.PostID == getPostID);
        //        result.Like++;
        //        data.Update(result);
        //    }else if (e.CommandName=="DownVote")
        //    {
        //        int getPostID = Convert.ToInt32(e.CommandArgument.ToString());
        //        Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();
        //        var result = data.Find(x => x.PostID == getPostID);
        //        result.Like--;
        //        data.Update(result);
        //    }
        //}

        //protected void lbl_downvote_Click(object sender, EventArgs e)
        //{
        //    RepeaterItem item = (sender as Label).NamingContainer as RepeaterItem;
        //    int getPostID = Convert.ToInt32((item.FindControl("Label1") as Label).Text);
        //    int getCurrentlike = Convert.ToInt32((item.FindControl("lbl_likecount") as Label).Text);
        //    getCurrentlike -= 1;

        //    Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();

        //    var result = data.Find(x =>  x.PostID == getPostID);


        //    result.Like -= getCurrentlike;

        //    data.Update(result);
        //}

        //protected void lbl_upvote_Click(object sender, EventArgs e)
        //{

        //    int getID = 17;
        //    int userID = 1;
        //    int getCurrentlike = Convert.ToInt32(Repeater1.Items.Equals("Like"));
        //    getCurrentlike += 1;

        //    Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();

        //    var result = data.Find(x => x.UserID == 1 && x.PostID == 17);


        //    result.Like += getCurrentlike;

        //    data.Update(result);
        //}

        //protected void Repeater1_ItemCreated(object sender, RepeaterItemEventArgs e)
        //{

        //    //e.Item.ItemType==e.Item.FindControl()
        //}



        //protected void Btn_UpVote_Click(object sender, CommandEventArgs e)
        //{

        //}

        //protected void Btn_UpVote_Click(object sender, CommandEventArgs d)
        //{


        //}
        //protected void Btn_UpDown_Click(object sender, EventArgs e)
        //{

        //}
    }
}
using Party.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Party.Web
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Repository<DataAccess.Categories> repoList = new Repository<DataAccess.Categories>();
                Repeater1.DataSource = repoList.List();
                Repeater1.DataBind();

                Repository<DataAccess.Communities> repoCommWeekly = new Repository<DataAccess.Communities>();
                DataAccess.ForumPartyEntities1 weeklyComm = new DataAccess.ForumPartyEntities1();
                var res = (from c in weeklyComm.Communities
                           select new
                           {
                               CommunityNameTrend = c.CommunityName,
                               CommunityID = c.CommunityID,
                               Members = c.MembersCount
                           }
                           ).OrderByDescending(x => x.Members).Take(5).ToList();

                Repeater2_TrendComm.DataSource = res;
                Repeater2_TrendComm.DataBind();
            }




            if (Session["UserName"] != null )
            {
                lbl_session.Text = Session["UserName"].ToString();
                btn_login.Visible = false;
                btn_logout.Visible = true;
                lnkbtn_MessagePage.Visible = true;
                lnkbtn_MainPage.Visible = true;
                

                if (Convert.ToInt32(Session["UserState"].ToString()) != 1)
                {
                    lb_AdminPanel.Visible = false;
                }
                else
                {
                    lb_AdminPanel.Visible = true;
                }
            }
            else
            {
                lnkbtn_MainPage.Visible = false;
                lnkbtn_MessagePage.Visible = false;
                btn_logout.Visible = false;
                btn_login.Visible = true;
                lbl_session.Text = "";
                lb_AdminPanel.Visible = false;
            }

        }
        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("/LogInPage");
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {

            Session.RemoveAll();
            lbl_session.Text = "";
            Response.Redirect("/LogInPage");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void SearchData_Click(object sender, EventArgs e)
        {
            txt_search.Text = "Search Data Work";
        }
        protected void AddPost_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("/LogInPage");
            }
            else
            {
                Response.Redirect("/AddPost");
            }

        }
        protected void CreateCommunity_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("/LogInPage");
            }
            else
            {
                Response.Redirect("/EditCommunity");
            }

        }

        protected void ForumPage_Click(object sender, EventArgs e)
        {

            Response.Redirect("/HomePage");

        }
        protected void PollsPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Communities");

        }

        protected void MessagesPage_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("/LogInPage");
            }
            else
            {
                Response.Redirect("/Messages/" + Session["UserName"].ToString());
            }


        }
        protected void HomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("/HomePage");

        }

        protected void ProfilePage_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("/LogInPage");
            }
            else
            {
                Response.Redirect("/Profile/" + Session["UserName"].ToString());
            }

        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void lb_category_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            Label categoryName = (Label)item.FindControl("Label2");
            string category = categoryName.Text;
            Response.Redirect("/HomePage/" + category);

        }

        protected void lb_Community_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("/LogInPage");
            }
            else
            {
                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                Label communityIDIndex = (Label)item.FindControl("Label1");
                Label communityNameIndex = (Label)item.FindControl("lbl_trendCommunity");
                string communityName = communityNameIndex.Text.ToString();
                int communityID = Convert.ToInt32(communityIDIndex.Text.ToString());
                Response.Redirect("/Community/" + communityID + "/" + communityName);
            }
           
        }

        protected void lb_AdminPanel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ControlPanel");
        }
    }
}  
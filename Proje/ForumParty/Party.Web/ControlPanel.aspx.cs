using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Party.Web
{
    public partial class ControlPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                btn_logout.Visible = true;
            }
            else
            {
                btn_logout.Visible = false;
            }
        }

        protected void SearchData_Click_Click(object sender, EventArgs e)
        {

        }

        protected void AddPost_Click_Click(object sender, EventArgs e)
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

        protected void CreateCommunity_Click_Click(object sender, EventArgs e)
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

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            lbl_session.Text = "";
            Response.Redirect("/LogInPage");
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            Response.Redirect("/LogInPage");
        }

        protected void lnkbtn_MainPage_Click(object sender, EventArgs e)
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

        protected void lnkbtn_MessagePage_Click(object sender, EventArgs e)
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

        protected void lnkbtn_CommunitiesPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Communities");
        }

        protected void lnkbtn_ForumPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("/HomePage");
        }

        protected void HomePage_Click_Click(object sender, EventArgs e)
        {
            Response.Redirect("/HomePage");
        }

        protected void btn_RouteEditPanel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ControlPanelEdit");
        }
    }
}
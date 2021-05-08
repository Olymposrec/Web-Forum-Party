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
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                string user = Session["UserName"].ToString();
                DataAccess.ForumPartyEntities1 data = new DataAccess.ForumPartyEntities1();

                var result = (from p in data.Posts
                              from u in data.Users
                              where p.UserID == u.UserID && u.UserName==user
                              select new
                              {
                                  Title = p.Title,
                                  Description = p.Description,
                                  UploadDate = p.UploadDate,
                                  UserID = u.UserName,
                                  Like = p.Like
                              }).ToList();
                if (result!=null)
                {
                    Repeater1.DataSource = result;
                    Repeater1.DataBind();
                }
               
            }
           
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}
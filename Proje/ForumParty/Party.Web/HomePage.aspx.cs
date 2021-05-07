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

                Business.Posts test = new Business.Posts();
                Repeater1.DataSource = test.SpecificGetPosts();
                Repeater1.DataBind();
            }
            else
            {

                Business.Posts test = new Business.Posts();
                Repeater1.DataSource = test.SpecificGetPosts();
                Repeater1.DataBind();
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        
    }
}
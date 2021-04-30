using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Party.Web
{
    public partial class PollsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserName"] != null)
            //{
            //    Party.Business.Users nesne = new Business.Users();
            //    var sonuc = nesne.Listele();
            //    Repeater1.DataSource = sonuc.Where(p => p.UserName == Session["UserName"].ToString());
            //    Repeater1.DataBind();
            //}
            //else
            //{
            //    Party.Business.Users nesne = new Business.Users();
            //    var sonuc = nesne.Listele();
            //    Repeater1.DataSource = sonuc;
            //    Repeater1.DataBind();
            //}
        }

        protected void Unnamed1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}
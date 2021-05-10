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

        protected void Btn_UpVote_Click(object sender, EventArgs e)
        {

            int getID=Convert.ToInt32(Repeater1.Items.Equals("PostID"));
            int userID = Convert.ToInt32(Repeater1.Items.Equals("UserID"));
            int getCurrentlike = Convert.ToInt32(Repeater1.Items.Equals("Like"));
            getCurrentlike++;
            Repository<DataAccess.Posts> data = new Repository<DataAccess.Posts>();
            DataAccess.Posts like = new DataAccess.Posts();
            like.Like=getCurrentlike;
            var result =data.Find(y => y.PostID == getID);
            data.Update(result);
        }
        protected void Btn_UpDown_Click(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Party.Web
{
    public partial class LogInPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            Party.Business.Users deneme = new Business.Users();
            Party.DataAccess.Users usersInput = new DataAccess.Users();
            usersInput.UserName = txt_userName.Text;
            usersInput.UserPassword = txt_passWord.Text;
            string returnVal = deneme.FindData(usersInput);

            if (txt_passWord.Text == "" && txt_userName.Text == "")
            {
                lbl_result.Text = "Text Boxes Cannot Be Empty!";

            }
            else
            {
                if (returnVal != null)
                    if (returnVal == "1")
                    {
                        Session["UserName"] = txt_userName.Text;
                        Response.Redirect("/HomePage.aspx");
                    }
                    else if (returnVal == "-1")
                        lbl_result.Text = "Incorrect Username or Password";
                    else
                        lbl_result.Text = "User not found.";
            }
        }
    }
}
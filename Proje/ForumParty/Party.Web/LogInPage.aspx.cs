using Party.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Party.Web
{
    public partial class LogInPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_registerResultDanger.Text = "";
            lbl_registerResultSuccess.Text = "";
            lbl_result.Text = "";
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            //Party.Business.Users deneme = new Business.Users();
            Party.DataAccess.Users usersInput = new DataAccess.Users();
            usersInput.UserName = txt_userName.Text;
            usersInput.UserPassword = txt_passWord.Text;
            //string returnVal = deneme.FindData(usersInput);

            Repository<DataAccess.Users> repo = new Repository<DataAccess.Users>();
            var returnVal = repo.Find(p => p.UserName == usersInput.UserName && p.UserPassword==usersInput.UserPassword);

            if (txt_passWord.Text == "" || txt_userName.Text == "")
            {
                lbl_result.Text = "Text Boxes Cannot Be Empty!";
                
            }
            else
            {
                if (returnVal != null)
                {
                    Session["UserName"] = txt_userName.Text;

                    var returnID = repo.Find(p => p.UserName == usersInput.UserName);
                    Session["UserID"]=returnID.UserID;
                    Response.Redirect("/HomePage.aspx");
                }
                else
                {
                    lbl_result.Text = "Incorrect Username or Password";
                }
            }
        }



        protected void register_Click(object sender, EventArgs e)
        {
            if (txt_confirmPasswordRegister.Text == "" || txt_passwordRegister.Text == "" || txt_usermailRegister.Text == "" || txt_usernameRegister.Text == "")
            {
                lbl_registerResultDanger.Text = "Text Boxes Cannot Be Empty!";
            }
            else
            {
                if (txt_passwordRegister.Text == txt_confirmPasswordRegister.Text)
                {
                    Repository<Party.DataAccess.Users> repo = new Repository<Party.DataAccess.Users>();
                    Repository<Party.DataAccess.Communities> repo2 = new Repository<DataAccess.Communities>();
                    Repository<Party.DataAccess.UsersCommunity> repo3 = new Repository<DataAccess.UsersCommunity>();
                    

                    DataAccess.Users newUser = new DataAccess.Users
                    {
                        UserMail = txt_usermailRegister.Text,
                        UsersStateID = 5,
                        UserName = txt_usernameRegister.Text,
                        UserPassword = txt_passwordRegister.Text
                    };

                    DataAccess.Communities newCommunity = new DataAccess.Communities
                    {
                        CommunityName = txt_usernameRegister.Text
                    };

                   

                    var checkUser = repo.Find(p => p.UserName == txt_usernameRegister.Text || p.UserMail == txt_usermailRegister.Text);
                    if (checkUser != null)
                    {
                        lbl_registerResultDanger.Text = "User Name or Mail is Already Taken.";
                    }
                    else
                    {
                        repo.Insert(newUser);
                        repo2.Insert(newCommunity);
                       
                        lbl_registerResultSuccess.Text = "Registration is successful.";

                        DataAccess.UsersCommunity newUserComm = new DataAccess.UsersCommunity
                        {
                            CommunityID = newCommunity.CommunityID,
                            UserID = newUser.UserID
                        };
                        repo3.Insert(newUserComm);

                    }

                    
                }
                else
                {
                    lbl_registerResultDanger.Text = "Confirmation Error!";
                }

            }
        }
    }
}
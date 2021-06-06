using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Party.Web
{
    public partial class ControlPanelEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connStr = ConfigurationManager.ConnectionStrings["ForumPartyConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(connStr);
                string sqlQuery = "select name from sys.tables";
                SqlCommand sqlComm = new SqlCommand(sqlQuery, conn);
                conn.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(sqlComm);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                DropDownList_TablesName.DataSource = dt;
                DropDownList_TablesName.DataTextField = "name";
                DropDownList_TablesName.DataValueField = "name";
                DropDownList_TablesName.DataBind();
                DropDownList_TablesName.Items.Insert(0, new ListItem("--Select a Table--", "0"));
                conn.Close();
            }
            

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

        protected void GridView_AboutUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView_AboutUsers.EditIndex = e.NewEditIndex;
            GridView_AboutUsers.DataSource = SqlDataSource1;
            GridView_AboutUsers.DataBind();
            lbl_result.Text = "";
            GridView_AboutUsers.EditRowStyle.BackColor = System.Drawing.Color.Orange;
        }

        protected void GridView_AboutUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView_AboutUsers.EditIndex = -1;
            GridView_AboutUsers.DataSource = SqlDataSource1;
            GridView_AboutUsers.DataBind();
            lbl_result.Text = "";
        }

        protected void GridView_AboutUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label userInfoID = GridView_AboutUsers.Rows[e.RowIndex].FindControl("Label10") as Label;
            TextBox name = GridView_AboutUsers.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
            TextBox surname = GridView_AboutUsers.Rows[e.RowIndex].FindControl("TextBox2") as TextBox;
            TextBox phone = GridView_AboutUsers.Rows[e.RowIndex].FindControl("TextBox3") as TextBox;
            TextBox aboutme = GridView_AboutUsers.Rows[e.RowIndex].FindControl("TextBox4") as TextBox;

            string connStr = ConfigurationManager.ConnectionStrings["ForumPartyConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sqlQuery = "Update AboutUsers set Name='" + name.Text + "', SurName='" + surname.Text + "'," +
                " Phone='" + phone.Text + "', AboutMe='" + aboutme.Text + "' Where UsersInfoID='" + userInfoID.Text + "' ";
            SqlCommand sqlComm = new SqlCommand(sqlQuery, conn);
            sqlComm.CommandText = sqlQuery;
            sqlComm.ExecuteNonQuery();
            lbl_result.Text = "Row Data Has Been Updated Successfully";
            GridView_AboutUsers.EditIndex = -1;
            SqlDataSource1.DataBind();
            GridView_AboutUsers.DataSource = SqlDataSource1;
            GridView_AboutUsers.DataBind();
            conn.Close();

        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {

            TextBox name = GridView_AboutUsers.FooterRow.FindControl("TextBox5") as TextBox;
            TextBox surname = GridView_AboutUsers.FooterRow.FindControl("TextBox6") as TextBox;
            TextBox phone = GridView_AboutUsers.FooterRow.FindControl("TextBox7") as TextBox;
            TextBox aboutme = GridView_AboutUsers.FooterRow.FindControl("TextBox8") as TextBox;

            string connStr = ConfigurationManager.ConnectionStrings["ForumPartyConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sqlQuery = "insert into AboutUsers(Name,SurName,Phone,AboutMe) values('" + name.Text + "','" + surname.Text + "','" + phone.Text + "','" + aboutme.Text + "')";
            SqlCommand sqlComm = new SqlCommand(sqlQuery, conn);
            sqlComm.CommandText = sqlQuery;
            sqlComm.ExecuteNonQuery();
            lbl_result.Text = "Row Data Has Been Insert Successfully";
            GridView_AboutUsers.EditIndex = -1;
            SqlDataSource1.DataBind();
            GridView_AboutUsers.DataSource = SqlDataSource1;
            GridView_AboutUsers.DataBind();
            conn.Close();
        }

        protected void GridView_AboutUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label userInfoID = GridView_AboutUsers.Rows[e.RowIndex].FindControl("Label1") as Label;

            string connStr = ConfigurationManager.ConnectionStrings["ForumPartyConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sqlQuery = "Delete From AboutUsers Where UsersInfoID='" + userInfoID.Text + "' ";
            SqlCommand sqlComm = new SqlCommand(sqlQuery, conn);
            sqlComm.CommandText = sqlQuery;
            sqlComm.ExecuteNonQuery();
            lbl_result.Text = "Row Data Has Been Deleted Successfully";
            GridView_AboutUsers.EditIndex = -1;
            SqlDataSource1.DataBind();
            GridView_AboutUsers.DataSource = SqlDataSource1;
            GridView_AboutUsers.DataBind();
            conn.Close();
        }


        protected void DropDownList_TablesName_TextChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                GridView10_Users.Visible = false;
                GridView_AboutUsers.Visible = false;
                if (DropDownList_TablesName.SelectedItem.Text.ToString() == "AboutUsers")
                {
                    GridView_AboutUsers.Visible = true;
                    GridView_AboutUsers.DataSource = SqlDataSource1;
                    GridView_AboutUsers.DataBind();
                }
                else if (DropDownList_TablesName.SelectedItem.Text.ToString() == "Users")
                {
                    GridView10_Users.Visible = true;
                    GridView10_Users.DataSource = SqlDataSource2;
                    GridView10_Users.DataBind();
                }
                else
                {
                    lbl_result.Text = "Please Select a Table!";
                }
            }
           


        }

        protected void GridView10_Users_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView10_Users.EditIndex = e.NewEditIndex;
            GridView10_Users.DataSource = SqlDataSource2;
            GridView10_Users.DataBind();
            lbl_result.Text = "";
            GridView10_Users.EditRowStyle.BackColor = System.Drawing.Color.Orange;
        }

        protected void GridView10_Users_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label userID = GridView10_Users.Rows[e.RowIndex].FindControl("Label20") as Label;
            TextBox userName = GridView10_Users.Rows[e.RowIndex].FindControl("TextBox9") as TextBox;
            TextBox userPassword = GridView10_Users.Rows[e.RowIndex].FindControl("TextBox10") as TextBox;
            TextBox userMail = GridView10_Users.Rows[e.RowIndex].FindControl("TextBox11") as TextBox;
            DropDownList usersStateID = GridView10_Users.Rows[e.RowIndex].FindControl("DropDownList2") as DropDownList;
            int stateID = Convert.ToInt32(usersStateID.SelectedItem.Value.ToString());
            string connStr = ConfigurationManager.ConnectionStrings["ForumPartyConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sqlQuery = "Update Users set UserName='" + userName.Text + "', UserPassword='" + userPassword.Text + "'," +
                " UserMail='" + userMail.Text + "', UsersStateID='" + stateID + "' where UserID='" + userID.Text+"' ";
            SqlCommand sqlComm = new SqlCommand(sqlQuery, conn);
            sqlComm.CommandText = sqlQuery;
            sqlComm.ExecuteNonQuery();
            lbl_result.Text = "Row Data Has Been Updated Successfully";
            GridView10_Users.EditIndex = -1;
            SqlDataSource2.DataBind();
            GridView10_Users.DataSource = SqlDataSource2;
            GridView10_Users.DataBind();
            conn.Close();
        }

        protected void GridView10_Users_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView10_Users.EditIndex = -1;
            GridView10_Users.DataSource = SqlDataSource2;
            GridView10_Users.DataBind();
            lbl_result.Text = "";
        }

        protected void GridView10_Users_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label userID = GridView10_Users.Rows[e.RowIndex].FindControl("Label15") as Label;
            string connStr = ConfigurationManager.ConnectionStrings["ForumPartyConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sqlQuery = "Delete From Users Where UserID='" + userID.Text + "' ";
            SqlCommand sqlComm = new SqlCommand(sqlQuery, conn);
            sqlComm.CommandText = sqlQuery;
            sqlComm.ExecuteNonQuery();
            lbl_result.Text = "Row Data Has Been Deleted Successfully";
            GridView10_Users.EditIndex = -1;
            SqlDataSource2.DataBind();
            GridView10_Users.DataSource = SqlDataSource2;
            GridView10_Users.DataBind();
            conn.Close();
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            
            Label userID = GridView10_Users.FooterRow.FindControl("Label20") as Label;
            TextBox userName = GridView10_Users.FooterRow.FindControl("TextBox12") as TextBox;
            TextBox userPassword = GridView10_Users.FooterRow.FindControl("TextBox13") as TextBox;
            TextBox userMail = GridView10_Users.FooterRow.FindControl("TextBox14") as TextBox;
            DropDownList usersStateID = GridView10_Users.FooterRow.FindControl("DropDownList1") as DropDownList;

            int drpID = int.Parse(usersStateID.SelectedValue.ToString());
            string connStr = ConfigurationManager.ConnectionStrings["ForumPartyConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            
            string sqlQuery = "insert into Users(UserName,UserPassword,UserMail,UsersStateID)  values('" + userName.Text + "','" + userPassword.Text + "'," +
                " '" + userMail.Text + "', '" + drpID + "')";
            SqlCommand sqlComm = new SqlCommand(sqlQuery, conn);
            sqlComm.CommandText = sqlQuery;
            sqlComm.ExecuteNonQuery();
            lbl_result.Text = "Row Data Has Been Updated Successfully";
            GridView10_Users.EditIndex = -1;
            SqlDataSource2.DataBind();
            GridView10_Users.DataSource = SqlDataSource2;
            GridView10_Users.DataBind();
            conn.Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Party.Web
{
    public partial class DataTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //int[] sayilar =new int []{ 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ////QUERY
            //var sonuc = from sayi in sayilar where sayi > 5 select sayi;
            //foreach (var item in sonuc)
            //{
            //    lst_box.Items.Add(item.ToString());
            //}

            ////Method
            //List<int> sonuc1 = sayilar.Where(p => p %2==0).ToList();

            //foreach (var item in sonuc1)
            //{
            //    lst_box2.Items.Add(item.ToString());
            //}

            string baglanti = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ForumPartyConnectionString"].ConnectionString;
            SqlConnection baglan = new SqlConnection(baglanti);

            //string sorgu = "insert into Users values('Asli','asfkposa213','Test@mail.com','5')";
            string sorgu2 = "update Users set UsersStateID=1 Where  UserID=1";
            //string sorgu3 = "delete from Users Where UserID=3";
            baglan.Open();
            SqlCommand com1 = new SqlCommand(sorgu2, baglan);
            var deger1 = com1.ExecuteNonQuery();
        }

        protected void textInput_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button_Click(object sender, EventArgs e)
        {
            ListItem deger = new ListItem();
            deger.Text = textInput.Text;
            deger.Value = new Random().Next(1, 100).ToString();
            drp_liste.Items.Add(deger);
        }

        protected void drp_liste_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = "Selected Value: "+drp_liste.SelectedValue+ "\n Selected Item: "+drp_liste.SelectedItem.Text;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Party.Business.Users nesne = new Business.Users();
            //var sonuc = nesne.GetByUseName("userTest");
            //GridView1.DataSource = sonuc;
            //GridView1.DataBind();
           

            Party.Business.Users yeniVeri = new Business.Users();
            Party.DataAccess.Users nesne = new DataAccess.Users();
            nesne.UserName = FakeData.NameData.GetFirstName();
            nesne.UserPassword = FakeData.TextData.GetAlphaNumeric(8);
            nesne.UserMail = FakeData.NetworkData.GetEmail();
            nesne.UsersStateID = 5;
            var deger = yeniVeri.AddData(nesne);


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Party.Business.Users veriGuncelle = new Business.Users();

            Party.DataAccess.Users nesne2 = new DataAccess.Users();
            nesne2.UserName = FakeData.NameData.GetFirstName();
            nesne2.UserPassword = FakeData.TextData.GetAlphaNumeric(8);
            nesne2.UserMail = FakeData.NetworkData.GetEmail();  
            nesne2.UsersStateID = 5;
            var sonuc = veriGuncelle.UpdateData(Convert.ToInt32(Text_UserID.Text), nesne2);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Party.Business.Users veriSil = new Business.Users();

            var sonuc = veriSil.DeleteData(Convert.ToInt32(Text_UserID.Text));
        }
    }
}
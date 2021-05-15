using Party.Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Party.Web
{
    public partial class AboutUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btn_Save_Click(object sender, EventArgs e)
        {
            
            if (txt_aboutMe.Text != "" && txt_phone.Text != "" && txt_surname.Text != "" && txt_name.Text != "" )
            {
                HttpPostedFile postedFile = profileImageUpload.PostedFile;
                if (profileImageUpload.HasFile)
                {

                    string fileName = Path.GetFileName(postedFile.FileName);
                    string fileExt = Path.GetExtension(fileName);
                    if (fileExt.ToLower() == ".jpg" || fileExt.ToLower() == ".bpmp" ||
                        fileExt.ToLower() == ".png" || fileExt.ToLower() == ".gif")
                    {
                       


                        byte[] bytes = null;
                        Stream stream = postedFile.InputStream;
                        BinaryReader binaryReader = new BinaryReader(stream);
                        bytes = binaryReader.ReadBytes((int)stream.Length);


                        int getID = Convert.ToInt32(Session["UserID"].ToString());



                        Repository<DataAccess.AboutUsers> repo = new Repository<DataAccess.AboutUsers>();
                        DataAccess.AboutUsers userInfo = new DataAccess.AboutUsers()
                        {
                            ProfilImage = bytes,
                            Name = txt_name.Text,
                            SurName=txt_surname.Text,
                            Phone=txt_phone.Text,
                            AboutMe=txt_aboutMe.Text,
                            UserID=getID
                        };

                        repo.Insert(userInfo);


                        Repository<DataAccess.Adress> repo2 = new Repository<DataAccess.Adress>();
                        DataAccess.Adress userAddress = new DataAccess.Adress()
                        {
                            Road=txt_road.Text,
                            Street=txt_street.Text,
                            Neighborhood=txt_neighbor.Text,
                            ApartmenNo=txt_aptNo.Text,
                            Floor=txt_floor.Text,
                            District=txt_District.Text,
                            Province=txt_province.Text
                        };

                        repo2.Insert(userAddress);
                       

                    }
                    else
                    {
                        lbl_result.Text = "Please fill in the fields!";
                    }


                }



            }
            

        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {

        }
    }
}
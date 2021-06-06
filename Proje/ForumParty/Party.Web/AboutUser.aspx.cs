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
            int getID = Convert.ToInt32(Session["UserID"].ToString());
            if (txt_aptNo.Text!="" && txt_District.Text!="" && txt_floor.Text!="" && txt_neighbor.Text!="" && txt_province.Text!="" &&
                txt_road.Text!="" && txt_street.Text != "")
            {
                Repository<DataAccess.Adress> repo2 = new Repository<DataAccess.Adress>();
                var result2 = repo2.Find(x => x.UserID == getID);
                result2.Road = txt_road.Text.ToString();
                result2.Street = txt_street.Text.ToString();
                result2.Neighborhood = txt_neighbor.Text.ToString();
                result2.ApartmenNo = txt_aptNo.Text.ToString();
                result2.Floor = txt_floor.Text.ToString();
                result2.District = txt_District.Text.ToString();
                result2.Province = txt_province.Text.ToString();

                repo2.Update(result2);
                lbl_result.Text = "Successfully Saved!";
            }
            else
            {
                lbl_result.Text = "Please fill in the fields!";
            }
            

        }



        protected void btn_SaveProfile_Click(object sender, EventArgs e)
        {
            if (txt_aboutMe.Text != "" && txt_phone.Text != "" && txt_surname.Text != "" && txt_name.Text != "")
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

                        var result = repo.Find(x => x.UserID == getID);
                        result.Name = txt_name.Text;
                        result.ProfilImage = bytes;
                        result.SurName = txt_surname.Text;
                        result.Phone = txt_phone.Text;
                        result.AboutMe = txt_aboutMe.Text;
                        repo.Update(result);
                        lbl_result.Text = "Successfully Saved!";
                    }
                    else
                    {
                        lbl_result.Text = "Please fill in the fields!";
                    }

                }
            }
        }
    }
}
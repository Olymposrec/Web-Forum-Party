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
    public partial class AddPostPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int getID = Convert.ToInt32(value: Session["UserID"]);
            DataAccess.ForumPartyEntities1 data = new DataAccess.ForumPartyEntities1();
            var result = (from p in data.UsersCommunity
                          from c in data.Users
                          from u in data.Communities
                          where c.UserID== getID && u.CommunityID==p.CommunityID && c.UserID==p.UserID
                          select new
                          {
                              u.CommunityName,
                              u.CommunityID
                          }).ToList();

            drp_community.DataSource = result; 
            drp_community.DataTextField = "CommunityName";
            drp_community.DataValueField = "CommunityID";
            drp_community.DataBind();
            //drp_community
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {


            if (txt_description.Text != "" && txt_title.Text != "")
            {
                HttpPostedFile postedFile = imageUpload.PostedFile;
                if (imageUpload.HasFile)
                {
                    
                    string fileName = Path.GetFileName(postedFile.FileName);
                    string fileExt = Path.GetExtension(fileName);
                    if (fileExt.ToLower() == ".jpg" || fileExt.ToLower() == ".bpmp" ||
                        fileExt.ToLower() == ".png" || fileExt.ToLower() == ".gif")
                    {
                        int privacyID;
                        if (RadioButton1.Checked)
                        {
                            privacyID = 1;
                        }
                        else
                            privacyID = 2;


                        byte[] bytes = null;
                        Stream stream = postedFile.InputStream;
                        BinaryReader binaryReader = new BinaryReader(stream);
                        bytes = binaryReader.ReadBytes((int)stream.Length);


                        int getID = Convert.ToInt32(Session["UserID"].ToString());



                        Repository<DataAccess.Posts> repo = new Repository<DataAccess.Posts>();
                        DataAccess.Posts post = new DataAccess.Posts
                        {
                            UserID = getID,
                            CategoryID = Convert.ToInt32(drp_category.SelectedItem.Value.ToString()),
                            Title = txt_title.Text.ToString(),
                            Description = txt_description.Text.ToString(),
                            PrivacyID = privacyID,
                            UploadDate = DateTime.Today.ToShortDateString(),
                            PostImage= bytes,
                            Like=0,
                            CommunityID = Convert.ToInt32(drp_community.SelectedValue.ToString())
                        };

                        repo.Insert(post);

                        Response.Redirect("/Profile/"+Session["UserName"].ToString());

                    }
                    else
                    {
                        lbl_result.Text = "You have to upload jpg or png file Only!";
                    }


                }



            }


        }
    }
}
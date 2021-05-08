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

        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {

           
            if (txt_description.Text != "" && txt_title.Text != "")
            {

                if (imageUpload.HasFile)
                {
                    string fileName = Path.GetFileName(imageUpload.FileName);
                    string imagePath = Path.Combine(Server.MapPath("/Images/"), fileName);
                    imageUpload.SaveAs(imagePath);

                }
                //if ()
                //{
                   

                //    if (ext == ".jpg" || ext == ".png")
                //    {
                       


                //    }
                //    else
                //    {
                //        lbl_result.Text = "You have to upload jpg or png file Only!";
                //    }
                //    //Repository<DataAccess.Posts> repo_newPost = new Repository<DataAccess.Posts>();
                //    //DataAccess.Posts newPostData = new DataAccess.Posts
                //    //{
                //    //    Title = txt_title.Text,
                //    //    Description = txt_description.Text,
                //    //    UploadDate = DateTime.Today.ToString(),
                //    //    CommunityID = Convert.ToInt32(drp_community.SelectedItem.Value),
                //    //    PostImage = name.ToString()


                //    //};
                //}
            }


        }
    }
}
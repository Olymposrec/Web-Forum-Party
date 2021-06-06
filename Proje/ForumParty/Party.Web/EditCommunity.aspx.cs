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
    public partial class EditCommunity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int getID = Convert.ToInt32(value: Session["UserID"]);
                DataAccess.ForumPartyEntities1 data = new DataAccess.ForumPartyEntities1();
                var result = (from p in data.UsersCommunity
                              where p.UserID == getID && p.CommunityStateID == 1
                              select new
                              {
                                  CommunityName = p.Communities.CommunityName,
                                  CommunityID = p.Communities.CommunityID
                              }).ToList();

                drp_community.DataSource = result;
                drp_community.DataTextField = "CommunityName";
                drp_community.DataValueField = "CommunityID";
                drp_community.DataBind();
                drp_community.Items.Insert(0, new ListItem("Select One","NA"));

            }
        }

        protected void update_Btn_Click(object sender, EventArgs e)
        {

            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
            TextBox txt_Name = item.FindControl("txt_communityName") as TextBox;
            TextBox txt_Description = item.FindControl("txt_description") as TextBox;
            FileUpload file_Upload = item.FindControl("imageUpload") as FileUpload;
            //int getID = Convert.ToInt32(Session["UserID"].ToString());
            string comName = txt_Name.Text.ToString();
            string comDescrip = txt_Description.Text.ToString();

            if (comName != "" && comDescrip != "")
            {
                HttpPostedFile postedFile = file_Upload.PostedFile;
                if (file_Upload.HasFile)
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


                        int comId = Convert.ToInt32(drp_community.SelectedItem.Value.ToString());
                        Repository<DataAccess.Communities> repo = new Repository<DataAccess.Communities>();
                        var result = repo.Find(x => x.CommunityID == comId);
                        result.CommunityImage = bytes;
                        result.CommunityName = comName;
                        result.Description = comDescrip;
                        repo.Update(result);

                        lbl_result.Text = "Successfully Updated!";

                    }
                    else
                    {
                        lbl_result.Text = "You have to upload jpg or png file Only!";
                    }


                }
                else
                {
                    int comId = Convert.ToInt32(drp_community.SelectedItem.Value.ToString());
                    Repository<DataAccess.Communities> repo = new Repository<DataAccess.Communities>();
                    var result = repo.Find(x => x.CommunityID == comId);
                    result.CommunityImage = null;
                    result.CommunityName = comName;
                    result.Description = comDescrip;
                    repo.Update(result);

                    lbl_result.Text = "Successfully Saved!";
                }



            }
        }

        protected void create_Btn_Click(object sender, EventArgs e)
        {
            Repository<DataAccess.Communities> repo = new Repository<DataAccess.Communities>();
            var result = repo.Find(x => x.CommunityName == txt_communityName.Text.ToString());
            if (result == null)
            {
                if (txt_communityName.Text != "" && txt_description.Text != "")
                {
                    HttpPostedFile postedFile = imageUpload.PostedFile;
                    if (imageUpload.HasFile)
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

                            Repository<DataAccess.Communities> newComm = new Repository<DataAccess.Communities>();

                            DataAccess.Communities commValues = new DataAccess.Communities()
                            {
                                CommunityImage = bytes,
                                CommunityName = txt_communityName.Text.ToString(),
                                Description = txt_description.Text.ToString(),
                                MembersCount = 1
                            };

                            newComm.Insert(commValues);

                            int value = Convert.ToInt32(Session["UserID"].ToString());

                            Repository<DataAccess.UsersCommunity> repo2 = new Repository<DataAccess.UsersCommunity>();

                            DataAccess.UsersCommunity newUser = new DataAccess.UsersCommunity()
                            {
                                CommunityID = commValues.CommunityID,
                                UserID = value,
                                CommunityStateID=1
                            };

                            repo2.Insert(newUser);

                            lbl_result.Text = "Successfully Created!";

                        }
                        else
                        {
                            lbl_result.Text = "You have to upload jpg or png file Only!";
                        }


                    }
                    else
                    {
                        Repository<DataAccess.Communities> newComm = new Repository<DataAccess.Communities>();

                        DataAccess.Communities commValues = new DataAccess.Communities()
                        {
                            CommunityImage = null,
                            CommunityName = txt_communityName.Text.ToString(),
                            Description = txt_description.Text.ToString(),
                            MembersCount = 1
                        };

                        newComm.Insert(commValues);


                        int value = Convert.ToInt32(Session["UserID"].ToString());
                        Repository<DataAccess.UsersCommunity> repo2 = new Repository<DataAccess.UsersCommunity>();

                        DataAccess.UsersCommunity newUser = new DataAccess.UsersCommunity()
                        {
                            CommunityID = commValues.CommunityID,
                            UserID = value,
                            CommunityStateID=1
                        };

                        repo2.Insert(newUser);

                        lbl_result.Text = "Successfully Created!";
                    }
                }
            }
            else
            {
                lbl_result.Text = "Invalid Community Name.";
            }
        }


        protected void drp_community_TextChanged(object sender, EventArgs e)
        {
            string communityName = drp_community.SelectedItem.Text.ToString();
            

            if(drp_community.SelectedItem.Text.ToString()!="Select One")
            {
                int communityID = Convert.ToInt32(drp_community.SelectedItem.Value.ToString());
                DataAccess.ForumPartyEntities1 commInfo = new DataAccess.ForumPartyEntities1();

                var result = (from p in commInfo.Communities
                              where p.CommunityName == communityName && p.CommunityID == communityID
                              select new
                              {
                                  CommunityName = p.CommunityName,
                                  CommunityDescription = p.Description
                              }).ToList();

                Repeater_comm.DataSource = result;
                Repeater_comm.DataBind();
            }
            else
            {
                
                DataAccess.ForumPartyEntities1 commInfo = new DataAccess.ForumPartyEntities1();

                var result = (from p in commInfo.Communities
                              where p.CommunityName == communityName && p.CommunityID == -1
                              select new
                              {
                                  CommunityName = p.CommunityName,
                                  CommunityDescription = p.Description
                              }).ToList();

                Repeater_comm.DataSource = result;
                Repeater_comm.DataBind();
            }
            

        }

        protected void delete_Btn_Click(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace Party.Web.WebService
{
    /// <summary>
    /// Summary description for AdminPanelService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AdminPanelService : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetPostData(int pageNumber, int pageSize)
        {
            List<DataAccess.Posts> newListPosts = new List<DataAccess.Posts>();



            string cs = ConfigurationManager.ConnectionStrings["ForumPartyConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetPosts", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@PageNumber",
                    Value = pageNumber
                });

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@PageSize",
                    Value = pageSize
                });

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    DataAccess.Posts newData = new DataAccess.Posts();
                    newData.PostID = int.Parse(rdr["PostID"].ToString());
                    newData.UserID = int.Parse(rdr["UserID"].ToString());
                    newData.CategoryID = int.Parse(rdr["CategoryID"].ToString());
                    newData.Title = rdr["Title"].ToString();
                    newData.Description = rdr["Description"].ToString();
                    newData.PrivacyID = int.Parse(rdr["PrivacyID"].ToString());
                    newData.UploadDate = rdr["UploadDate"].ToString();
                    newData.Like = int.Parse(rdr["Like"].ToString());
                    newData.CommunityID = int.Parse(rdr["CommunityID"].ToString());
                    //newData.PostImage = (byte[])rdr["PostImage"];
                        
                    newListPosts.Add(newData);


                }

                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(newListPosts));
            }
        }
    }
}

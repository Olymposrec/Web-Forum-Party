using Party.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Party.Web
{
    public partial class PollsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("/LogInPage");
            }
            else
            {
                DataAccess.ForumPartyEntities1 communitiesList = new DataAccess.ForumPartyEntities1();

                var result = (from p in communitiesList.Communities
                              select new
                              {
                                  CommuntiyImage = p.CommunityImage,
                                  CommunityName = p.CommunityName,
                                  CommunityID = p.CommunityID,
                                  MembersCount = p.MembersCount
                              }).ToList();

                Repeater1.DataSource = result;
                Repeater1.DataBind();
            }
           

            
        }

        protected void Unnamed1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }



        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            Label commName = (Label)e.Item.FindControl("Label2");
            Label commID = (Label)e.Item.FindControl("Label1");
            int userPerm = Convert.ToInt32(Session["UserID"].ToString());


            int commIDValue = Convert.ToInt32(commID.Text.ToString());

            DataAccess.ForumPartyEntities1 perm = new DataAccess.ForumPartyEntities1();
            var permResult = (from p in perm.UsersCommunity
                              where p.UserID == userPerm && p.CommunityID == commIDValue
                              select new
                              {
                                  CommunityStateID = p.CommunityStateID
                              }).FirstOrDefault();
            LinkButton btn_join = (LinkButton)e.Item.FindControl("lb_JoinCommunity");
            if (permResult != null)
            {
                int userPrmRes = int.Parse(permResult.CommunityStateID.ToString());
                if (userPrmRes == 2)
                {
                    btn_join.Text = "Joined";
                }
                else if (userPrmRes == 1)
                {
                    btn_join.Text = "Founder";
                    btn_join.Enabled = false;
                }
                else if (userPrmRes == 3)
                {
                    btn_join.Text = "Joined";
                    btn_join.Enabled = true;
                }
            }
            else
            {
                btn_join.Text = "Join";
                btn_join.Enabled = true;
            }
        }

        protected void lb_JoinCommunity_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            Label commName = item.FindControl("Label2") as Label;
            Label commID = item.FindControl("Label1") as Label;
            string commNameValue = commName.Text.ToString();
            if (Session["UserName"] != null)
            {
                int userPerm = Convert.ToInt32(Session["UserID"].ToString());
                int commIDValue = Convert.ToInt32(commID.Text.ToString());
                DataAccess.ForumPartyEntities1 perm = new DataAccess.ForumPartyEntities1();
                var permResult = (from p in perm.UsersCommunity
                                  where p.UserID == userPerm && p.CommunityID == commIDValue
                                  select new
                                  {
                                      CommunityStateID = p.CommunityStateID
                                  }).FirstOrDefault();
                if (permResult == null)
                {
                    
                    Repository<DataAccess.Communities> data = new Repository<DataAccess.Communities>();

                    var result = data.Find(x => x.CommunityID == commIDValue);
                    result.MembersCount++;
                    data.Update(result);

                    Repository<DataAccess.UsersCommunity> repo = new Repository<DataAccess.UsersCommunity>();
                    int UserID = Convert.ToInt32(Session["UserID"].ToString());
                    DataAccess.UsersCommunity newUserComm = new DataAccess.UsersCommunity
                    {
                        CommunityID = commIDValue,
                        UserID = UserID,
                        CommunityStateID = 2
                    };
                    repo.Insert(newUserComm);

                    Response.Redirect("/Community/" + commIDValue + "/" + commNameValue);
                }
                else
                {
                   
                    Repository<DataAccess.Communities> data = new Repository<DataAccess.Communities>();

                    var result = data.Find(x => x.CommunityID == commIDValue);
                    result.MembersCount--;
                    data.Update(result);

                    int UserID = Convert.ToInt32(Session["UserID"].ToString());
                    Repository<DataAccess.UsersCommunity> repo = new Repository<DataAccess.UsersCommunity>();
                    var resul2 = repo.Find(x => x.CommunityID == commIDValue && x.UserID == UserID);
                    repo.Delete(resul2);
                    Response.Redirect("/Community/" + commIDValue + "/" + commNameValue);
                }

            }
            else
            {
                Response.Redirect("/LogInPage");
            }
        }

        protected void Repeater1_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            Label commName = item.FindControl("Label2") as Label;
            Label commID = item.FindControl("Label1") as Label;
            string commNameValue = commName.Text.ToString();
            int commIDValue = Convert.ToInt32(commID.Text.ToString());
            Response.Redirect("/Community/" + commIDValue + "/" + commNameValue);
        }
    }
}
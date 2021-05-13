﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Party.Web
{
    public class Global : System.Web.HttpApplication
    {
        void RouteCustom(RouteCollection route)
        {
            route.MapPageRoute("Detail","PostDetail/{PostID}/{UserID}","~/PostDetail.aspx");
        }
        void RouteOtherProfile(RouteCollection route)
        {
            route.MapPageRoute("ProfileGuest", "Profile/{UserID}/{UserName}", "~/ProfilPage.aspx");
        }
        void RouteProfile(RouteCollection route)
        {
            route.MapPageRoute("Profile", "Profile/{UserName}", "~/ProfilPage.aspx");
        }
        void RouteAppPostPage(RouteCollection route)
        {
            route.MapPageRoute("AddPost", "AddPost", "~/AddPostPage.aspx");
        }
        void RouteHomePage(RouteCollection route)
        {
            route.MapPageRoute("HomePage", "HomePage", "~/HomePage.aspx");
        }

        void RouteLogInPage(RouteCollection route)
        {
            route.MapPageRoute("LogInPage", "LogInPage", "~/LogInPage.aspx");
        }

        void RouteCategoryArea(RouteCollection route)
        {
            route.MapPageRoute("Category", "HomePage/{CategoryName}", "~/Homepage.aspx");
        }


        protected void Application_Start(object sender, EventArgs e)
        {
            RouteCustom(RouteTable.Routes);
            
            RouteProfile(RouteTable.Routes);

            RouteAppPostPage(RouteTable.Routes);

            RouteHomePage(RouteTable.Routes);

            RouteOtherProfile(RouteTable.Routes);

            RouteLogInPage(RouteTable.Routes);
            RouteCategoryArea(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
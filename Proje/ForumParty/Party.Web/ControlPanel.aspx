<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlPanel.aspx.cs" Inherits="Party.Web.ControlPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Party: Forum</title>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="Party is a forum site where communities come together. " />
    <meta name="author" content="Melih Akkose" />


    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
   

    <link href="Resource/css/blog-home.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.4.1/font/bootstrap-icons.css" />



    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
    <link href="Resource/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">




        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
            <div class="container mr-auto">
                <asp:LinkButton ID="HomePage_Click" runat="server" OnClick="HomePage_Click_Click" class="navbar-brand" type="button">
           <img width="25" height="25" class="rounded-circle" src="Resource/images/homepageLogo2.jpg" runat="server"/> <span class="navbar-brand mb-0 h1"> Party Forum</span>
                </asp:LinkButton>

                <div class="collapse navbar-collapse" id="navbarResponsive">

                    <ul class="navbar-nav ml-auto">
                        <li class="nav-item">
                            <asp:LinkButton ID="lnkbtn_ForumPage" runat="server" OnClick="lnkbtn_ForumPage_Click" class="navbar-brand" type="button"><i class="bi bi-archive-fill"></i> Forum</asp:LinkButton>

                        </li>
                        <li class="nav-item">
                            <asp:LinkButton ID="lnkbtn_CommunitiesPage" runat="server" OnClick="lnkbtn_CommunitiesPage_Click" class="navbar-brand" type="button"><i class="bi bi-border-width"></i> Communities</asp:LinkButton>
                            <a class="navbar-brand" href="#"></a>
                        </li>
                        <li class="nav-item">
                            <asp:LinkButton ID="lnkbtn_MessagePage" runat="server" OnClick="lnkbtn_MessagePage_Click" class="navbar-brand" type="button"><i class="bi bi-chat-left-text-fill"></i> Messages</asp:LinkButton>

                        </li>
                        <li class="nav-item">
                            <asp:LinkButton ID="lnkbtn_MainPage" runat="server" OnClick="lnkbtn_MainPage_Click" class="navbar-brand" type="button"><i class="bi bi-person-circle"></i> Profil</asp:LinkButton>

                        </li>
                    </ul>
                    <ul class="navbar-nav ml-auto">
                        <li class="nav-item">
                            <asp:LinkButton ID="btn_login" runat="server" OnClick="btn_login_Click" class="navbar-brand" type="button"><i class="bi bi-box-arrow-right"></i> Log In</asp:LinkButton>
                        </li>
                        <li class="nav-item">
                            <asp:Label ID="lbl_session" runat="server" type="text" class="navbar-brand text-primary"></asp:Label>
                        </li>
                        <li class="nav-item">
                            <asp:LinkButton ID="btn_logout" runat="server" OnClick="btn_logout_Click" class="navbar-brand" type="button"><i class="bi bi-box-arrow-left"></i> Log Out</asp:LinkButton>
                        </li>
                    </ul>
                </div>


            </div>
        </nav>
        <header class="modal-header" style="margin-bottom: 50px; height: max-content;">
            <!-- Search Widget -->
            <div class="container">
                <div class="card-body">
                    <div class="input-group">
                        <asp:TextBox ID="txt_search" runat="server" class="form-control" placeholder="Search for..."></asp:TextBox>
                        <span class="input-group-append">
                            <asp:LinkButton ID="SearchData_Click" runat="server" class="btn btn-secondary" type="button" OnClick="SearchData_Click_Click"><i class="bi bi-search"></i></asp:LinkButton>
                            <asp:LinkButton ID="AddPost_Click" runat="server" class="btn btn-secondary" type="button" OnClick="AddPost_Click_Click"><i class="bi bi-archive-fill"></i></asp:LinkButton>
                            <asp:LinkButton ID="CreateCommunity_Click" runat="server" class="btn btn-secondary" type="button" OnClick="CreateCommunity_Click_Click"><i class="bi bi-border-width"></i></asp:LinkButton>
                        </span>
                    </div>
                </div>
            </div>
        </header>


        <asp:Button ID="btn_RouteEditPanel" OnClick="btn_RouteEditPanel_Click" runat="server" Text="GO TO EDİT PANEL" class="btn btn-primary btn btn-default btn-block" />

      

     <script src=' <%=ResolveUrl("~/Scripts/jquery-3.6.0.min.js") %>'>  </script>
     <script type="text/javascript">
         $(document).ready(function () {
             var currentPageNumber = 1;
             loadData(currentPageNumber);

             $(window).scroll(function () {

                 if ($(window).scrollTop() == $(document).height() - $(window).height()) {

                     currentPageNumber += 1;
                     loadData(currentPageNumber);

                 }

             });

             function loadData(currentPage) {
                 $.ajax({
                     url: '/WebService/AdminPanelService.asmx/GetPostData',
                     method: 'post',
                     data: { pageNumber: currentPage, pageSize: 8 },
                     dataType: 'json',
                     success: function (data) {
                         var postTable = $('#tbPost tbody');

                         $(data).each(function (index, post) {
                             postTable.append('<tr><td>' + post.PostID  +'</td><td>' +
                                 post.UserID + '</td><td>' + post.CategoryID + '</td><td>' +
                                 post.Title + '</td><td>' + post.Description + '</td><td>' +
                                 post.PrivacyID + '</td><td>' + post.UploadDate + '</td><td>' +
                                 post.Like + '</td><td>' + post.CommunityID +  '</td></tr>');
                         })
                     }
                 });
             }
         });
     </script>
       
    <h2>Sayfa Aşağıya Kaydıkça Veri Yükleme Alanı (Test)</h2>
    <table id="tbPost" class="table table-dark">
        <thead>
            <tr>
                <th scope="col">PostID</th>
                <th scope="col">UserID</th>
                <th scope="col">CategoryID</th>
                <th scope="col">Title</th>
                <th scope="col">Description</th>
                <th scope="col">PrivacyID</th>
                <th scope="col">UploadDate</th>
                <th scope="col">Like</th>
                <th scope="col">CommunityID</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>


</form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlPanelEdit.aspx.cs" Inherits="Party.Web.ControlPanelEdit" %>

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
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
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
                        <li class="nav-item">
                            <asp:LinkButton ID="lb_AdminPanel" runat="server" OnClick="lb_AdminPanel_Click" class="navbar-brand" type="button"><i class="bi bi-gear-fill"></i> Control Panel</asp:LinkButton>

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


        <asp:DropDownList ID="DropDownList_TablesName" runat="server" class="custom-select" OnTextChanged="DropDownList_TablesName_TextChanged" AutoPostBack="True"></asp:DropDownList>

        <div class="auto-style1">

            <asp:GridView ID="GridView_AboutUsers" runat="server" class="table table-bordered table-condensed table-responsive table-hover " AutoGenerateColumns="False" ShowFooter="True" OnRowCancelingEdit="GridView_AboutUsers_RowCancelingEdit" OnRowEditing="GridView_AboutUsers_RowEditing" OnRowUpdating="GridView_AboutUsers_RowUpdating" OnRowDeleting="GridView_AboutUsers_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="User Info ID">
                        <EditItemTemplate>
                            <asp:Label ID="Label10" runat="server" Text='<%# Eval("UsersInfoID") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("UsersInfoID") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="User ID">
                        <ItemTemplate>
                            <asp:Label ID="Label13" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SurName">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("SurName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("SurName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phone">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("Phone") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("Phone") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address ID">
                        <EditItemTemplate>
                            <asp:Label ID="Label11" runat="server" Text='<%# Eval("AddressID") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label14" runat="server" Text='<%# Eval("AddressID") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Image Binary">
                        <EditItemTemplate>
                            <asp:Label ID="Label12" runat="server" Text='<%# Eval("ProfilImage") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("ProfilImage") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="About Me">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("AboutMe") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("AboutMe") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Operations">
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Update">Update</asp:LinkButton>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">Insert</asp:LinkButton>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit">Edit</asp:LinkButton>
                            &nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete">Delete</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ForumPartyConnectionString %>" DeleteCommand="DELETE FROM [AboutUsers] WHERE [UsersInfoID] = @UsersInfoID" InsertCommand="INSERT INTO [AboutUsers] ([UserID], [Name], [SurName], [Phone], [AddressID], [ProfilImage], [AboutMe]) VALUES (@UserID, @Name, @SurName, @Phone, @AddressID, @ProfilImage, @AboutMe)" SelectCommand="SELECT * FROM [AboutUsers]" UpdateCommand="UPDATE [AboutUsers] SET [UserID] = @UserID, [Name] = @Name, [SurName] = @SurName, [Phone] = @Phone, [AddressID] = @AddressID, [ProfilImage] = @ProfilImage, [AboutMe] = @AboutMe WHERE [UsersInfoID] = @UsersInfoID">
            <DeleteParameters>
                <asp:Parameter Name="UsersInfoID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="UserID" Type="Int32" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="SurName" Type="String" />
                <asp:Parameter Name="Phone" Type="String" />
                <asp:Parameter Name="AddressID" Type="Int32" />
                <asp:Parameter Name="ProfilImage" Type="Object" />
                <asp:Parameter Name="AboutMe" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="UserID" Type="Int32" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="SurName" Type="String" />
                <asp:Parameter Name="Phone" Type="String" />
                <asp:Parameter Name="AddressID" Type="Int32" />
                <asp:Parameter Name="ProfilImage" Type="Object" />
                <asp:Parameter Name="AboutMe" Type="String" />
                <asp:Parameter Name="UsersInfoID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>



        <asp:GridView ID="GridView10_Users" runat="server" Width="100%" class="table table-bordered table-condensed table-responsive table-hover " AutoGenerateColumns="False" Height="229px" OnRowCancelingEdit="GridView10_Users_RowCancelingEdit" OnRowDeleting="GridView10_Users_RowDeleting" OnRowEditing="GridView10_Users_RowEditing" OnRowUpdating="GridView10_Users_RowUpdating" ShowFooter="True">
            <Columns>
                <asp:TemplateField HeaderText="UserID">
                    <EditItemTemplate>
                        <asp:Label ID="Label20" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label15" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UserName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Eval("UserName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label16" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UserPassword">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Eval("UserPassword") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label17" runat="server" Text='<%# Eval("UserPassword") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UserMail">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox11" runat="server" Text='<%# Eval("UserMail") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label18" runat="server" Text='<%# Eval("UserMail") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UsersStateID">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource3" DataTextField="StateName" DataValueField="UserStateID">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ForumPartyConnectionString %>" SelectCommand="SELECT * FROM [UsersState]"></asp:SqlDataSource>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="StateName" DataValueField="UserStateID">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ForumPartyConnectionString %>" DeleteCommand="DELETE FROM [UsersState] WHERE [UserStateID] = @UserStateID" InsertCommand="INSERT INTO [UsersState] ([StateName]) VALUES (@StateName)" SelectCommand="SELECT * FROM [UsersState]" UpdateCommand="UPDATE [UsersState] SET [StateName] = @StateName WHERE [UserStateID] = @UserStateID">
                            <DeleteParameters>
                                <asp:Parameter Name="UserStateID" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="StateName" Type="String" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="StateName" Type="String" />
                                <asp:Parameter Name="UserStateID" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label19" runat="server" Text='<%# Eval("UsersStateID") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Options">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton8" runat="server" CommandName="Update">Update</asp:LinkButton>
                        &nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="LinkButton9" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:LinkButton ID="LinkButton10" runat="server" CommandName="Insert" OnClick="LinkButton10_Click">Insert</asp:LinkButton>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton6" runat="server" CommandName="Edit">Edit</asp:LinkButton>
                        &nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="LinkButton7" runat="server" CommandName="Delete">Delete</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ForumPartyConnectionString %>" DeleteCommand="DELETE FROM [Users] WHERE [UserID] = @UserID" InsertCommand="INSERT INTO [Users] ([UserName], [UserPassword], [UserMail], [UsersStateID]) VALUES (@UserName, @UserPassword, @UserMail, @UsersStateID)" SelectCommand="SELECT * FROM [Users]" UpdateCommand="UPDATE [Users] SET [UserName] = @UserName, [UserPassword] = @UserPassword, [UserMail] = @UserMail, [UsersStateID] = @UsersStateID WHERE [UserID] = @UserID">
            <DeleteParameters>
                <asp:Parameter Name="UserID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="UserName" Type="String" />
                <asp:Parameter Name="UserPassword" Type="String" />
                <asp:Parameter Name="UserMail" Type="String" />
                <asp:Parameter Name="UsersStateID" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="UserName" Type="String" />
                <asp:Parameter Name="UserPassword" Type="String" />
                <asp:Parameter Name="UserMail" Type="String" />
                <asp:Parameter Name="UsersStateID" Type="Int32" />
                <asp:Parameter Name="UserID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>

        <asp:Label ID="lbl_result" runat="server"></asp:Label>

    </form>
</body>
</html>

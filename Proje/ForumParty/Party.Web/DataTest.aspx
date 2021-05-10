<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataTest.aspx.cs" Inherits="Party.Web.DataTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Party: Forum</title>
    
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content="Party is a forum site where communities come together. "/>
    <meta name="author" content="Melih Akkose"/>

    <!-- Icons-->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.4.1/font/bootstrap-icons.css"/>

    <!-- Bootstrap core JavaScript -->
    <script src="Resource/jquery/jquery.min.js"></script>
    <script src="Resource/js/bootstrap.bundle.min.js"></script>

    <!-- Bootstrap core CSS -->
    <link href="Resource/css/bootstrap.min.css" rel="stylesheet" />

     <!-- Custom styles for this template -->
    
    <link href="Resource/css/blog-home.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
       
        <div>
            <asp:TextBox ID="textInput" runat="server" OnTextChanged="textInput_TextChanged"></asp:TextBox>
            <br />
            <asp:Button ID="Button" runat="server" Text="Button" OnClick="Button_Click" />
            <br />
            <asp:DropDownList ID="drp_liste" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drp_liste_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="-1">Seçiniz</asp:ListItem>
            </asp:DropDownList>
        </div>
        <p>
            Seçilen Değerin Özelliğini Alma: 
        </p>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <br />
        <asp:ListBox ID="lst_box" runat="server"></asp:ListBox>
        <br />
        <asp:ListBox ID="lst_box2" runat="server"></asp:ListBox>
         <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ForumPartyConnectionString %>" SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
        <br />
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        <br />
        <asp:Button ID="Button1" runat="server" Text="EF Data Ekle" OnClick="Button1_Click" />
        <br />
        <asp:TextBox ID="Text_UserID" runat="server"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="EF Data Guncelle" OnClick="Button2_Click" />
        <br />
        <asp:Button ID="Button3" runat="server" Text="EF Data Sil" OnClick="Button3_Click" />
        
       <div>
          <asp:ScriptManager ID="scriptManager" runat="server">  </asp:ScriptManager>
           <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">

            <ContentTemplate>
                   <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                   
         </ContentTemplate>
               <Triggers>
                   <asp:AsyncPostBackTrigger ControlID="Button4" EventName="Click"/>
               </Triggers>
        </asp:UpdatePanel>
               <asp:Button ID="Button4" runat="server" Text="Göster" OnClick="Button4_Click" />
       </div>
       <%-- <asp:Repeater ID="repeatData" runat="server">
            <ItemTemplate>
                 <div class="card mb-4">
          <img class="card-img-top" src="http://placehold.it/750x300" alt="Card image cap"/>
          <div class="card-body">
            <h2 class="card-title">Example Content</h2>
            <h6 class="align-content-sm-end"><i class="bi bi-clock-fill"></i> 01.02.2016</h6>
              <h6 class="align-content-sm-end"><i class="bi bi-person-fill"></i>
                  <asp:Label ID="userName_label" runat="server" Text=""><%#Eval("UserName") %></asp:Label> </h6>
            <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
            <button type="button" class="btn btn-success"><i class="bi bi-chevron-up"></i> 46 </button>
            <button type="button" class="btn btn-danger"><i class="bi bi-chevron-down"></i> 32</button>
            <button type="button" class="btn btn-info">Detail <i class="bi bi-info-circle-fill"></i></button>
            <button type="button" class="btn btn-primary">Comment <i class="bi bi-chat-square-text"></i></button>
          </div>
        </div>
            </ItemTemplate>
        </asp:Repeater>--%>

        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>
       
    </form>
    
</body>

</html>

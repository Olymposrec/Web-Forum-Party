<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataTest.aspx.cs" Inherits="Party.Web.DataTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    </form>
</body>

</html>

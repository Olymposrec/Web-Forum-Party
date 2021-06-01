<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Communities.aspx.cs" Inherits="Party.Web.PollsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card my-6" ">
            <div class="card-header">
                 Communities
            </div>
                <ul class="list-group list-group-flush">
    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnItemCreated="Repeater1_ItemCreated" >
        <ItemTemplate>
            
            <div class="container">
                <div class="row ">
            
                
                <div class="text-left col-sm">
                    <asp:Image ID="Image1" class="rounded-circle"  src='Resource/images/profilDefaultImage.png' width="25" height="25"  runat="server" />
                   <%-- <asp:Image ID="Image2" class="rounded-circle"  src='<%#"data:image/jpeg;base64,"+Convert.ToBase64String((byte[])Eval("CommuntiyImage"))%>' width="25" height="25" runat="server" />--%>
                    


                </div>
                <div class=" text-center col-sm">

                                <i class="bi bi-people-fill"> </i> <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server"><b><asp:Label ID="Label2" runat="server" Text='<%#Eval("CommunityName")%>'></asp:Label></b></asp:LinkButton>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("CommunityID") %>' Visible="false"></asp:Label>
                </div>
                <div class="text-right col-sm">
                    <b><asp:Label ID="Label4" runat="server" Text="Members: "> </asp:Label><asp:Label ID="Label3" runat="server" Text='<%#Eval("MembersCount") %>'></asp:Label></b>
                    <asp:LinkButton ID="lb_JoinCommunity" runat="server" OnClick="lb_JoinCommunity_Click" class="btn btn-primary position-relative" Text="Join"></asp:LinkButton>
                </div>
               
                    </div>
                </div>
                
            <br />
        </ItemTemplate>
    </asp:Repeater>       
                </ul>
         </div>
    <br />

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PollsPage.aspx.cs" Inherits="Party.Web.PollsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Unnamed1_ItemCommand" >
        <ItemTemplate>
                <div class="card mb-4">
                      <img max-width="%100" height="auto" class="card-img-top" src="Resource/images/test.jpg"  alt="Card image cap"/>
                           <div class="card-body">
                              <h2 class="card-title">
                                  <asp:Label ID="lbl_title" runat="server" ><%#Eval("Title") %></asp:Label></h2>
                              <h6 class="align-content-sm-end"><i class="bi bi-clock-fill"></i> 
                                  <asp:Label ID="lbl_date" runat="server" ><%#Eval("UploadDate") %></asp:Label>
                              </h6>
                              <h6 class="align-content-sm-end"><i class="bi bi-person-fill"></i>
                              <asp:Label ID="lbl_username" runat="server" ><%#Eval("UserName") %></asp:Label></h6>
                               <asp:Label ID="lbl_description" runat="server" class="card-text"><%#Eval("Description") %></asp:Label>
                               <asp:LinkButton ID="lbl_upvote" runat="server"  type="button" class="btn btn-success"> <i class="bi bi-chevron-up"></i></asp:LinkButton>
                               <asp:LinkButton ID="lbl_downvote" runat="server"  type="button" class="btn btn-danger"><i class="bi bi-chevron-down"></i></asp:LinkButton>
                               <asp:Label ID="lbl_likecount" runat="server" Text="46"></asp:Label>
                               <asp:LinkButton ID="LinkButton3" runat="server"  type="button" class="btn btn-info">Detail <i class="bi bi-info-circle-fill"></i></asp:LinkButton>
                               <asp:LinkButton ID="LinkButton4" runat="server"  type="button" class="btn btn-primary">Comment <i class="bi bi-chat-square-text"></i></asp:LinkButton>
                           </div>
                </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProfilPage.aspx.cs" Inherits="Party.Web.ProfilPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Profile Page</h1>
	<header>
        <div class="container mt-5 d-flex justify-content-center">
    <div class="card p-3">
        <div class="d-flex align-items-center">
            <div class="image">
                <img src="<%#"data:image/jpeg;base64,"+ Convert.ToBase64String((byte[])Eval("ProfilImage"))%>  "  visible="false">
               
            </div>
            <div class="ml-3 w-100">
                 <h4 class="mb-0 mt-0"><%#Eval("ProfilOwner") %></h4>
                <div class="p-2 mt-2 bg-primary d-flex justify-content-between rounded text-white stats">
                    <div class="d-flex flex-column"> <span class="followers">Followers</span> <span class="number2"><%#Eval("Followers") %></span> </div>
                </div>
                <div class="button mt-2 d-flex flex-row align-items-center">
                    <asp:Button ID="btn_follow" runat="server" Text="Follow"   class="btn btn-sm btn-primary w-100 ml-2"/>
                    <asp:Button ID="btn_chat" runat="server" Text="Chat" class="btn btn-sm btn-outline-primary w-100" />

                </div>
            </div>
        </div>
    </div>
</div>
        <br />
	</header>
   

        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
    <ItemTemplate>
                 <div class="card mb-4">
                     
                           <img max-width="%100" height="auto" class="card-img-top" src="<%#"data:image/jpeg;base64,"+ Convert.ToBase64String((byte[])Eval("PostImage")) %>"  alt="Card image cap"/>
                           <div class="card-body">
                              <h2 class="card-title">
                                  <asp:Label ID="lbl_title" runat="server" ><%#Eval("Title") %></asp:Label>
                              </h2>
                              <h6 class="align-content-sm-end"> 
                                  <div class="row">
                                      
                                            <div class="col-md-4"><asp:LinkButton ID="LinkButton1" runat="server" class="text-left"><i class="bi bi-person-fill" type="button"></i> <%#Eval("UserID") %></asp:LinkButton></div>
                                            <div class="col-md-4 ml-auto text-right"> <asp:Label ID="lbl_date" runat="server" ><i class="bi bi-clock-fill"></i> <%#Eval("UploadDate")%></asp:Label></div>
                                    
                                  </div>
                              </h6>
                               <asp:Label ID="lbl_description" runat="server" class="card-text"><%#Eval("Description") %></asp:Label>
                                <div >
                                    <hr />
                                </div>
                               <div style="height:40px;width:fit-content()">
                                   <asp:LinkButton ID="lbl_upvote" runat="server" OnClick="lbl_upvote_Click" type="button" class="btn btn-success"> <i class="bi bi-chevron-up"></i></asp:LinkButton>
                                <asp:Label ID="lbl_likecount" runat="server" class="h5" ><b><%#Eval("Like") %></b></asp:Label>
                                <asp:LinkButton ID="lbl_downvote" runat="server"  type="button" class="btn btn-danger"><i class="bi bi-chevron-down"></i></asp:LinkButton>
                               <asp:LinkButton ID="LinkButton3" runat="server"  type="button" class="btn btn-info">Detail <i class="bi bi-info-circle-fill"></i></asp:LinkButton>
                               
                                   <asp:LinkButton ID="LinkButton2" runat="server"  type="button" class="btn btn-danger">Delete <i class="bi bi-trash-fill"></i></asp:LinkButton>
                               </div>
                                
                           </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
</asp:Content>

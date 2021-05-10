<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Party.Web.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <!-- Blog Post -->
   
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
    <ItemTemplate>
                 <div class="card mb-4">
                     
                           <img max-width="%100" height="auto" class="card-img-top" src="<%#"data:image/jpeg;base64,"+ Convert.ToBase64String((byte[])Eval("PostImage")) %>"  alt="Card image cap"/>
                           <div class="card-body">
                              <h2 class="card-title">
                                  <asp:Label ID="lbl_title" runat="server" ><%#Eval("Title") %></asp:Label>
                              </h2>
                              <h6 class="align-content-sm-end"> 
                                  <div class="row">
                                        <asp:Label ID="Label1" runat="server" Text="" Visible="false"><%#Eval("PostID")%>" </asp:Label>
                                            <div class="col-md-4"><asp:LinkButton ID="LinkButton1" runat="server" class="text-left"><i class="bi bi-person-fill" type="button"></i> <%#Eval("UserID") %></asp:LinkButton></div>
                                            <div class="col-md-4 ml-auto text-right"> <asp:Label ID="lbl_date" runat="server" ><i class="bi bi-clock-fill"></i> <%#Eval("UploadData")%></asp:Label></div>
                                    
                                  </div>
                              </h6>
                               <asp:Label ID="lbl_description" runat="server" class="card-text"><%#Eval("Description") %></asp:Label>
                                <div >
                                    <hr />
                                </div>
                               <div style="height:40px;width:fit-content()">
                                            <asp:LinkButton ID="lbl_upvote" OnClick="Btn_UpVote_Click" runat="server"  type="button" class="btn btn-success"> <i class="bi bi-chevron-up"></i></asp:LinkButton>
                                            <asp:Label ID="lbl_likecount"  runat="server" class="h5" ><b><%#Eval("Like") %></b></asp:Label>
                                            <asp:LinkButton ID="lbl_downvote" OnClick="Btn_UpDown_Click" runat="server"  type="button" class="btn btn-danger"><i class="bi bi-chevron-down"></i></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton3" runat="server"  type="button" class="btn btn-info">Detail <i class="bi bi-info-circle-fill"></i></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton4" runat="server"  type="button" class="btn btn-primary">Comment <i class="bi bi-chat-square-text"></i></asp:LinkButton>
                                   
                                   <asp:ListView ID="ListView1" runat="server" DataKeyNames="PostImage,Title,PostID,UserID,UploadData,Description,Like"></asp:ListView>
                               </div>
                                
                           </div>
                </div>
            </ItemTemplate>

        </asp:Repeater>
    
</asp:Content>

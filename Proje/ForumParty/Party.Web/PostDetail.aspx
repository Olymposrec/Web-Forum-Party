<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PostDetail.aspx.cs" Inherits="Party.Web.PostDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Resource/css/bootstrap.min.css" rel="stylesheet" />
    <script src="Resource/jquery/jquery.min.js"></script>
    <script src="Resource/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Repeater ID="Repeater2" runat="server">
        <ItemTemplate>

            <div class="card mb-4">
                     
                           <img max-width="%100" height="auto" class="card-img-top" src="<%#"data:image/jpeg;base64,"+ Convert.ToBase64String((byte[])Eval("PostImage")) %>"  alt="Card image cap"/>
                           <div class="card-body">
                              <h2 class="card-title">
                                  <asp:Label ID="lbl_title" runat="server" ><%#Eval("Title") %></asp:Label>
                              </h2>
                              <h6 class="align-content-sm-end"> 
                                  <div class="row">
                                      <asp:Label ID="Label2" runat="server" Text='<%#Eval("UserID")%>' Visible="false"> </asp:Label>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("PostID")%>' Visible="false"> </asp:Label>
                                           <i class="bi bi-person-fill" type="button"></i><div class="col-md-4"><asp:LinkButton ID="lb_routeProfile" runat="server" OnClick="lb_routeProfile_Click" class="text-left"><%#Eval("UserName") %></asp:LinkButton></div>
                                            <div class="col-md-4 ml-auto text-right"> <asp:Label ID="lbl_date" runat="server" ><i class="bi bi-clock-fill"></i> <%#Eval("UploadDate")%></asp:Label></div>
                                    
                                  </div>
                              </h6>
                               <asp:Label ID="lbl_description" runat="server" class="card-text"><%#Eval("Description") %></asp:Label>
                                <div >
                                    <hr />
                                </div>
                               <div style="height:40px;width:fit-content()">
                                            <asp:LinkButton ID="lbl_upvote" OnClick="lbl_upvote_Click" runat="server"  type="button" class="btn btn-success" > <i class="bi bi-chevron-up"></i></asp:LinkButton>
                                            <asp:Label ID="lbl_likecount"  runat="server" class="h5" ><b><%#Eval("Like") %></b></asp:Label>
                                            <asp:LinkButton ID="lbl_downvote" OnClick="lbl_downvote_Click"  runat ="server"  type="button" class="btn btn-danger" > <i class="bi bi-chevron-down"></i></asp:LinkButton>
                                        
                                           
                                   
                                   <asp:ListView ID="ListView1" runat="server" DataKeyNames="PostImage,Title,PostID,UserID,UploadData,Description,Like"></asp:ListView>
                               </div>
                           </div>
                </div>


        </ItemTemplate>

    </asp:Repeater>


    

            <!-- Fluid width widget -->        
    	    <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        <span class="glyphicon glyphicon-comment"></span> 
                        Recent Comments
                    </h3>
                </div>
                <div class="panel-body">

                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>


                    <ul class="media-list">
                        <li class="media">
                            <div class="media-body">
                                 <div class="row">
                                            <div class="col-md-4"><i class="bi bi-person-fill" type="button"></i> <asp:LinkButton ID="LinkButton1" runat="server" class="text-left" Text='<%#Eval("Nickname") %>'></asp:LinkButton></div>
                                            <div class="col-md-4 ml-auto text-right"> <asp:Label ID="lbl_date" runat="server" ><i class="bi bi-clock-fill"></i><%#Eval("CommentDate") %></asp:Label></div>

                                  </div>
                                
                                <p>
                                     <%#Eval("Content") %>
                                </p>
                            </div>
                        </li>
                    </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                    
                    <asp:TextBox ID="txt_Comment" runat="server" class="btn btn-outline-primary btn-block"></asp:TextBox>
                    <asp:LinkButton ID="btn_comment" runat="server" OnClick="btn_comment_Click"  type="button" class="btn btn-primary btn btn-default btn-block"> Comment <i class="bi bi-chat-square-text"></i></asp:LinkButton>
                    

                
                </div>
            </div>
            <!-- End fluid width widget --> 
            





</asp:Content>

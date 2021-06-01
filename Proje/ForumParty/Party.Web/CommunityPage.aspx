<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CommunityPage.aspx.cs" Inherits="Party.Web.CommunityPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="card mb-4">
                <div class="card-title">
                    <h2>Community Page  </h2>
                </div>

    <asp:DataList ID="DataList1" runat="server" OnSelectedIndexChanged="DataList1_SelectedIndexChanged"  OnItemCreated="DataList1_ItemCreated">
         <ItemTemplate>
                <img runat="server" class="card-img-top-sm rounded-circle mx-auto d-block" src='Resource/images/profilDefaultImage.png' width="160" height="160" style="margin-top: 10px" />
                <div class="card-body">
                    <h2 class="card-title">
                        <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label> <%#Eval("CommunityName")%>
                    </h2>
                    <h6 class="align-content-start">
                        <div class="row">
                            <div class="col-md-4 ml-auto text-right">
                                <asp:Label ID="Label3" runat="server" Text="Followers: "></asp:Label><asp:LinkButton ID="LinkButton1" runat="server" class="text-left" Text='<%#Eval("Members") %>'> </asp:LinkButton>
                            </div>

                        </div>
                    </h6>
                    <asp:Label ID="Label4" runat="server" Text="About: "></asp:Label> <asp:Label ID="lbl_aboutMe" runat="server" class="card-text" Text='<%#Eval("AboutMe") %>'></asp:Label>
                    <div>
                        <hr />
                    </div>
                </div>
        
                    <div style="height: 40px; width: fit-content()">
                       
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                            <ContentTemplate>
                                <asp:Button ID="btn_Join" OnClick="btn_join_Click" runat="server" Text="Join" class="btn btn-primary " />
                                <asp:Button ID="btn_editProfil" runat="server" Text="Edit Profile" OnClick="btn_editProfil_Click" class="btn btn-primary " />
                                <asp:Button ID="btn_delete" runat="server" OnClick="btn_delete_Click" Text="Delete" class="btn btn-primary " />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

               </ItemTemplate>
      </asp:DataList>
        </div>

          
    

    <br />


    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound" OnItemCreated="Repeater1_ItemCreated">
        <ItemTemplate>
            <div class="card mb-4">

                <img max-width="%100" height="auto" class="card-img-top" src='<%#"data:image/jpeg;base64,"+ Convert.ToBase64String((byte[])Eval("PostImage")) %>' alt="Card image cap" />
                <div class="card-body">
                    <h2 class="card-title">
                        <asp:Label ID="Label5" runat="server" Text='<%#Eval("PostID") %>' Visible="false"></asp:Label>
                        <asp:Label ID="lbl_title" runat="server"><%#Eval("Title") %></asp:Label>
                    </h2>
                    <h6 class="align-content-sm-end">
                        <div class="row">

                            <div class="col-md-4">
                                <i class="bi bi-person-fill" ></i> <asp:LinkButton ID="LinkButton1" runat="server" class="text-left" Text='<%#Eval("UserID") %>'> </asp:LinkButton>
                            </div>
                            <div class="col-md-4 ml-auto text-right">
                                <i class="bi bi-clock-fill"></i> <asp:Label ID="lbl_date" runat="server" Text='<%#Eval("UploadDate")%>'></asp:Label>
                                 <br />
                                <i class="bi bi-people-fill"></i> <asp:LinkButton ID="community_Linkbtn" OnClick="community_Linkbtn_Click" runat="server"  Text='<%#Eval("CommunityName")%>'></asp:LinkButton>
                            </div>

                        </div>
                    </h6>
                    <asp:Label ID="lbl_description" runat="server" class="card-text"><%#Eval("Description") %></asp:Label>
                    <div>
                        <hr />
                    </div>
                    <div style="height: 40px; width: fit-content()">
                        <asp:LinkButton ID="lbl_upvote" runat="server" OnClick="lbl_upvote_Click" type="button" class="btn btn-success"> <i class="bi bi-chevron-up"></i></asp:LinkButton>
                        <asp:Label ID="lbl_likecount" runat="server" class="h5"><b><%#Eval("Like") %></b></asp:Label>
                        <asp:LinkButton ID="lbl_downvote" runat="server" OnClick="lbl_downvote_Click" type="button" class="btn btn-danger"><i class="bi bi-chevron-down"></i></asp:LinkButton>
                        <asp:LinkButton ID="lb_DetailLink" OnClick="lb_Detail_Click" runat="server" type="button" class="btn btn-info">Detail <i class="bi bi-info-circle-fill"></i></asp:LinkButton>
                         <asp:LinkButton ID="LinkButton2" OnClick="lb_Comment_Click" runat="server"  type="button" class="btn btn-info">Comment <i class="bi bi-chat-left-text-fill"></i></asp:LinkButton>
                        <asp:LinkButton ID="delete_PostLink" OnClick="delete_PostLink_Click" runat="server" type="button" class="btn btn-danger">Delete <i class="bi bi-trash-fill"></i></asp:LinkButton>
                    </div>

                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
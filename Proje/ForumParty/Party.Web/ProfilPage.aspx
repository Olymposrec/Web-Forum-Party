<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProfilPage.aspx.cs" Inherits="Party.Web.ProfilPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="card mb-4">
                <div class="card-title">
                    <h2>Profile Page  </h2>
                </div>

    <asp:DataList ID="DataList1" runat="server" OnSelectedIndexChanged="DataList1_SelectedIndexChanged"  OnItemCreated="DataList1_ItemCreated">
         <ItemTemplate>
                <img runat="server" class="card-img-top-sm rounded-circle mx-auto d-block" src='Resource/images/profilDefaultImage.png' width="160" height="160" style="margin-top: 10px" />
                <div class="card-body">
                    <h2 class="card-title">
                        <%#Eval("Name") %>  <%#Eval("Surname") %>
                    </h2>
                    <h6 class="align-content-start">
                        <div class="row">

                            <div class="col-md-4 ">
                                <asp:Label ID="lbl_date" runat="server" Text='<%#Eval("UserName")%>'></asp:Label>
                            </div>
                            <div class="col-md-4 ml-auto text-right">
                                <asp:LinkButton ID="LinkButton1" runat="server" class="text-left" Text='<%#Eval("Followers") %>'> </asp:LinkButton>
                            </div>

                        </div>
                    </h6>
                    <asp:Label ID="lbl_aboutMe" runat="server" class="card-text" Text='<%#Eval("AboutMe") %>'></asp:Label>
                    <div>
                        <hr />
                    </div>
                </div>
        
                    <div style="height: 40px; width: fit-content()">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                            <ContentTemplate>
                                <asp:Button ID="btn_follow" OnClick="btn_follow_Click" runat="server" Text="Follow" class="btn btn-primary " />
                                <asp:Button ID="btn_chat" runat="server" Text="Chat" class="btn  btn-outline-primary" />
                                <asp:Button ID="btn_editProfil" runat="server" Text="Edit Profile" class="btn btn-primary " />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

               </ItemTemplate>
      </asp:DataList>
        </div>

          
    

    <br />


    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
        <ItemTemplate>
            <div class="card mb-4">

                <img max-width="%100" height="auto" class="card-img-top" src="<%#"data:image/jpeg;base64,"+ Convert.ToBase64String((byte[])Eval("PostImage")) %>" alt="Card image cap" />
                <div class="card-body">
                    <h2 class="card-title">
                        <asp:Label ID="lbl_title" runat="server"><%#Eval("Title") %></asp:Label>
                    </h2>
                    <h6 class="align-content-sm-end">
                        <div class="row">

                            <div class="col-md-4">
                                <asp:LinkButton ID="LinkButton1" runat="server" class="text-left"><i class="bi bi-person-fill" type="button"></i> <%#Eval("UserID") %></asp:LinkButton>
                            </div>
                            <div class="col-md-4 ml-auto text-right">
                                <asp:Label ID="lbl_date" runat="server"><i class="bi bi-clock-fill"></i> <%#Eval("UploadDate")%></asp:Label>
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
                        <asp:LinkButton ID="lbl_downvote" runat="server" type="button" class="btn btn-danger"><i class="bi bi-chevron-down"></i></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton3" runat="server" type="button" class="btn btn-info">Detail <i class="bi bi-info-circle-fill"></i></asp:LinkButton>

                        <asp:LinkButton ID="LinkButton2" runat="server" type="button" class="btn btn-danger">Delete <i class="bi bi-trash-fill"></i></asp:LinkButton>
                    </div>

                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

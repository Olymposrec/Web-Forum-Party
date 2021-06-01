<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditCommunity.aspx.cs" Inherits="Party.Web.EditCommunity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div>
            <asp:DropDownList ID="drp_community" runat="server" required="required" class="custom-select" AutoPostBack="True" OnTextChanged="drp_community_TextChanged">
            </asp:DropDownList>
            
        </div>
        <hr />
        <h6>EDIT COMMUNITY</h6>
        <hr />
        <div>

            <asp:Repeater ID="Repeater_comm" runat="server">
                <ItemTemplate>
                    <div class="form-group">
                        <label for="text">Community Name</label>
                        <div class="input-group">
                            <div class="input-group-prepend">
                                <div class="input-group-text">
                                    <i class="bi bi-archive-fill"></i>
                                </div>
                            </div>
                            <asp:TextBox ID="txt_communityName" runat="server" placeholder="Community Name" type="text" class="form-control" Text='<%#Eval("CommunityName")%>'></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-control-file">
                        <label class="form-label" for="customFile">Community Image</label>
                        <asp:FileUpload ID="imageUpload" runat="server" type="file" class="form-control"></asp:FileUpload>
                    </div>
                    <div class="form-group">
                        <label for="textarea">Description</label>
                        <asp:TextBox ID="txt_description" runat="server" placeholder="Description" TextMode="MultiLine" Rows="5" class="form-control" MaxLength="500" Text='<%#Eval("CommunityDescription") %>'></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="update_Btn" runat="server" Text="Update" type="submit" class="btn btn-primary" OnClick="update_Btn_Click" />
                        <asp:Button ID="delete_Btn" runat="server" Text="Delete" type="submit" class="btn btn-primary" OnClick="delete_Btn_Click" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>
    <hr />
     <div class="form-group">
         <h6>CREATE COMMUNITY</h6>
         <hr />
                        <label for="text">Community Name</label>
                        <div class="input-group">
                            <div class="input-group-prepend">
                                <div class="input-group-text">
                                    <i class="bi bi-archive-fill"></i>
                                </div>
                            </div>
                            <asp:TextBox ID="txt_communityName" runat="server" placeholder="Community Name" type="text" class="form-control" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-control-file">
                        <label class="form-label" for="customFile">Community Image</label>
                        <asp:FileUpload ID="imageUpload" runat="server" type="file" class="form-control"></asp:FileUpload>
                    </div>
                    <div class="form-group">
                        <label for="textarea">Description</label>
                        <asp:TextBox ID="txt_description" runat="server" placeholder="Description" TextMode="MultiLine" Rows="5" class="form-control" MaxLength="500" ></asp:TextBox>
                    </div>
                    <div class="form-group">
                        
                        <asp:Button ID="create_Btn" runat="server" Text="Create" type="submit" class="btn btn-primary" OnClick="create_Btn_Click" />
                       
                    </div>
        <hr />
        <asp:Label ID="lbl_result" runat="server" Text=""></asp:Label>


</asp:Content>

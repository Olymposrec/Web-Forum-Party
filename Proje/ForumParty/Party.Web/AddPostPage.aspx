<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddPostPage.aspx.cs" Inherits="Party.Web.AddPostPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <form>
  <div class="form-group">
    <label for="text">Title</label> 
    <div class="input-group">
      <div class="input-group-prepend">
        <div class="input-group-text">
          <i class="bi bi-archive-fill"></i>
        </div>
      </div> 
        <asp:TextBox ID="txt_title" runat="server" placeholder="Post Title" type="text" required="required" class="form-control"></asp:TextBox>
    </div>
  </div>
      <div class="form-control-file">
        <label class="form-label" for="customFile">File Input.</label>
          <asp:FileUpload runat="server"  type="file" class="form-control"></asp:FileUpload>
      </div> 


  <div class="form-group">
        <label for="textarea">Text Area</label> 
    <asp:TextBox ID="txt_description" runat="server" placeholder="Description" TextMode="MultiLine" Rows="10" required="required" class="form-control" MaxLength="255" ></asp:TextBox>
  </div>
  <div class="form-group">
    <label for="drp_category">Category</label> 
    <div>
        <asp:DropDownList ID="drp_category" runat="server" required="required" class="custom-select">
            <asp:ListItem Selected="True" Value="-1">Select One</asp:ListItem>
        </asp:DropDownList>
    </div>
  </div>
  <div class="form-group">
    <label for="select">Community</label> 
    <div>
      <asp:DropDownList ID="drp_community" runat="server" required="required" class="custom-select">
          <asp:ListItem Selected="True" Value="-1">Select One</asp:ListItem>
        </asp:DropDownList>
    </div>
  </div>
  <div class="form-group">
    <label>Privacy State</label> 
    <div>
      <div class="custom-control custom-radio custom-control-inline">
          <asp:RadioButton ID="RadioButton1" type="radio" runat="server" GroupName="privacyState" Text=" Public" Checked="true"/>
      </div>
      <div class="custom-control custom-radio custom-control-inline">
          
          <asp:RadioButton ID="RadioButton2" type="radio" runat="server" GroupName="privacyState" Text=" Private" />
      </div>
    </div>
  </div> 
  <div class="form-group">
      <asp:Button runat="server" Text="Submit"  type="submit" class="btn btn-primary"/>
  </div>
</form>

   

</asp:Content>

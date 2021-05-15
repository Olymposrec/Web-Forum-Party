<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AboutUser.aspx.cs" Inherits="Party.Web.AboutUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form>

      <div class="form-control-file">
        <label class="form-label" for="customFile"><b>Profile Image</b> </label>
          <asp:FileUpload  ID="profileImageUpload" runat="server"  type="file" class="form-control"></asp:FileUpload>
      </div> 
        <br />

<hr />
  <div class="form-group">
       <label class="form-label"><b>Profile Information </b></label>
      <br />
    <asp:TextBox ID="txt_name" runat="server" placeholder="Name"   type="text" required="required" class="form-control"></asp:TextBox>
    <br />
    <asp:TextBox ID="txt_surname" runat="server" placeholder="SurName"  type="text" required="required" class="form-control"></asp:TextBox>
    <br />
    <asp:TextBox ID="txt_phone" runat="server" placeholder="5XX-XXX-XX-XX"  type="tel" pattern="[0-9]{3}[0-9]{3}[0-9]{2}[0-9]{2}"  required="required" class="form-control"></asp:TextBox>
      <small>Format: 5XXXXXXXXX</small>
      <br />
    <br />
    <asp:TextBox ID="txt_aboutMe" runat="server" placeholder=" About Me"  type="text" TextMode="MultiLine" required="required" class="form-control" rows="5" MaxLength="255" ></asp:TextBox>
 </div>
  <hr />
<div class="form-group">
    <label class="form-label"><b>Address Information</b> </label>
    <br />
    <asp:TextBox ID="txt_road" runat="server" placeholder="Road"   type="text" required="required" class="form-control"></asp:TextBox>
    <br />
    <asp:TextBox ID="txt_street" runat="server" placeholder="Street"   type="text" required="required" class="form-control"></asp:TextBox>
    <br />
    <asp:TextBox ID="txt_neighbor" runat="server" placeholder="Neighborhood"   type="text" required="required" class="form-control"></asp:TextBox>
    <br />
    <asp:TextBox ID="txt_aptNo" runat="server" placeholder="Apartment No"   type="number" required="required" class="form-control"></asp:TextBox>
    <br />
    <asp:TextBox ID="txt_floor" runat="server" placeholder="Floor"   type="number" required="required" class="form-control"></asp:TextBox>
    <br />
    <asp:TextBox ID="txt_District" runat="server" placeholder="District"   type="text" required="required" class="form-control"></asp:TextBox>
    <br />
    <asp:TextBox ID="txt_province" runat="server" placeholder="Province"   type="text" required="required" class="form-control"></asp:TextBox>
    <br />

</div>


 
  <div class="btn-group">
      <asp:Button runat="server" ID="btn_Save" Text="Save"  type="submit" class="btn btn-success" OnClick="btn_Save_Click"/>
      <p>&nbsp</p>
      <asp:Button runat="server" ID="btn_Update" Text="Update"  type="submit" class="btn btn-primary" OnClick="btn_Update_Click"/>
      <br />
  </div>


 <asp:Label ID="lbl_result" runat="server" Text=""></asp:Label>

        <br />
</form>



</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LogInPage.aspx.cs" Inherits="Party.Web.LogInPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
					<form>
    <div class="card  text-center">
				<img class=" card-img-top-sm rounded-circle mx-auto d-block" src="Resource/images/homepageLogo2.jpg" width="%100" height="160" style="margin-top:10px"  />
				<div class="card-body">
					<h4 class="card-title text-center mb-4 mt-1">Log in</h4>
				    <hr/>
					<asp:Label ID="lbl_result" runat="server" Text="" class="text-danger"></asp:Label>
						<div class="form-group">
							<div class="input-group">
								<div class="input-group-prepend">
									<span class="input-group-text"><i class="bi bi-person-fill"></i></span>
								</div>
									<asp:TextBox ID="txt_userName" runat="server" type="text" class="form-control input_user"  placeholder="Username"></asp:TextBox>
							</div> <!-- input-group.// -->
						</div> <!-- form-group// -->
						<div class="form-group">
							<div class="input-group">
								<div class="input-group-prepend">
									<span class="input-group-text"><i class="bi bi-key"></i></span>
								</div>
									<asp:TextBox ID="txt_passWord" runat="server" type="password" class="form-control input_pass"  placeholder="Password"></asp:TextBox>
							</div> <!-- input-group.// -->
						</div> <!-- form-group// -->
						<div class="form-group">
							<asp:Button ID="loginButton" Text="Log In" runat="server" type="button"  class="btn login_btn btn-success" OnClick="loginButton_Click" />
						</div> <!-- form-group// -->
							<p class="text-center"><a href="#" class="btn">Forgot password?</a></p>
				</div>
  </div>

	    <div class="card  text-center">
				
				<div class="card-body">
					<h4 class="card-title text-center mb-4 mt-1">Register</h4>
				    <hr/>
					<asp:Label ID="lbl_registerResultDanger" runat="server" Text="" class="text-danger"></asp:Label>
					<asp:Label ID="lbl_registerResultSuccess" runat="server" Text="" class="text-success"></asp:Label>
					<%--<form>--%>
						<div class="form-group">
							<div class="input-group">
								<div class="input-group-prepend">
									<span class="input-group-text"><i class="bi bi-person-fill"></i></span>
									
								</div>
									<asp:TextBox ID="txt_usernameRegister" runat="server" type="text" class="form-control input_pass"  placeholder="User Name"></asp:TextBox>
							</div>
						</div> 
						<div class="form-group">
							<div class="input-group">
								<div class="input-group-prepend">
									<span class="input-group-text"><i class="bi bi-envelope-fill"></i></span>
								</div>
									<asp:TextBox ID="txt_usermailRegister" runat="server" type="email" class="form-control input_user"  placeholder="User Mail"></asp:TextBox>
							</div> 
						</div> 
						<div class="form-group">
							<div class="input-group">
								<div class="input-group-prepend">
									<span class="input-group-text"><i class="bi bi-key"></i></span>
								</div>
									<asp:TextBox ID="txt_passwordRegister" runat="server" type="password" class="form-control input_pass"  placeholder="Password"></asp:TextBox>
							</div>
						</div> 
						<div class="form-group">
							<div class="input-group">
								<div class="input-group-prepend">
									<span class="input-group-text"><i class="bi bi-key"></i></span>
								</div>
									<asp:TextBox ID="txt_confirmPasswordRegister" runat="server" type="password" class="form-control input_pass"  placeholder="Confirm Password"></asp:TextBox>
							</div>
						</div> 
						<div class="form-group">
							<asp:Button ID="btn_addUser" Text="Register" runat="server" type="button"  class="btn login_btn btn-success" OnClick="register_Click" />
						</div> 
							
					<%--<form>--%>
				</div>
  </div>
					</form>
</asp:Content>

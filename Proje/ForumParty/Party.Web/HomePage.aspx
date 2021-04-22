<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Party.Web.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <!-- Blog Post -->
        <div class="card mb-4">
          <img class="card-img-top" src="http://placehold.it/750x300" alt="Card image cap"/>
          <div class="card-body">
            <h2 class="card-title">Example Content</h2>
            <h6 class="align-content-sm-end"><i class="bi bi-clock-fill"></i> 01.02.2016</h6>
              <h6 class="align-content-sm-end"><i class="bi bi-person-fill"></i> Freud</h6>
            <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
            <button type="button" class="btn btn-success"><i class="bi bi-chevron-up"></i> 46 </button>
            <button type="button" class="btn btn-danger"><i class="bi bi-chevron-down"></i> 32</button>
            <button type="button" class="btn btn-info">Detail <i class="bi bi-info-circle-fill"></i></button>
            <button type="button" class="btn btn-primary">Comment <i class="bi bi-chat-square-text"></i></button>
          </div>
        </div>
</asp:Content>

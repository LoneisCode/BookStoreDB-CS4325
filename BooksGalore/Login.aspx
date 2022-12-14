<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BooksGalore.Style.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Style/register.css" rel="stylesheet" type="text/css" />
        <div class ="splashCont">
       <img src="Content/Images/paul-melki-bByhWydZLW0-unsplash.jpg" alt ="Amazing bookshelf" id="bookSplash" />
        <div id="form" class="form-group">
            <h1 id="formTitle">Welcome back beloved customer!</h1>
            <hr />
                <asp:Label runat="server"  CssClass="lblfield" >Username</asp:Label>
                <asp:TextBox runat="server" ClientIDMode="Static" cssClass="form-control regTxtBx" ID="uName" required="true" />
                <asp:Label runat="server" CssClass="lblfield">Password</asp:Label>
                <asp:TextBox runat="server" ClientIDMode="Static" cssClass="form-control regTxtBx" TextMode="Password" ID="passwd" required="true"/>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="Login" OnClick="Log_Click" Type="submit"/>
            <asp:Label CssClass="alert alert-danger regTxtBx" Visible="false" runat="server" ID="wentWrong" />
        </div>
    </div>
</asp:Content>

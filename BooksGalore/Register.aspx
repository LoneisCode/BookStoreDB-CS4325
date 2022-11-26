<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BooksGalore.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Style/register.css" rel="stylesheet" type="text/css" />
        <div class ="splashCont">
       <img src="Content/Images/paul-melki-bByhWydZLW0-unsplash.jpg" alt ="Amazing bookshelf" id="bookSplash" />
        <div id="form" class="form-group">
            <h1 id="formTitle">We would love you as a customer!</h1>
            <hr />
                <asp:Label runat="server"  CssClass="lblfield">First Name</asp:Label>
                <asp:TextBox runat="server" ClientIDMode="Static" cssClass="form-control" ID="fName" />
                <asp:Label runat="server" CssClass="lblfield">Last Name</asp:Label>
                <asp:TextBox runat="server" ClientIDMode="Static" cssClass="form-control" ID="lName" />
                <asp:Label runat="server"  CssClass="lblfield">Username</asp:Label>
                <asp:TextBox runat="server" ClientIDMode="Static" cssClass="form-control" ID="uName" />
                <asp:Label runat="server" CssClass="lblfield">Password</asp:Label>
                <asp:TextBox runat="server" ClientIDMode="Static" cssClass="form-control" ID="passwd" />
                <asp:Label runat="server" CssClass="lblfield">Re-Type Password</asp:Label>
                <asp:TextBox runat="server" ClientIDMode="Static" cssClass="form-control" ID="passwdConfirm" />
            <asp:Button runat="server" OnClick="Reg_Click" cssClass="btn btn-primary" Text="Create Account"/>
            <asp:Label CssClass="alert alert-danger" Visible="false" runat="server" />
        </div>
    </div>
</asp:Content>

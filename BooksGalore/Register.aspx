<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BooksGalore.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Style/register.css" rel="stylesheet" type="text/css" />
        <div class ="splashCont">
       <img src="Content/Images/paul-melki-bByhWydZLW0-unsplash.jpg" alt ="Amazing bookshelf" id="bookSplash" />
        <div id="form" class="form-group">
            <h1 id="formTitle">We would love you as a customer!</h1>
            <hr />
                <asp:Label runat="server"  CssClass="lblfield">First Name</asp:Label>
                <asp:TextBox runat="server" ClientIDMode="Static" cssClass="form-control regTxtBx" ID="fName" required="true"/>
                <asp:Label runat="server" CssClass="lblfield">Last Name</asp:Label>
                <asp:TextBox runat="server" ClientIDMode="Static" cssClass="form-control regTxtBx" ID="lName" required="true"/>
                <asp:Label runat="server"  CssClass="lblfield">Username</asp:Label>
                <asp:TextBox runat="server" ClientIDMode="Static" CssClass="form-control regTxtBx" ID="uName" required="true"/>

                <asp:Label runat="server"  CssClass="lblfield">Email</asp:Label>
                <asp:TextBox runat="server" ClientIDMode="Static" cssClass="form-control regTxtBx" ID="emailBx" required="true" TextMode="Email"/>
                <asp:Label runat="server" CssClass="lblfield">Address</asp:Label>
                <asp:TextBox runat="server" ClientIDMode="Static" cssClass="form-control regTxtBx" ID="addyBx" required="true"/>
                <asp:Label runat="server"  CssClass="lblfield">Phone</asp:Label>
                <asp:TextBox runat="server" ClientIDMode="Static" CssClass="form-control regTxtBx" ID="phoneNum" required="true" TextMode="Phone" />
                <asp:Label runat="server" CssClass="lblfield">Password</asp:Label>
                <asp:TextBox runat="server" ClientIDMode="Static" cssClass="form-control regTxtBx" TextMode="Password" ID="passwd" required="true" />
                <asp:Label runat="server" CssClass="lblfield">Re-Type Password</asp:Label>
                <asp:TextBox runat="server" ClientIDMode="Static" cssClass="form-control regTxtBx" TextMode="Password" ID="passwdConfirm" required="true"/>
                <asp:Button runat="server" OnClick="Reg_Click" cssClass="btn btn-primary" Text="Create Account" Type="submit" />
                <asp:Label CssClass="alert alert-danger form-control regTxtBx" Visible="False" runat="server" ID="wentWrong"/>
        </div>
    </div>
</asp:Content>

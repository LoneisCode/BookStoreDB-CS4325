<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BooksGalore.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Style/Home.css" rel ="stylesheet" type="text/css" />

    <div class ="splashCont">
       <img src="Content/Images/paul-melki-bByhWydZLW0-unsplash.jpg" alt ="Amazing bookshelf" id="bookSplash" />
        <div id="homeTitle"><span class="titleText">Welcome to Books Galore</span></div>
    </div>

    <h2 id="devTitle">Who we are ?</h2>
    <div class="devInfo">
        

        <div class="indivInfo">
            <div class="devName"><h3>Kniledge "Lone" Johns</h3></div>
            <asp:Image runat="server" ImageUrl="~/Content/Images/lone_pic.jfif" CssClass="devImg"/>
        </div>
        <div class="indivInfo">
            <div class="devName"><h3>John Workman</h3></div>
            <asp:Image runat="server" ImageUrl="~/Content/Images/john_pic.jfif" CssClass="devImg" />
        </div>

    </div>
</asp:Content>

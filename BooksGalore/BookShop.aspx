<%@ Page Title="BookShop" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookShop.aspx.cs" Inherits="BooksGalore.BookShop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Style/BookShop.css" rel ="stylesheet" type="text/css" />
    
    <h1>Galore of Books</h1>
    <asp:Repeater runat="server" ID="BookCard" >
        <ItemTemplate>
            <div class="itemCard">
                <h2 id="bookTitle"><%# Eval("Title") %></h2>
                <h3 id="authorOfBook"><%#Eval("LName")%>,<%# Eval("FName") %></h3>
                <h4 id="priceOfBook"><%# Eval("Price") %></h4>
                <h4 id="reviewOfBook"><%# Eval("UserReviews") %></h4>
                <p id="publication"><%# Eval("PublicationDate") %></p>
                <p id="Categories"><%# Eval("CategoryDescription") %></p>
                 <p id="ISBN"><%# Eval("ISBN") %></p>
                <asp:button ID="addCartBtn" Text="Add to Cart" runat="server" OnClick="addCartBtn_Click"/>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    
</asp:Content>

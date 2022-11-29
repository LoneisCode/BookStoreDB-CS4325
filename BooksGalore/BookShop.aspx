<%@ Page Title="BookShop" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookShop.aspx.cs" Inherits="BooksGalore.BookShop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Galore of Books</h1>
    <asp:Repeater runat="server" ID="BookCard" >
        <ItemTemplate>
            <div class="itemCard">
                <h2 id="bookTitle"><%# Eval("Title") %></h2>
                <h3 id="authorOfBook"><%# Eval("Author") %></h3>
                <h4 id="priceOfBook"><%# Eval("Price") %></h4>
                <h4 id="reviewOfBook"><%# Eval("UserReviews") %></h4>
                <p id="publication"><%# Eval("PublicationDate") %></p>
                <p id="Categories"><%# Eval("CategoryDescription") %></p>
                 <p id="ISBN"><%# Eval("ISBN") %></p>
                <button ID="addCartBtn" onclick="addToCart" />
            </div>
        </ItemTemplate>
    </asp:Repeater>
    
</asp:Content>

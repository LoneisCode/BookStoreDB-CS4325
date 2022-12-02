<%@ Page Title="BookShop" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookShop.aspx.cs" Inherits="BooksGalore.BookShop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Style/BookShop.css" rel ="stylesheet" type="text/css" />
    
    <h1>Galore of Books</h1>
    <asp:Label ID="cartValue" runat="server"></asp:Label>
    <asp:Repeater runat="server" ID="BookCard" >
        <ItemTemplate>
            <div class="itemCard">
                <asp:Label id="bookTitle" runat="server"><%# Eval("Title") %></asp:Label>
                <asp:Label id="authorOfBook" runat="server"><%#Eval("LName")%>,<%# Eval("FName") %></asp:Label>
                <asp:Label id="priceOfBook" runat="server"><%# Eval("Price") %></asp:Label>
                <p id="reviewOfBook" ><%# Eval("UserReviews") %></p>
                <p id="publication"><%# Eval("PublicationDate") %></p>
                <p id="Categories"><%# Eval("CategoryDescription") %></p>
                 <p id="ISBN"><%# Eval("ISBN") %></p>
                <asp:button ID="addCartBtn" Text="Add to Cart" runat="server" OnClick="addCartBtn_Click"/>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    
</asp:Content>

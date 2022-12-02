<%@ Page Title="OrderPage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderPage.aspx.cs" Inherits="BooksGalore.Style.OrderPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button runat="server" Text="Place Order" OnClick="PlaceOrder" />
</asp:Content>

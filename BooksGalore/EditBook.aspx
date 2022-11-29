<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBook.aspx.cs" Inherits="BooksGalore.EditBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblUserReviews" runat="server" Text="Enter new User Review state:"></asp:Label>
    <asp:TextBox ID="txtUserReviews" runat="server" ></asp:TextBox>
    <br />
    <asp:Label ID="lblPublicationDate" runat="server" Text="Enter new Publication Date:"></asp:Label>
    <asp:TextBox ID="txtPublicationDate" runat="server" ></asp:TextBox>
    <br />
    <asp:Label ID="lblPrice" runat="server" Text="Enter new Price:"></asp:Label>
    <asp:TextBox ID="txtPrice" runat="server" ></asp:TextBox>
    <br />
    <asp:Label ID="lblTitle" runat="server" Text="Enter new Title:"></asp:Label>
    <asp:TextBox ID="txtTitle" runat="server" ></asp:TextBox>
    <br />
    <asp:Label ID="lblAuthorID" runat="server" Text="Enter new AuthorID:"></asp:Label>
    <asp:TextBox ID="txtAuthorID" runat="server" ></asp:TextBox>
    <br />
    <asp:Label ID="lblSID" runat="server" Text="Enter new Supplier ID:"></asp:Label>
    <asp:TextBox ID="txtSID" runat="server" ></asp:TextBox>
    <br />
    <asp:Label ID="lblCategoryCode" runat="server" Text="Enter new CategoryCode:"></asp:Label>
    <asp:TextBox ID="txtCategoryCode" runat="server" ></asp:TextBox>
    <br />
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
</asp:Content>

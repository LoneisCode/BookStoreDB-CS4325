<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCustomer.aspx.cs" Inherits="BooksGalore.EditCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblFName" runat="server" Text="Enter new first name:"></asp:Label>
    <asp:TextBox ID="txtFName" runat="server" OnTextChanged="txtFName_TextChanged" ></asp:TextBox>
    <br />
    <asp:Label ID="lblLName" runat="server" Text="Enter new last name:"></asp:Label>
    <asp:TextBox ID="txtLName" runat="server" OnTextChanged="txtLName_TextChanged" ></asp:TextBox>
    <br />
    <asp:Label ID="lblUName" runat="server" Text="Enter new user name:"></asp:Label>
    <asp:TextBox ID="txtUName" runat="server" OnTextChanged="txtUName_TextChanged" ></asp:TextBox>
    <br />
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
</asp:Content>

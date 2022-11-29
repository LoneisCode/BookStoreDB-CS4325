<%@ Page Title="EditAuthor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditAuthor.aspx.cs" Inherits="BooksGalore.EditAuthor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblGender" runat="server" Text="Enter new Gender:"></asp:Label>
    <asp:TextBox ID="txtGender" runat="server" ></asp:TextBox>
    <br />
    <asp:Label ID="lblFName" runat="server" Text="Enter new first name:"></asp:Label>
    <asp:TextBox ID="txtFName" runat="server" ></asp:TextBox>
    <br />
    <asp:Label ID="lblLName" runat="server" Text="Enter new last name:"></asp:Label>
    <asp:TextBox ID="txtLName" runat="server" ></asp:TextBox>
    <br />
    <asp:Label ID="lblDOB" runat="server" Text="Enter new DOB (mm/dd/yyyy):"></asp:Label>
    <asp:TextBox ID="txtDOB" runat="server" ></asp:TextBox>
    <br />
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
</asp:Content>

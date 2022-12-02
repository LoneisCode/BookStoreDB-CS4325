<%@ Page Title="BookShop" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookShop.aspx.cs" Inherits="BooksGalore.BookShop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Style/BookShop.css" rel ="stylesheet" type="text/css" />
    
    <h1>Galore of Books</h1>
    <asp:Label ID="cartValue" runat="server"></asp:Label>
    <asp:Panel runat="server">
    <asp:GridView runat="server" ID="BookRow" BackColor="#666666" ForeColor="White" OnRowCommand="BookRow_RowCommand" OnRowDataBound="BookRow_RowDataBound">
        <Columns>
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Add to Cart" CommandName="AddToCart"  CommandArgument = '<%#Eval("Title")+","+Eval("Price")+","+ Eval("ISBN")%> '/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns> 
    </asp:GridView>
    </asp:Panel>
</asp:Content>

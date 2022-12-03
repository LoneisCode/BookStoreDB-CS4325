<%@ Page Title="OrderPage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderPage.aspx.cs" Inherits="BooksGalore.Style.OrderPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Style/orderPage.css" rel="stylesheet" type="text/css" />
    <asp:Button runat="server" Text="Place Order" OnClick="PlaceOrder" />
    <asp:Button runat="server" Text="Back" OnClick="Back_Click" />
    
    <asp:Panel runat="server">
    <asp:GridView runat="server" ID="CartItemRow" BackColor="#666666" ForeColor="White" OnRowCommand="CartItemRow_RowCommand" OnRowDataBound="CartItemRow_RowDataBound">
        <Columns>
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button runat="server" CommandName ="dtlItem" Text="Delete from cart" CommandArgument='<%#Eval("id")%>'/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns> 
    </asp:GridView>
    </asp:Panel>
</asp:Content>

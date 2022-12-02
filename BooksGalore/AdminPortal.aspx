<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPortal.aspx.cs" Inherits="BooksGalore.AdminPortal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        ADMIN PORTAL
    </h1>
    <asp:Button ID="btnCustomerList" runat="server" Text="Customer List" onClick ="btnCustomerList_Click"/>
    <asp:Button ID="btnOrderList" runat="server" Text="Order List" onClick ="btnOrderList_Click" />
    <asp:Button ID="btnBookList" runat="server" Text="Book List" onClick ="btnBookList_Click"/>
    <asp:Button ID="btnSupplierList" runat="server" Text="Supplier List" onClick ="btnSupplierList_Click"/>
    <asp:Button ID="btnAuthorList" runat="server" Text="Author List" onClick ="btnAuthorList_Click"/>

    <br />
    <asp:Panel ID="pnlAdmin" runat="server">
        <asp:GridView ID="gvAdminInfo" runat="server" OnRowCommand="gvAdminInfo_RowCommand1" OnRowDataBound="gvAdminInfo_RowDataBound1">
            <Columns>
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-primary" Text="Edit" CommandName="EditRow" />
                        <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger"
                            OnClientClick="return confirm('Are you sure you want to delete this habit?')" Text="Delete" CommandName="DeleteRow" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns> 
        </asp:GridView>
    </asp:Panel>
</asp:Content>

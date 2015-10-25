<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="CreditForm.aspx.cs" Inherits="UI.CreditForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Credit</h3>
    
    <asp:Label ID="Label1" runat="server" Text="To" CssClass="label label-primary"></asp:Label>
    <br />
    <asp:DropDownList ID="ToDropdown" runat="server" Width="280px"></asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Amount" CssClass="label label-primary"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="Amount" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="ContinueCredit" OnClick="Button1_Click" CssClass="btn btn-primary" />
</asp:Content>
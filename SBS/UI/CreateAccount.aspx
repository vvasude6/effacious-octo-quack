<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="UI.CreateAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4>Request Create New Account</h4>
    <asp:DropDownList ID="AccountTypeDropDownList" runat="server">
        <asp:ListItem Selected="True">SavingsAccount</asp:ListItem>
        <asp:ListItem>Checking Account</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="AccountCreateBtn" runat="server" Text="Create" CssClass="btn btn-primary" OnClick="AccountCreate_click"/>

</asp:Content>
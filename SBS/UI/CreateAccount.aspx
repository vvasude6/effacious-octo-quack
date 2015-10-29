<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="UI.CreateAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4>Request Create New Account</h4>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        <asp:RadioButton runat="server" text=""></asp:RadioButton>
        <asp:RadioButton runat="server"></asp:RadioButton>
    </asp:RadioButtonList>
    <asp:Button ID="CustCreateBtn" runat="server" Text="Create" CssClass="btn btn-primary" OnClick="CustCreate_Click"/>

</asp:Content>

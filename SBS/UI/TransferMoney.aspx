<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TransferMoney.aspx.cs" Inherits="UI.TransferMoney" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Transfer</h3>
   <h4> <asp:Label ID="fromLabel" runat="server" Text="From" CssClass="label label-primary"></asp:Label></h4>
    <asp:DropDownList ID="FromDropDown" runat="server" width="280px" CssClass="dropdown-toggle">
    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    <h4><asp:Label ID="ToLabel" runat="server" Text="To" CssClass="label label-primary"></asp:Label></h4>
    <asp:DropDownList ID="ToDropDown" runat="server" width="280px" CssClass="dropdown-toggle">
    </asp:DropDownList>
    <br />
    <br />
    <h4><asp:Label ID="amountLabel" runat="server" Text="Amount" CssClass="label label-primary"></asp:Label></h4>
    <asp:TextBox ID="AmountTransfer" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <h4><asp:Label ID="ConfirmLabel" runat="server" Text="ConfirmAmount" CssClass="label label-primary"></asp:Label></h4>
    <asp:TextBox ID="ConfirmAmount" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <asp:Button ID="Transfer" runat="server" Text="ContinueTransfer" CssClass="btn btn-primary" OnClick="Transfer_Click" />






    

</asp:Content>

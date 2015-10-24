<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MakePayment.aspx.cs" Inherits="UI.MakePayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Payment</h3>

    <h4><asp:Label ID="PayeeLabel" runat="server" Text="Select Payee" CssClass="label label-primary"></asp:Label></h4>
    <asp:DropDownList ID="PayeeList" runat="server" CssClass="dropdown-toggle" Width="280px"></asp:DropDownList>
    <asp:Button ID="NewPayee" runat="server" Text="AddnewPayee" CssClass="btn btn-primary" />
    <h4>&nbsp;<asp:Label ID="PayLabel" runat="server" Text="Enter Amount" CssClass="label label-primary"></asp:Label></h4>
    <asp:TextBox ID="AmountPay" runat="server" CssClass="form-control"></asp:TextBox>
    <h4><asp:Label ID="ConfirmLabel" runat="server" Text="Confirm Amount" CssClass="label label-primary"></asp:Label></h4>
    <asp:TextBox ID="ConfirmPay" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <asp:Button ID="Payment" runat="server" Text="MakePayment" CssClass="btn btn-primary" OnClick="Payment_Click" />
    



    


</asp:Content>

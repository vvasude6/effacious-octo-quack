<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="CreditForm.aspx.cs" Inherits="UI.CreditForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Deposit Money</h3>

    <br />
    <br />
    <div class="input-group">
        <span class="input-group-addon">&nbsp;&nbsp;&nbsp;To Account</span>
        <asp:DropDownList ID="ToDropdown" runat="server" Width="250px" Height="35px" CssClass="form-control"></asp:DropDownList>
    </div>

    <br />
    <div class="input-group">
        <span class="input-group-addon">&nbsp;&nbsp;&nbsp;Amount ($)</span>
        <asp:TextBox ID="Amount" runat="server" class="form-control" Width="250px" TextMode="Number"></asp:TextBox>
    </div>

    <br />
    <br />

    <asp:Button ID="CreditButton" runat="server" Text="Credit Amount" OnClick="CreditButton_Click" CssClass="btn btn-default" />

</asp:Content>

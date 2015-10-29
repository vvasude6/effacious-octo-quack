<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MakePayment.aspx.cs" Inherits="UI.MakePayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Make Payment</h3>

    <br />
    <br />
    <div runat="server" id="FromCustomerDiv" class="input-group">
        <span class="input-group-addon">&nbsp;From Customer</span>
        <asp:DropDownList ID="CustomerDropDown" runat="server" Width="250px" Height="35px" CssClass="form-control"
            OnSelectedIndexChanged="CustomerDropDown_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
    </div>

    <br />
    <div class="input-group">
        <span class="input-group-addon">&nbsp;&nbsp;&nbsp;&nbsp;From Account</span>
        <asp:DropDownList ID="FromDropdown" runat="server" Width="250px" Height="35px" CssClass="form-control"></asp:DropDownList>
    </div>

    <br />
    <div class="input-group">
        <span class="input-group-addon">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To Account</span>
        <asp:DropDownList ID="ToDropdown" runat="server" Width="250px" Height="35px" CssClass="form-control"></asp:DropDownList>
    </div>

    <br />
    <div class="input-group">
        <span class="input-group-addon">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Amount ($)</span>
        <asp:TextBox ID="Amount" runat="server" class="form-control" Width="250px" TextMode="Number"></asp:TextBox>
    </div>

    <br />
    <br />

    <asp:Button ID="MakePaymentButton" runat="server" Text="Make Payment" OnClick="MakePayment_Click" CssClass="btn btn-default" />


    


</asp:Content>

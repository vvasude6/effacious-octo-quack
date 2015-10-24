<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="MerchantDisplay.aspx.cs" Inherits="UI.MerchantDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3></h3>

    <div class="panel panel-default">
        <div class="panel-heading">Accounts</div>
        <div class="panel-body">
            <ul id="MerchantAccountlist" runat="server" class="list-group">

            </ul>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-heading">Pending Transactions</div>
        <div class="panel-body">
            <table id="Transactiontable" runat="server" class="list-group">

            </table>
        </div>
    </div>

   </asp:Content>
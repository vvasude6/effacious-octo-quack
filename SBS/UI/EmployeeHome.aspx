<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EmployeeHome.aspx.cs" Inherits="UI.EmployeeHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Home</h3>
    <div class="panel panel-default">
        <div class="panel-heading">Pending Transactions</div>
        <div class="panel-body">
            <ul id="PendingTransactionList" runat="server" class="list-group">
                <li class="list-group-item"> Sample format </li>
            </ul>
        </div>
    </div>

    <div class="panel panel-default">
        <div class="panel-heading">Recent Activity</div>
        <div class="panel-body">
            No recent Activity
        </div>
    </div>
</asp:Content>

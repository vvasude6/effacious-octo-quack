<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UI.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Home</h3>


    <div class="panel panel-default">
        <div class="panel-heading">Linked Accounts</div>
        <div class="panel-body">
            <ul id="AccountList" runat="server" class="list-group">
                <li class="list-group-item"> <span class="badge">$14</span> Sample format </li>
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

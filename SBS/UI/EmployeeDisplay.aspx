<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MerchantDisplay.aspx.cs" Inherits="UI.DisplayMerchant" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">Transactions</div>
        <div class="panel-body">
            <ul id="EmpTranslist" runat="server" class="list-group">

            </ul>
        </div>
        </div>
    </form>
</body>
</html>



<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MerchantDisplay.aspx.cs" Inherits="UI.EmployeeDisplay" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Display</title>
    <link href="Content/bootstrap.min.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
         <div class="panel panel-default">
        <div class="panel-heading">Transactions</div>
        <div class="panel-body">
            <asp:table id="EmpTranslist" runat="server">

            </asp:table>
        </div>
        </div>
   
    </form>
</body>
</html>



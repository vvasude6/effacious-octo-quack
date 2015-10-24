<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="UI.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin</title>
    <link href="Content/bootstrap.min.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
      
     <asp:Button ID="UpdateProfile" runat="server" Text="UpdateProfile" CssClass="btn btn-default"/>
        <br />
        <br />
     <div class="panel panel-default">
        <div class="panel-heading">Transactions
         </div>
        <div class="panel-body">
            <ul id="AdminTranlist" runat="server" class="list-group">

            </ul>
        </div>
        </div>
    </form>
</body>
</html>

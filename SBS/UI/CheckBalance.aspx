<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckBalance.aspx.cs" Inherits="UI.CheckBalance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <div style="width: 133px; margin-left: 440px">
            <br />
            <asp:Button ID="Balancecheck" runat="server" Text="Check Balance" CssClass="bth btn-primary" OnClick="Button1_Click" />
            <br />
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </form>
</body>
</html>

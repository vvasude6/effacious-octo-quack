<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="UI.UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left: 280px">
    
    </div>
        <p>
            &nbsp;</p>
        <p style="margin-left: 440px; width: 121px; height: 13px;">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Username"></asp:Label>
&nbsp;&nbsp;&nbsp;</p>
        <p style="margin-left: 440px; width: 121px; height: 13px;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Username" runat="server" CssClass="form-control" Width="173px" ></asp:TextBox>
        </p>
        <div style="margin-left: 440px">
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Password"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <asp:TextBox ID="Password" runat="server" CssClass="form-control" Height="30px" Width="177px"></asp:TextBox>
        </div>
        <div style="margin-left: 440px">
            <br />
            <br />
            &nbsp;<asp:Button ID="login" runat="server" OnClick="Button1_Click" Text="Login" CssClass="btn btn-primary" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:LinkButton ID="Forgotpassword" runat="server" OnClick="LinkButton1_Click">Forgot Password?</asp:LinkButton>
        </div>
    </form>
</body>
</html>

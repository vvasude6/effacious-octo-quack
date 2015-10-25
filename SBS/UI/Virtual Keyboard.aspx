<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Virtual Keyboard.aspx.cs" Inherits="UI.Virtual_Keyboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBox1" runat="server" Width="485px"></asp:TextBox>
        <p>
            <asp:Button ID="Button_bquote" runat="server" OnClick="Button_Value_Click" Text="`" Width="35px" />
            <asp:Button ID="Button_1" runat="server" OnClick="Button_Value_Click" Text="1" Width="35px" />
            <asp:Button ID="Button_2" runat="server" OnClick="Button_Value_Click" Text="2" Width="35px" />
            <asp:Button ID="Button_3" runat="server" OnClick="Button_Value_Click" Text="3" Width="35px" />
            <asp:Button ID="Button_4" runat="server" OnClick="Button_Value_Click" Text="4" Width="35px" />
            <asp:Button ID="Button_5" runat="server" OnClick="Button_Value_Click" Text="5" Width="35px" />
            <asp:Button ID="Button_6" runat="server" OnClick="Button_Value_Click" Text="6" Width="35px" />
            <asp:Button ID="Button_7" runat="server" OnClick="Button_Value_Click" Text="7" Width="35px" />
            <asp:Button ID="Button_8" runat="server" OnClick="Button_Value_Click" Text="8" Width="35px" />
            <asp:Button ID="Button_9" runat="server" OnClick="Button_Value_Click" Text="9" Width="35px" />
            <asp:Button ID="Button_0" runat="server" OnClick="Button_Value_Click" Text="0" Width="35px" />
            <asp:Button ID="Button_dash" runat="server" OnClick="Button_Value_Click" Text="-" Width="35px" />
            <asp:Button ID="Button_equal" runat="server" OnClick="Button_Value_Click" Text="=" Width="35px" />
            <asp:Button ID="Button_bksp" runat="server" Text="bksp" Width="40px" />
        </p>
        <p>
            <asp:Button ID="Button_tab" runat="server" OnClick="Button_Value_Click" Text="tab" Width="40px" />
            <asp:Button ID="Button_q" runat="server" OnClick="Button_Value_Click" Text="q" Width="35px" />
            <asp:Button ID="Button_w" runat="server" OnClick="Button_Value_Click" Text="w" Width="35px" />
            <asp:Button ID="Button_e" runat="server" OnClick="Button_Value_Click" Text="e" Width="35px" />
            <asp:Button ID="Button_r" runat="server" OnClick="Button_Value_Click" Text="r" Width="35px" />
            <asp:Button ID="Button_t" runat="server" OnClick="Button_Value_Click" Text="t" Width="35px" />
            <asp:Button ID="Button_y" runat="server" OnClick="Button_Value_Click" Text="y" Width="35px" />
            <asp:Button ID="Button_u" runat="server" OnClick="Button_Value_Click" Text="u" Width="35px" />
            <asp:Button ID="Button_i" runat="server" OnClick="Button_Value_Click" Text="i" Width="35px" />
            <asp:Button ID="Button_o" runat="server" OnClick="Button_Value_Click" Text="o" Width="35px" />
            <asp:Button ID="Button_p" runat="server" OnClick="Button_Value_Click" Text="p" Width="35px" />
            <asp:Button ID="Button_obrkt" runat="server" OnClick="Button_Value_Click" Text="[" Width="35px" />
            <asp:Button ID="Button_cbrkt" runat="server" OnClick="Button_Value_Click" Text="]" Width="35px" />
            <asp:Button ID="Button_bkslsh" runat="server" OnClick="Button_Value_Click" Text="\" Width="35px" />
        </p>
        <p>
            <asp:Button ID="Button_caps" runat="server" OnClick="Button_Value_Click" Text="caps" Width="50px" />
            <asp:Button ID="Button_a" runat="server" OnClick="Button_Value_Click" Text="a" Width="35px" />
            <asp:Button ID="Button_s" runat="server" OnClick="Button_Value_Click" Text="s" Width="35px" />
            <asp:Button ID="Button_d" runat="server" OnClick="Button_Value_Click" Text="d" Width="35px" />
            <asp:Button ID="Button_f" runat="server" OnClick="Button_Value_Click" Text="f" Width="35px" />
            <asp:Button ID="Button_g" runat="server" OnClick="Button_Value_Click" Text="g" Width="35px" />
            <asp:Button ID="Button_h" runat="server" OnClick="Button_Value_Click" Text="h" Width="35px" />
            <asp:Button ID="Button_j" runat="server" OnClick="Button_Value_Click" Text="j" Width="35px" />
            <asp:Button ID="Button_k" runat="server" OnClick="Button_Value_Click" Text="k" Width="35px" />
            <asp:Button ID="Button_l" runat="server" OnClick="Button_Value_Click" Text="l" Width="35px" />
            <asp:Button ID="Button_semi" runat="server" OnClick="Button_Value_Click" Text=";" Width="35px" />
            <asp:Button ID="Button_fquote" runat="server" OnClick="Button_Value_Click" Text="'" Width="35px" />
            <asp:Button ID="Button_enter" runat="server" Text="enter" Width="60px" />
        </p>
        <p>
            <asp:Button ID="Button_lshft" runat="server" OnClick="Button_Value_Click" Text="shft" Width="72px" />
            <asp:Button ID="Button_z" runat="server" OnClick="Button_Value_Click" Text="z" Width="35px" />
            <asp:Button ID="Button_x" runat="server" OnClick="Button_Value_Click" Text="x" Width="35px" />
            <asp:Button ID="Button_c" runat="server" OnClick="Button_Value_Click" Text="c" Width="35px" />
            <asp:Button ID="Button_v" runat="server" OnClick="Button_Value_Click" Text="v" Width="35px" />
            <asp:Button ID="Button_b" runat="server" OnClick="Button_Value_Click" Text="b" Width="35px" />
            <asp:Button ID="Button_n" runat="server" OnClick="Button_Value_Click" Text="n" Width="35px" />
            <asp:Button ID="Button_m" runat="server" OnClick="Button_Value_Click" Text="m" Width="35px" />
            <asp:Button ID="Button_comma" runat="server" OnClick="Button_Value_Click" Text="," Width="35px" />
            <asp:Button ID="Button_period" runat="server" OnClick="Button_Value_Click" Text="." Width="35px" />
            <asp:Button ID="Button_frslash" runat="server" OnClick="Button_Value_Click" Text="/" Width="35px" />
            <asp:Button ID="Button_shft" runat="server" OnClick="Button_Value_Click" Text="shft" Width="72px" />
        </p>
        <p>
            <asp:Button ID="Button_space" runat="server" OnClick="Button_Value_Click" Text="space" Width="495px" />
        </p>
    </form>
</body>
</html>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OTPControl.ascx.cs" Inherits="UI.OTPControl" %>

<p>To proceed please enter the OTP that was sent to your registered Email ID</p>
<div class="input-group">
    <span class="input-group-addon" id="basic-addon3">OTP Secret</span>
    <asp:TextBox runat="server" type="text" class="form-control" ID="OTPTextBox" aria-describedby="basic-addon3"></asp:TextBox>
    <span class="input-group-btn">
        <asp:Button ID="VerifyButton" runat="server" class="btn btn-default" Text="Verify" OnClick="VerifyButton_Click"></asp:Button>
    </span>
</div>
<div style="text-align:left">
&nbsp;&nbsp;<asp:LinkButton ID="ResendOTPLink" runat="server" Text="Resend OTP" OnClick="ResendOTPLink_Click"></asp:LinkButton>
    </div>
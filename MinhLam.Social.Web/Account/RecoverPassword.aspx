<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="MinhLam.Social.Web.Account.RecoverPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="divContainerSmall">
             <asp:Panel ID="pnlRecoverPassword" runat="server">
                <fieldset class="recoverPassword">
                    <div class="divContainerTitle">
                        Please enter your email address below
                    </div>
                    <p>
                        <asp:Label ID="EmailLabel" runat="server" 
                            AssociatedControlID="txtEmail">Email:</asp:Label>
                        <asp:TextBox CssClass="textRegister" ID="txtEmail" 
                            runat="server"></asp:TextBox>
                    </p>
                    <asp:Button CssClass="recoverPwdButton" 
                        ID="btnRecoverPassword" Text="Recover Password"
                            runat="server" OnClick="btnRecoverPassword_Click" />
                </fieldset>
             </asp:Panel>
             <asp:Panel Visible="false" ID="pnlMessage" runat="server">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
             </asp:Panel>
             </div>
    </form>
</body>
</html>

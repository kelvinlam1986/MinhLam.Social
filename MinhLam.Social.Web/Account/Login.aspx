<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MinhLam.Social.Web.Account.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <label>Username:</label>
                <br />
                <asp:TextBox ID="txtUsername" runat="server" CssClass="textEntry"></asp:TextBox>
            </p>
            <p>
                <label>Password:</label>
                <br />
                <asp:TextBox ID="txtPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
            </p>
             <p class="submitButton">
                <asp:Button ID="btnLogin" CssClass="loginButton" runat="server"
                    Text="Log In" OnClick="btnLogin_Click" />
            </p>
            <asp:Label runat="server" ID="lblMessage" BackColor="Wheat" ForeColor="Red"></asp:Label>

             <p>
                <asp:LinkButton ID="lbRecoverPassword" runat="server" Text="Forgot Password?" OnClick="lbRecoverPassword_Click" />
            </p>
            <p>
                <asp:LinkButton ID="lbRegister" runat="server" Text="Register" OnClick="lbRegister_Click" />
            </p>
        </div>
        <a href="VerifyEmail.aspx?a=DVb9u8hQdy/OZ3reoPle3nRYQw9Z730IfA07OJcn33A=">Test verify account</a>
        <a href="VerifyEmail.aspx?a=abcdef5247735538">Test verify account failed</a>
    </form>
</body>
</html>

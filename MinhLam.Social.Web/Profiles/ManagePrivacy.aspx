<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagePrivacy.aspx.cs" Inherits="MinhLam.Social.Web.Profiles.ManagePrivacy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="divContainer">
            <fieldset class="formFields">
                <div class="divContainerTitle">
                    Set the visibility of each section below:
                </div>
                <div align="left">
                    Private &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp: Only you can see it
                    <br />
                    Friends Only : Only you and your friends can see it
                    <br />
                    Public &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp: Everyone can see it
                    <p />
                    <asp:PlaceHolder ID="phPrivacyFlagTypes" runat="server"></asp:PlaceHolder>
                </div>
                <div class="divContainerFooter">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                    <asp:Button CssClass="loginButton" ID="btnSave" runat="server" Text="Save Privacy Settings" OnClick="btnSave_Click" />
                </div>
            </fieldset>
        </div>
    </form>
</body>
</html>

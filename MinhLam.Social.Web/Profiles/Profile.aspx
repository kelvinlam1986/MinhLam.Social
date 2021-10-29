<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="MinhLam.Social.Web.Profiles.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="divContainerLarge" style="min-height: 210px;">
            <fieldset>
                <table width="100%">
                    <tr>
                        <td align="left">
                            <asp:Image Width="200" Height="200" ID="imgAvatar" 
                                runat="server" ImageUrl="~/Images/ProfileAvatar/ProfileImage.aspx" />
                        </td>
                        <td valign="top" align="left">
                            <asp:Label CssClass="ProfileName" ID="lblFirstName" runat="server"></asp:Label>
                            <asp:Label CssClass="ProfileName" ID="lblLastName" runat="server"></asp:Label>
                            <asp:Literal ID="litLevelOfExperience" runat="server"></asp:Literal>
                            <asp:Panel ID="pnlPrivacyAccountInfo" runat="server">
                                <fieldset>
                                    <div class="divContainerTitle">Account Info</div>
                                    <table class="profileInfo">
                                        <tr>
                                            <td>
                                                Email:
                                            </td>
                                            <td>
                                                <asp:Literal ID="litEmail" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Zip:
                                            </td>
                                            <td>
                                                <asp:Literal ID="litZip" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Birthday:
                                            </td>
                                            <td>
                                                <asp:Literal ID="litBirthDate" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Updated:
                                            </td>
                                            <td>
                                                <asp:Literal ID="litLastUpdateDate" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </asp:Panel>
                            <asp:Panel ID="pnlPrivacyTankInfo" runat="server">
                                <fieldset>
                                    <div class="divContainerTitle">Fish Facts</div>
                                    <table class="profileInfo">
                                        <tr>
                                            <td>
                                                Year of tank:
                                            </td>
                                            <td>
                                                <asp:Literal ID="litYearOfFirstTank" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                #Tanks owned:
                                            </td>
                                            <td>
                                                <asp:Literal ID="litNumberOfTanksOwned" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                #Fish owned:
                                            </td>
                                            <td>
                                                <asp:Literal ID="litNumberOfFishOwned" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Panel ID="pnlPrivacyIM" runat="server">
                                <fieldset>
                                    <div class="divContainerTitle">Contact Information</div>
                                    <table width="100%">
                                        <tr>
                                            <td width="200px">
                                                <table class="profileInfo">
                                                    <tr>
                                                        <td>
                                                            AOL:
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litIMAOL" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            MSN:
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litIMMSN" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            GIM:
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litIMGIM" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td align="left">
                                                <table class="profileInfo">
                                                    <tr>
                                                        <td>
                                                            YIM:
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litIMYIM" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            ICQ:
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litIMICQ" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Skype:
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litIMSkype" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </asp:Panel>
                        </td>
                    </tr>
                     <tr>
                        <td colspan="2" align="left">
                            <asp:PlaceHolder ID="phAttributes" runat="server"></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </form>
</body>
</html>

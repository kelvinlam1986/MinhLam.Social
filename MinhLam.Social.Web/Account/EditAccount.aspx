<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditAccount.aspx.cs" Inherits="MinhLam.Social.Web.Account.EditAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="divContainer">
            <asp:Panel ID="pnlEditAccount" runat="server">
                <fieldset>
                    <div class="divContainerTitle">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                        <asp:ValidationSummary ID="Summary" runat="server" DisplayMode="List" ForeColor="Red" />
                    </div>
                    <asp:Table ID="Table1" runat="server" CellPadding="2" EnableViewState="False" Width="300px"
                        HorizontalAlign="Center">
                         <asp:TableRow runat="server" HorizontalAlign="Right">
                            <asp:TableCell runat="server">Username:</asp:TableCell>
                            <asp:TableCell runat="server" HorizontalAlign="Left">
                                <asp:Label ID="lblUsername" runat="server" ForeColor="Gray" ViewStateMode="Enabled"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" HorizontalAlign="Right">
                            <asp:TableCell runat="server" TabIndex="1">Old Password:</asp:TableCell>
                            <asp:TableCell runat="server" HorizontalAlign="Left">
                                <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPassword"
                                    ForeColor="Red" ErrorMessage="In order to make changes to your account you need to provide your current password.">*</asp:RequiredFieldValidator>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" HorizontalAlign="Right">
                            <asp:TableCell runat="server">New Password:</asp:TableCell>
                            <asp:TableCell runat="server" TabIndex="2" HorizontalAlign="Left">
                                <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="valNewPassword" runat="server" ForeColor="Red"
                                    ControlToValidate="txtNewPassword" ValidationExpression="(?=^.{5,}$)(?=.*\d)(?=.*\W+)(?![.\n]).*$"
                                    Display="Dynamic" ErrorMessage="Your password must be at least 8 characters long and contain at
                                     least one upper case letter, one lower case letter, one number, and one special character">*</asp:RegularExpressionValidator>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" HorizontalAlign="Right">
                            <asp:TableCell runat="server">Verify Password: </asp:TableCell>
                            <asp:TableCell runat="server" TabIndex="3" HorizontalAlign="Left">
                                <asp:TextBox ID="txtVerifyPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator" runat="server" ForeColor="Red" ControlToValidate="txtNewPassword"
                                    ControlToCompare="txtVerifyPassword" ErrorMessage="The passwords you entered do no match!"
                                    Display="Dynamic">*</asp:CompareValidator>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" HorizontalAlign="Right">
                            <asp:TableCell runat="server">First Name:</asp:TableCell>
                            <asp:TableCell runat="server" TabIndex="4" HorizontalAlign="Left">
                                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow1" runat="server" HorizontalAlign="Right">
                            <asp:TableCell runat="server">Last Name:</asp:TableCell>
                            <asp:TableCell runat="server" TabIndex="5" HorizontalAlign="Left">
                                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                         <asp:TableRow ID="TableRow2" runat="server" HorizontalAlign="Right">
                            <asp:TableCell runat="server">Email:</asp:TableCell>
                            <asp:TableCell runat="server" TabIndex="6" HorizontalAlign="Left">
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valRequiredEmail" runat="server" ForeColor="Red"
                                    ControlToValidate="txtEmail" ErrorMessage="Please provide your email address!">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="valEmailInCorrectFormat" runat="server" ForeColor="Red"
                                    ErrorMessage="This does not appear to be a valid email address!" ControlToValidate="txtEmail"
                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow3" runat="server" HorizontalAlign="Right">
                            <asp:TableCell runat="server">Birthdate (MM/DD/YYYY):</asp:TableCell>
                            <asp:TableCell runat="server" TabIndex="7" HorizontalAlign="Left">
                                <asp:TextBox ID="txtBirthDate" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="valDate" runat="server" ForeColor="Red" ControlToValidate="txtBirthDate"
                                    Type="Date" Operator="DataTypeCheck" ErrorMessage="Please enter a valid date!">*</asp:CompareValidator>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow4" runat="server" HorizontalAlign="Right">
                            <asp:TableCell runat="server">Zip:</asp:TableCell>
                            <asp:TableCell runat="server" TabIndex="8" HorizontalAlign="Left">
                                <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="valZipcode" ControlToValidate="txtZipCode" runat="server"
                                    ForeColor="Red" ErrorMessage="This must be a valid US zip code!" ValidationExpression="^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z] \d[a-zA-Z]\d)$">*</asp:RegularExpressionValidator>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <asp:Button CssClass="EditAccountButton" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
                </fieldset>
            </asp:Panel>
             <asp:Panel ID="pnlSaved" runat="server">
            </asp:Panel>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MinhLam.Social.Web.Account.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="pnlCreateAccount" runat="server">
            <div class="divContainer">
                <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
                <asp:Wizard ID="wizRegister" CssClass="Wizard"
                    runat="server" ActiveStepIndex="1" BackColor="#EFF3FB" BorderColor="#B5C7DE"
                    BorderWidth="1px" Width="395px" OnActiveStepChanged="wizRegister_ActiveStepChanged" OnFinishButtonClick="wizRegister_FinishButtonClick" OnNextButtonClick="wizRegister_NextButtonClick">
                    <HeaderStyle BackColor="Wheat" BorderColor="#EFF3FB" BorderStyle="Solid" BorderWidth="2px"
                        ForeColor="White" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        <asp:ValidationSummary ID="valSummary" runat="server" HeaderText="Fix errors displayed below and try again!"
                            DisplayMode="BulletList" ForeColor="Red" />
                    </HeaderTemplate>
                     <NavigationButtonStyle BackColor="#FF9900" BorderColor="#507CD1" BorderStyle="Solid"
                            BorderWidth="1px" ForeColor="#284E98" />
                    <SideBarButtonStyle BackColor="#507CD1" ForeColor="White" />
                    <SideBarStyle BackColor="#507CD1" VerticalAlign="Top" HorizontalAlign="Left" />
                    <StepStyle Font-Size="0.8em" ForeColor="#333333" />
                    <WizardSteps>
                        <asp:WizardStep ID="wsUsernameAndPassword" runat="server" Title="1. Create Account">
                            <fieldset class="register">
                                <div class="divContainerTitle">
                                    Let&#39;s start by creating your login
                                </div>
                                <p>
                                    <asp:Label CssClass="labelRegister" ID="EmailLabel" runat="server" AssociatedControlID="txtEmail">Email:</asp:Label>
                                    <br />
                                    <asp:TextBox CssClass="textRegister" ID="txtEmail" runat="server" />
                                    <asp:RequiredFieldValidator ID="valRequiredEmail" runat="server" ControlToValidate="txtEmail"
                                        ErrorMessage="Please provide your email address!" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                                        ErrorMessage="This does not appear to be a valid email address!" ForeColor="Red"
                                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                </p>
                                <p>
                                    <asp:Label CssClass="labelRegister" ID="UsernameLabel" runat="server" AssociatedControlID="txtUsername">Username:</asp:Label>
                                    <br />
                                    <asp:TextBox CssClass="textRegister" ID="txtUsername" runat="server" />
                                    <asp:RequiredFieldValidator ID="valRequiredUsername" runat="server" ControlToValidate="txtUsername"
                                        ErrorMessage="Please provide a username!" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="valUsernameValidation" runat="server" ControlToValidate="txtUsername"
                                        ErrorMessage="Your username must be at least 6 letters or numbers and no more than 30."
                                        ForeColor="Red" ValidationExpression="^[a-zA-Z0-9.]{6,30}">*</asp:RegularExpressionValidator>
                                </p>
                                <p>
                                    <asp:Label CssClass="labelRegister" ID="PasswordLabel" runat="server" AssociatedControlID="txtPassword">Password:</asp:Label>
                                    <br />
                                    <asp:TextBox CssClass="textRegister" ID="txtPassword" runat="server" TextMode="Password" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPassword"
                                        Display="Dynamic" ErrorMessage="Your password must be at least 8 characters long and contain at
                                                 least one upper case letter, one lower case letter, one number, and one special character"
                                        ForeColor="Red" ValidationExpression="(?=^.{5,}$)(?=.*\d)(?=.*\W+)(?![.\n]).*$">*</asp:RegularExpressionValidator>
                                </p>
                                <p>
                                    <asp:Label CssClass="labelRegister" ID="VerifyPassword" runat="server" AssociatedControlID="txtVerifyPassword">Verify Password:</asp:Label>
                                    <br />
                                    <asp:TextBox CssClass="textRegister" ID="txtVerifyPassword" runat="server" TextMode="Password" />
                                    <asp:CompareValidator ID="valComparePasswords" runat="server" ControlToCompare="txtVerifyPassword"
                                        ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="The passwords you entered do no match!"
                                        ForeColor="Red">*</asp:CompareValidator>
                                </p>
                            </fieldset>
                        </asp:WizardStep>
                        <asp:WizardStep ID="wsWhoYouAre" runat="server" Title="2. About You">
                            <fieldset class="register">
                                <div class="divContainerTitle">
                                    Tell us a little bit about yourself!
                                </div>
                                <p>
                                    <asp:Label CssClass="labelRegister" ID="FirstNameLabel" runat="server" AssociatedControlID="txtFirstName">First Name:</asp:Label>
                                    <br />
                                    <asp:TextBox CssClass="textRegister" ID="txtFirstName" runat="server" />
                                    <asp:RequiredFieldValidator ID="valRequireFirstName" runat="server" ControlToValidate="txtFirstName"
                                        ErrorMessage="Please provide your first name!" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </p>
                                <p>
                                    <asp:Label CssClass="labelRegister" ID="LastNameLabel" runat="server" AssociatedControlID="txtLastName">Last Name:</asp:Label>
                                    <br />
                                    <asp:TextBox CssClass="textRegister" ID="txtLastName" runat="server" />
                                    <asp:RequiredFieldValidator ID="valRequiredLastName" runat="server" ControlToValidate="txtLastName"
                                        ErrorMessage="Please provide your last name!" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </p>
                                <p>
                                    <asp:Label CssClass="labelRegister" ID="BirthdayLabel" runat="server" AssociatedControlID="txtBirthday">Birthday (MM/DD/YYYY):</asp:Label>
                                    <br />
                                    <asp:TextBox CssClass="textRegister" ID="txtBirthday" runat="server" Text="" />
                                    <asp:CompareValidator ID="valDate" runat="server" ControlToValidate="txtBirthday"
                                        ErrorMessage="Please enter a valid date!" ForeColor="Red" Operator="DataTypeCheck"
                                        Type="Date">*</asp:CompareValidator>
                                </p>
                                <p>
                                    <asp:Label CssClass="labelRegister" ID="ZipcodeLabel" runat="server" AssociatedControlID="txtZipcode">Zipcode:</asp:Label>
                                    <br />
                                    <asp:TextBox CssClass="textRegister" ID="txtZipcode" runat="server" Text="" />
                                    <asp:RegularExpressionValidator ID="valZipcode" runat="server" ControlToValidate="txtZipcode"
                                        ErrorMessage="This must be a valid US zip code!" ForeColor="Red" ValidationExpression="^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z] \d[a-zA-Z]\d)$">*</asp:RegularExpressionValidator>
                                </p>
                            </fieldset>
                        </asp:WizardStep>
                        <asp:WizardStep ID="wsTerms" Title="3. Terms">
                            <fieldset class="register">
                                <asp:TextBox ID="txtTerms" runat="server" Columns="40" Rows="10" TextMode="MultiLine"></asp:TextBox>
                                <br />
                                <div class="divContainerTitle">
                                    <asp:CheckBox ID="chkAgreeWithTerms" runat="server" Text="I agree with the terms"
                                        Checked="True" />
                                </div>
                                <asp:Label ID="lblTermID" runat="server" Visible="false"></asp:Label>
                            </fieldset>
                        </asp:WizardStep>
                    </WizardSteps>

                </asp:Wizard>
        
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlAccountCreated" Visible="false" runat="server">
        <div class="divContainer">
            Your account was created successfully.<br />
            <br />
            <asp:Label runat="server" ForeColor="Red" Text="Email verification required!" /><br />
            There is one step left. Please go to your email account and open the verification
            email we just sent to you. There you will find a link that you must follow to verify
            your email address. Once this step has been completed you can log in.<br />
            <br />
            Thank you for signing up!
        </div>
    </asp:Panel>
    </form>
</body>
</html>

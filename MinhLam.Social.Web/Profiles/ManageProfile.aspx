<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageProfile.aspx.cs" Inherits="MinhLam.Social.Web.Profiles.ManageProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <div class="divContainerLarge">
          <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" />
          <asp:Label ID="lblProfileID" runat="server" Visible="false" />
          <asp:Label ID="lblProfileTimestamp" runat="server" Visible="false" />
          <asp:Wizard ID="wizProfile" runat="server" CssClass="Wizard" BackColor="#EFF3FB"
            BorderColor="#B5C7DE" BorderWidth="1px" Font-Names="Verdana" Width="495px"
              OnFinishButtonClick="wizProfile_FinishButtonClick"
              OnNextButtonClick="wizProfile_NextButtonClick">
              <HeaderStyle BackColor="Wheat" BorderColor="#EFF3FB" BorderStyle="Solid" BorderWidth="2px"
                ForeColor="White" HorizontalAlign="Center"/>
               <HeaderTemplate>
                    <asp:ValidationSummary ID="ErrorSummary" runat="server" ForeColor="Red" 
                        HeaderText="Fix errors displayed below and try again!"
                        DisplayMode="BulletList" />
               </HeaderTemplate>
               <NavigationButtonStyle BackColor="#FF9900" BorderColor="#507CD1" BorderStyle="Solid"
                BorderWidth="1px" ForeColor="#284E98" />
               <SideBarButtonStyle BackColor="#507CD1" ForeColor="White" />
               <SideBarStyle BackColor="#507CD1" VerticalAlign="Top" HorizontalAlign="Left"></SideBarStyle>
               <StepStyle Font-Size="0.8em" ForeColor="#333333" />
               <WizardSteps>
                   <asp:WizardStep Title="1. Tank Info" ID="wsTankInfo" runat="server">
                        <div class="divWizardStep">
                            <fieldset class="formFields">
                                <div class="divContainerTitle">
                                    Provide Information about tanks you own
                                </div>
                                <p>
                                    <asp:Label CssClass="formLabel" ID="Label" runat="server" AssociatedControlID="txtYearOfFirstTank">Year of first tank:</asp:Label>
                                    <br />
                                    <asp:TextBox CssClass="formText" ID="txtYearOfFirstTank" runat="server"></asp:TextBox>
                                    <asp:RangeValidator runat="server" ForeColor="Red" ControlToValidate="txtYearOfFirstTank"
                                        MinimumValue="1900" MaximumValue="2020" Display="Dynamic" ErrorMessage="Please enter the 4 digit year that you started your first tank!">*</asp:RangeValidator>
                                </p>
                                <p>
                                    <asp:Label CssClass="formLabel" ID="Label1" runat="server" AssociatedControlID="txtNumberOfTanksOwned">Number of tanks owned:</asp:Label>
                                    <br />
                                    <asp:TextBox CssClass="formText" ID="txtNumberOfTanksOwned" runat="server"></asp:TextBox>
                                    <asp:CompareValidator runat="server" ForeColor="Red" Operator="DataTypeCheck" ControlToValidate="txtNumberOfTanksOwned"
                                        Type="Integer" ErrorMessage="Must be a number">*</asp:CompareValidator>
                                </p>
                                <p>
                                    <asp:Label CssClass="formLabel" ID="Label2" runat="server" AssociatedControlID="txtNumberOfFishOwned">Number of fish owned:</asp:Label>
                                    <br />
                                    <asp:TextBox CssClass="formText" ID="txtNumberOfFishOwned" runat="server"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" Operator="DataTypeCheck"
                                        ControlToValidate="txtNumberOfFishOwned" Type="Integer" ErrorMessage="Must be a number">*</asp:CompareValidator>
                                </p>
                                <p>
                                    <asp:Label CssClass="formLabel" ID="Label3" runat="server" AssociatedControlID="ddlLevelOfExperience">Level of experience:</asp:Label>
                                    <br />
                                    <asp:DropDownList ID="ddlLevelOfExperience" runat="server">
                                    </asp:DropDownList>
                                </p>
                            </fieldset>
                        </div>
                    </asp:WizardStep>
                   <asp:WizardStep Title="2. Signature" ID="wsSignature" runat="server">
                        <div class="divWizardStep">
                            <fieldset class="formFields">
                                <div class="divContainerTitle">
                                    Provide your Signature
                                </div>
                                <p>
                                    <asp:Label CssClass="formLabel" ID="Label4" runat="server" AssociatedControlID="txtSignature">Your signature:</asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtSignature" TextMode="MultiLine" Columns="20" Rows="4" runat="server"></asp:TextBox>
                                </p>
                            </fieldset>
                        </div>
                    </asp:WizardStep>
                   <asp:WizardStep Title="3. Instant Messaging" ID="wsInstantMessaging" runat="server">
                        <div class="divWizardStep">
                            <fieldset class="formFields">
                                <div class="divContainerTitle">
                                    Instant Messaging Services
                                </div>
                                <p>
                                    <asp:Label CssClass="formLabel" ID="Label5" runat="server" AssociatedControlID="txtIMMSN">MSN:</asp:Label>
                                    <br />
                                    <asp:TextBox CssClass="formText" ID="txtIMMSN" runat="server"></asp:TextBox>
                                </p>
                                <p>
                                    <asp:Label CssClass="formLabel" ID="Label6" runat="server" AssociatedControlID="txtIMAOL">AOL:</asp:Label>
                                    <br />
                                    <asp:TextBox CssClass="formText" ID="txtIMAOL" runat="server"></asp:TextBox>
                                </p>
                                <p>
                                    <asp:Label CssClass="formLabel" ID="Label7" runat="server" AssociatedControlID="txtIMGIM">Google IM:</asp:Label>
                                    <br />
                                    <asp:TextBox CssClass="formText" ID="txtIMGIM" runat="server"></asp:TextBox>
                                </p>
                                <p>
                                    <asp:Label CssClass="formLabel" ID="Label8" runat="server" AssociatedControlID="txtIMYIM">Yahoo IM:</asp:Label>
                                    <br />
                                    <asp:TextBox CssClass="formText" ID="txtIMYIM" runat="server"></asp:TextBox>
                                </p>
                                <p>
                                    <asp:Label CssClass="formLabel" ID="Label9" runat="server" AssociatedControlID="txtIMICQ">ICQ #:</asp:Label>
                                    <br />
                                    <asp:TextBox CssClass="formText" ID="txtIMICQ" runat="server"></asp:TextBox>
                                </p>
                                <p>
                                    <asp:Label CssClass="formLabel" ID="Label10" runat="server" AssociatedControlID="txtIMSkype">Skype:</asp:Label>
                                    <br />
                                    <asp:TextBox CssClass="formText" ID="txtIMSkype" runat="server"></asp:TextBox>
                                </p>
                            </fieldset>
                        </div>
                    </asp:WizardStep>
                   <asp:WizardStep Title="4. About You" ID="wsAttributes" runat="server">
                       <div class="divWizardStep">
                           <fieldset class="formFields">
                               <div class="divContainerTitle">
                                   All about you
                               </div>
                               <asp:PlaceHolder ID="phAttributes" runat="server" />
                           </fieldset>
                       </div>
                   </asp:WizardStep>
               </WizardSteps>

          </asp:Wizard>
      </div>
        <script type="text/javascript">
            function MaxLength2000(sender, args) {
                if (args.Value.length > 2000) {
                    args.IsValid = false;
                    return;
                }
                args.IsValid = true;
            }
        </script>
    </form>
</body>
</html>

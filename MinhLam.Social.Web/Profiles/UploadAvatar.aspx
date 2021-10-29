<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadAvatar.aspx.cs" Inherits="MinhLam.Social.Web.Profiles.UploadAvatar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="/Scripts/cropper/lib/prototype.js"></script>
    <script type="text/javascript" src="/Scripts/cropper/lib/scriptaculous.js?load=builder,dragdrop"></script>
    <script type="text/javascript" src="/Scripts/cropper/cropper.js"></script>
    <script type="text/javascript">
        function onEndCrop( coords, dimensions ) 
        {
            $( 'hidX1' ).value = coords.x1;
            $( 'hidY1' ).value = coords.y1;
            $( 'hidX2' ).value = coords.x2;
            $( 'hidY2' ).value = coords.y2;
            $( 'hidWidth' ).value = dimensions.width;
            $( 'hidHeight' ).value = dimensions.height;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="divContainerLarge" style="min-height: 120px">
            <fieldset>
                <div class="divContainerTitle">
                    Use your Gravatar
                </div>
                <table>
                    <tr>
                        <td>
                            <asp:Image ID="Image2" ImageUrl="~/Images/ProfileAvatar/ProfileImage.aspx"
                                runat="server" Height="80px" Width="80px" BorderStyle="Dotted" BorderColor="Black"
                                BorderWidth="1px" />
                        </td>
                        <td align="left">
                            <asp:CheckBox ID="cbUseGravatar" runat="server" Text="Yes, use my Gravatar"  />
                            <br />
                            What is a Gravatar? A Gravatar is a centrally located avatar that you can take with
                                 you to participating sites, communities, and blogs.
                            <asp:HyperLink ID="HyperLink1" NavigateUrl="http://www.gravatar.com" Text="http://www.gravatar.com"
                                    runat="server" />
                            <br />
                            <div style="float: right;">
                                <asp:Button CssClass="SiteButton" ID="btnUseGravatar" runat="server" OnClick="btnUseGravatar_Click" Text="Use Gravatar" />
                            </div>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <br />
        <asp:Panel ID="pnlUpload" runat="server" Visible="true">
        <div class="divContainerLarge">
        <fieldset>
            <div class="divContainerTitle">
                Upload an avatar</div>
            <table width="100%">
                <tr>
                    <td style="width: 205px;">
                        <div style="width: 200px; height: 200px; border: solid 1px #000000; padding: 5px;">
                            Avatars can be displayed as large as 200x200 pixels (<i>the size of this box</i>).
                            It is suggested that you do not upload anything smaller or larger than this, as
                            it might stretch/shrink a bit and not look as nice as you had hoped!
                        </div>
                    </td>
                    <td valign="top">
                        <div style="padding: 5px; float: left;">
                            Avatar Path:
                        </div>
                        <br />
                        <asp:FileUpload Width="270px" Size="28" ID="fuAvatarUpload" runat="server" />
                        <p />
                        <table width="100%">
                            <tr align="right">
                                <td>
                                    <asp:Button CssClass="SiteButton" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px;">
                                    <asp:Label ForeColor="Red" ID="lblMessage" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <p />
                    </td>
                </tr>
            </table>
        </fieldset>
        </div>
    </asp:Panel>
        <asp:Panel ID="pnlCrop" runat="server" Visible="false">
        <asp:HiddenField ID="hidX1" runat="server" Value="0" />
        <asp:HiddenField ID="hidY1" runat="server" Value="0" />
        <asp:HiddenField ID="hidX2" runat="server" Value="0" />
        <asp:HiddenField ID="hidY2" runat="server" Value="0" />
        <asp:HiddenField ID="hidWidth" runat="server" Value="0" />
        <asp:HiddenField ID="hidHeight" runat="server" Value="0" />
        <div class="divContainerLarge">
            <fieldset>
            <div class="divContainerRow">
                <div class="divContainerRow">
                    <div style="width: 300px; height: 100px; float: left;">
                        <b>Now crop your avatar</b><br />
                        Images come in all shapes and sizes so we have provided you with a tool that will
                        allow you to select the section of your image that you would like to use for your
                        avatar.
                    </div>
                    <div id="previewWrap" />
                </div>
                <div>
                    <asp:Image ImageUrl="~/Images/ProfileAvatar/ProfileImage.aspx" ID="imgCropImage"
                        runat="server" />
                </div>
                <script type="text/javascript">
                    Event.observe(window, 'load', function () {
                        new Cropper.ImgWithPreview('imgCropImage',
                        {
                            previewWrap: 'previewWrap',
                            minWidth: 100,
                            minHeight: 100,
                            ratioDim: { x: 100, y: 100 },
                            displayOnInit: true,
                            onEndCrop: onEndCrop
                        });
                    });
                </script>
                <div class="divContainerFooter">
                    <asp:Button CssClass="SiteButton" ID="btnCrop" Text="Perform Crop" runat="server" OnClick="btnCrop_Click" />
                    <asp:Label ID="lblCropInfo" ForeColor="Red" runat="server"></asp:Label>
                </div>
            </div>
            </fieldset>
        </div>
    </asp:Panel>
        <asp:Panel ID="pnlApprove" runat="server" Visible="false">
        <div class="divContainerLarge">
            <fieldset>
                <div class="divContainerTitle">
                    Here is your shiny new avatar!</div>
                <div class="divContainerRow">
                    <asp:Image ImageUrl="~/Images/ProfileAvatar/ProfileImage.aspx" runat="server" />
                </div>
                <div class="divContainerFooter">
                    <asp:Button CssClass="SiteButton" ID="btnStartNew" runat="server" Text="Don't like it?" OnClick="btnStartNew_Click" />
                    <asp:Button CssClass="SiteButton" ID="btnComplete" runat="server" Text="I like it!" OnClick="btnComplete_Click" />
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    </form>
</body>
</html>

using MinhLam.Social.Application;
using MinhLam.Social.Application.Profiles;
using MinhLam.Social.Domain.Common;
using MinhLam.Social.Presentors.Profiles;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MinhLam.Social.Web.Profiles
{
    public partial class ManageProfile : System.Web.UI.Page, IManageProfileView
    {
        [Inject]
        public IProfileService ProfileService { get; set; }
        [Inject]
        public ILevelOfExperienceTypeQuery LevelOfExperienceTypeQuery { get; set; }
        [Inject]
        public IProfileAttributeTypeQuery ProfileAttributeTypeQuery { get; set; }
        [Inject]
        public IProfileQuery ProfileQuery { get; set; }
        [Inject]
        public IUserSession UserSession { get; set; }
        [Inject]
        public IRedirector Redirector { get; set; }

        private ManageProfilePresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new ManageProfilePresenter(
                ProfileService,
                LevelOfExperienceTypeQuery,
                ProfileAttributeTypeQuery,
                ProfileQuery,
                UserSession,
                Redirector
                );
            this.presenter.Init(this, IsPostBack);
        }

        protected void wizProfile_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            var currentProfile = this.presenter.GetProfile();
            int numberOfFishOwned = 0;
            int numberOfTanksOwned = 0;
            int yearOffFirstTank = 0;

            if (!string.IsNullOrEmpty(txtNumberOfFishOwned.Text))
                numberOfFishOwned = Convert.ToInt32(txtNumberOfFishOwned.Text);

            if (!string.IsNullOrEmpty(txtNumberOfTanksOwned.Text))
                numberOfTanksOwned = Convert.ToInt32(txtNumberOfTanksOwned.Text);

            if (!string.IsNullOrEmpty(txtYearOfFirstTank.Text))
                yearOffFirstTank = Convert.ToInt32(txtYearOfFirstTank.Text);

            var profileAttributes = this.ExtractAttributes();

            if (currentProfile == null)
            {
                this.presenter.NewProfle(
                    txtIMAOL.Text,
                    txtIMICQ.Text,
                    txtIMGIM.Text,
                    txtIMMSN.Text,
                    txtIMSkype.Text,
                    txtIMYIM.Text,
                    Guid.Parse(ddlLevelOfExperience.SelectedValue),
                    yearOffFirstTank,
                    numberOfTanksOwned,
                    numberOfFishOwned,
                    txtSignature.Text,
                    profileAttributes
                    );
            }
            else
            {
                this.presenter.UpdateProfile(
                    txtIMAOL.Text,
                    txtIMICQ.Text,
                    txtIMGIM.Text,
                    txtIMMSN.Text,
                    txtIMSkype.Text,
                    txtIMYIM.Text,
                    Guid.Parse(ddlLevelOfExperience.SelectedValue),
                    yearOffFirstTank,
                    numberOfTanksOwned,
                    numberOfFishOwned,
                    txtSignature.Text,
                    profileAttributes);
            }
        }

        protected void wizProfile_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            lblErrorMessage.Text = "";
        }

        public void LoadLevelOfExperienceTypes(List<GetLevelOfExperienceTypeListReadModel> listOfLevelExperience)
        {
            ddlLevelOfExperience.Items.Clear();
            foreach (var type in listOfLevelExperience)
            {
                ListItem li = new ListItem(type.Name, type.Id.ToString());
                ddlLevelOfExperience.Items.Add(li);
            }
        }

        public void LoadProfile(GetCurrentProfileReadModel currentProfile)
        {
            if (currentProfile != null)
            {
                lblProfileID.Text = currentProfile.Id.ToString();
                txtIMAOL.Text = currentProfile.AolAccountName;
                txtIMGIM.Text = currentProfile.GoogleAccountName;
                txtIMICQ.Text = currentProfile.IcqAccountName;
                txtIMMSN.Text = currentProfile.MsnAccountName;
                txtIMSkype.Text = currentProfile.SkypeAccountName;
                txtIMYIM.Text = currentProfile.YahooAccountName;
                txtNumberOfFishOwned.Text = currentProfile.NumberOfFishOwned.ToString();
                txtNumberOfTanksOwned.Text = currentProfile.NumberOfTanksOwned.ToString();
                txtSignature.Text = currentProfile.Signature;
                txtYearOfFirstTank.Text = currentProfile.YearOfFirstTank.ToString();

                foreach (ListItem item in ddlLevelOfExperience.Items)
                {
                    if (item.Value == currentProfile.LevelOfExperienceId.ToString())
                        item.Selected = true;
                }

                if (currentProfile.Attributes.Count > 0)
                {
                    foreach (var attribute in currentProfile.Attributes)
                    {
                        Label lblProfileAttributeID =
                            phAttributes.FindControl("lblProfileAttributeID" +
                                                     attribute.ProfileAttributeTypeId.ToString()) as Label;
                        if (lblProfileAttributeID != null)
                        {
                            lblProfileAttributeID.Text = attribute.ProfileAttributeId.ToString();
                        }

                        TextBox txtProfileAttribute =
                            phAttributes.FindControl("txtProfileAttribute" + attribute.ProfileAttributeTypeId.ToString()) as
                            TextBox;
                        if (txtProfileAttribute != null)
                        {
                            txtProfileAttribute.Text = attribute.Response;
                        }
                    }
                }
            }
        }

        public void LoadProfileAttributeTypes(List<GetProfileAttributeTypeReadModel> listOfProfileAttributeType)
        {
            foreach (var type in listOfProfileAttributeType)
            {
                Label label = new Label();
                label.ID = "lblAttribute" + type.Id.ToString();
                label.Text = type.Name;
                label.CssClass = "formLabel";

                Label lblAttributeTypeID = new Label();
                lblAttributeTypeID.ID = "lblAttributeTypeID" + type.Id.ToString();
                lblAttributeTypeID.Text = type.Id.ToString();
                lblAttributeTypeID.Visible = false;

                Label lblProfileAttributeID = new Label();
                lblProfileAttributeID.ID = "lblProfileAttributeID" + type.Id.ToString();
                lblProfileAttributeID.Visible = false;

                TextBox tb = new TextBox();
                tb.ID = "txtProfileAttribute" + type.Id.ToString();
                tb.TextMode = TextBoxMode.MultiLine;
                tb.Columns = 40;
                tb.Rows = 2;

                CustomValidator cv = new CustomValidator();
                cv.ControlToValidate = "txtProfileAttribute" + type.Id.ToString();
                cv.ClientValidationFunction = "MaxLength2000";
                cv.ErrorMessage = "This field can only be 2000 characters long!";
                cv.Text = "*";
                cv.ForeColor = System.Drawing.Color.Red;

                phAttributes.Controls.Add(lblAttributeTypeID);
                phAttributes.Controls.Add(lblProfileAttributeID);
                phAttributes.Controls.Add(label);
                phAttributes.Controls.Add(new LiteralControl("<br />"));
                phAttributes.Controls.Add(tb);
                phAttributes.Controls.Add(cv);
                phAttributes.Controls.Add(new LiteralControl("<br />"));
            }
        }

        public void ShowMessage(string message)
        {
            this.lblErrorMessage.Text = message;
        }

        private List<InputProfileAttribute> ExtractAttributes()
        {
            List<InputProfileAttribute> attributes = new List<InputProfileAttribute>();
            foreach (var type in this.presenter.GetProfileAttributeTypes())
            {
                Label lblAttributeTypeID = phAttributes.FindControl("lblAttributeTypeID" + type.Id.ToString()) as Label;
                Label lblProfileAttributeID =
                    phAttributes.FindControl("lblProfileAttributeID" + type.Id.ToString()) as Label;

                TextBox txtProfileAttribute = phAttributes.FindControl("txtProfileAttribute" + type.Id.ToString()) as TextBox;
                var pa = new InputProfileAttribute();
                if (!string.IsNullOrEmpty(lblProfileAttributeID.Text))
                    pa.Id = Guid.Parse(lblProfileAttributeID.Text);
                else
                    pa.Id = Guid.Empty;

                pa.ProfileAtributeTypeId = Guid.Parse(lblAttributeTypeID.Text);
                pa.Response = txtProfileAttribute.Text;
                attributes.Add(pa);
            }
            return attributes;
        }

    }
}
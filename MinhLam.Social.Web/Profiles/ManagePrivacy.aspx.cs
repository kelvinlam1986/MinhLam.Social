using MinhLam.Social.Application;
using MinhLam.Social.Application.Profiles;
using MinhLam.Social.Domain.Common;
using MinhLam.Social.Domain.Profiles;
using MinhLam.Social.Presentors.Profiles;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MinhLam.Social.Web.Profiles
{
    public partial class ManagePrivacy : System.Web.UI.Page, IManagePrivacyView
    {
        private ManagePrivacyPresenter presenter;

        [Inject]
        public IProfileService ProfileService { get; set; }

        [Inject]
        public IPrivacyFlagRepository PrivacyFlagRepository { get; set; }

        [Inject]
        public IPrivacyFlagTypeQuery PrivacyFlagTypeQuery { get; set; }

        [Inject]
        public IVisibilityQuery VisibilityQuery { get; set; }

        [Inject]
        public IPrivacyFlagQuery PrivacyFlagQuery { get; set; }

        [Inject]
        public IUserSession UserSession { get; set; }

        [Inject]
        public IRedirector Redirector { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new ManagePrivacyPresenter(
                ProfileService,
                PrivacyFlagRepository,
                PrivacyFlagTypeQuery,
                VisibilityQuery,
                PrivacyFlagQuery,
                UserSession,
                Redirector
                );
            presenter.Init(this, IsPostBack);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            foreach (var type in this.presenter.GetPrivacyFlagTypes())
            {
                DropDownList ddlVisibility =
                    phPrivacyFlagTypes.FindControl("ddlVisibility" + type.Id.ToString()) as DropDownList;
                if (ddlVisibility != null)
                {
                    this.presenter.SavePrivacyFlag(type.Id, Guid.Parse(ddlVisibility.SelectedValue));
                }
            }

        }

        public void ShowMessage(string message)
        {
            this.lblMessage.Text = message;
        }

        public void ShowPrivacyTypes(
            List<GetPrivacyFlagTypeListReadModel> privacyFlagTypes, 
            List<GetVisibilityListReadModel> visibilies, 
            List<GetPrivacyFlagListByProfileReadModel> privacyFlags)
        {
            foreach (var type in privacyFlagTypes)
            {
                // Add the field name to the display
                phPrivacyFlagTypes.Controls.Add(new LiteralControl("<p>"));
                Label lbl = new Label();
                lbl.Text = type.FieldName + ":";
                lbl.Width = 100;
                phPrivacyFlagTypes.Controls.Add(lbl);

                // Create the visibility drop down
                DropDownList ddlVisibility = new DropDownList();
                ddlVisibility.ID = "ddlVisibility" + type.Id.ToString();
                foreach (var level in visibilies)
                {
                    ListItem li = new ListItem(level.Name, level.Id.ToString());
                    if (!IsPostBack)
                    {
                        li.Selected 
                            = this.presenter.IsFlagSelected(type.Id, level.Id, privacyFlags);
                    }

                    ddlVisibility.Items.Add(li);
                }

                // If the first time add privacy flag
                if (privacyFlags.Count == 0)
                {
                    if (ddlVisibility.Items.Count > 0)
                    {
                        ddlVisibility.Items[0].Selected = true;
                    }
                }

                phPrivacyFlagTypes.Controls.Add(ddlVisibility);
                phPrivacyFlagTypes.Controls.Add(new LiteralControl("</p>"));
            }
        }
    }
}
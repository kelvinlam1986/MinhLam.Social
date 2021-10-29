using MinhLam.Social.Application;
using MinhLam.Social.Application.Profiles;
using MinhLam.Social.Domain.Common;
using MinhLam.Social.Domain.Profiles;
using MinhLam.Social.Presentors.Profiles;
using Ninject;
using System;

namespace MinhLam.Social.Web.Profiles
{
    public partial class UploadAvatar : System.Web.UI.Page, IUploadAvatarView
    {
        [Inject]
        public IProfileService ProfileService { get; set; }

        [Inject]
        public IUserSession UserSession { get; set; }

        [Inject]
        public IRedirector Redirector { get; set; }

        [Inject]
        public IProfileRepository ProfileRepository { get; set; }

        
        private UploadAvatarPresenter presenter;


        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new UploadAvatarPresenter(
                ProfileService,
                UserSession,
                Redirector,
                ProfileRepository);
            presenter.Init(this, IsPostBack);
        }

        protected void btnUseGravatar_Click(object sender, EventArgs e)
        {
            presenter.UseGravatar(cbUseGravatar.Checked);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (fuAvatarUpload.PostedFile != null || 
                string.IsNullOrEmpty(fuAvatarUpload.PostedFile.FileName) == false)
            {
                this.presenter.UploadFile(fuAvatarUpload.PostedFile);
            }
        }

        protected void btnCrop_Click(object sender, EventArgs e)
        {
            this.presenter.CropFile(
                Convert.ToInt32(hidX1.Value),
                Convert.ToInt32(hidY1.Value),
                Convert.ToInt32(hidWidth.Value),
                Convert.ToInt32(hidHeight.Value));
        }

        protected void btnStartNew_Click(object sender, EventArgs e)
        {
            this.presenter.StartNewAvatar();
        }

        protected void btnComplete_Click(object sender, EventArgs e)
        {
            this.presenter.Complete();
        }

        public void InitGravatar(bool useGravatar)
        {
            cbUseGravatar.Checked = useGravatar;
        }

        public void ShowMessage(string message)
        {
            this.lblMessage.Text = message;
        }

        public void ShowCropPanel()
        {
            pnlCrop.Visible = true;
            pnlUpload.Visible = false;
            pnlApprove.Visible = false;
        }

        public void ShowApprovePanel()
        {
            pnlCrop.Visible = false;
            pnlUpload.Visible = false;
            pnlApprove.Visible = true;
        }

        public void ShowUploadPanel()
        {
            pnlCrop.Visible = false;
            pnlUpload.Visible = true;
            pnlApprove.Visible = false;
        }
    }
}
using MinhLam.Framework;
using MinhLam.Social.Application;
using MinhLam.Social.Application.Profiles;
using MinhLam.Social.Domain.Common;
using MinhLam.Social.Domain.Profiles;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace MinhLam.Social.Presentors.Profiles
{
    public class UploadAvatarPresenter
    {
        private IUploadAvatarView view;
        private IProfileService profileService;
        private IUserSession userSession;
        private IRedirector redirector;
        private IProfileRepository profileRepository;
        private Profile profile;

        public UploadAvatarPresenter(
            IProfileService profileService,
            IUserSession userSession,
            IRedirector redirector,
            IProfileRepository profileRepository)
        {
            this.profileService = profileService;
            this.profileRepository = profileRepository;
            this.userSession = userSession;
            this.redirector = redirector;
        }

        public void Init(IUploadAvatarView view, bool isPostBack)
        {
            this.view = view;
            if (userSession.CurrentUser == null)
            {
                redirector.GoToAccountLoginPage();
                return;
            }
            else
            {
                var profileId = userSession.CurrentUser.ProfileId;
                if (profileId == null || profileId == Guid.Empty)
                {
                    redirector.GoToAccountLoginPage();
                    return;
                }

                profile = profileRepository.GetById(profileId);
                if (profile == null)
                {
                    redirector.GoToAccountLoginPage();
                    return;
                }

                if (!isPostBack)
                {
                    this.view.InitGravatar(profile.UseGravatar);
                }
            }
        }

        public void UploadFile(HttpPostedFile file)
        {
            string extension = Path.GetExtension(file.FileName).ToLower();
            string mimeType;
            byte[] uploadedImage = new byte[file.InputStream.Length];
            switch (extension)
            {
                case ".png":
                case ".jpg":
                case ".gif":
                    mimeType = file.ContentType;
                    break;

                default:
                    this.view.ShowMessage("We only accept .png, .jpg and .gif");
                    return;
            }

            if (file.ContentLength / 1000 < 1000)
            {
                file.InputStream.Read(uploadedImage, 0, uploadedImage.Length);
                try
                {
                    var uploadAvatarCommand = new UploadAvatarCommand(
                        profile.Id,
                        uploadedImage,
                        mimeType
                        );
                    this.profileService.Handle(uploadAvatarCommand);
                    this.view.ShowCropPanel();
                }
                catch (DomainException e)
                {
                    this.view.ShowMessage(e.Message);
                    return;
                }
                catch (ApplicationException e)
                {
                    this.view.ShowMessage(e.Message);
                    return;
                }
                catch (Exception)
                {
                    this.view.ShowMessage("System has some wrong operation.Please contact administrator");
                    return;
                }
            }
            else
            {
                this.view.ShowMessage("The file you uploaded is larger than the 1mb limit. " +
                    "Please reduce the size of your file and try again.");
            }
        }

        public void CropFile(int x, int y, int width, int height)
        {
            byte[] imageBytes = profile.Avatar;
            byte[] bytes;
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image img = Image.FromStream(ms, true);
                Bitmap bmpCropped = new Bitmap(200, 200);
                Graphics g = Graphics.FromImage(bmpCropped);
                Rectangle recDestination = new Rectangle(0, 0, bmpCropped.Width, bmpCropped.Height);
                Rectangle rectCropArea = new Rectangle(x, y, width, height);
                g.DrawImage(img, recDestination, rectCropArea, GraphicsUnit.Pixel);
                g.Dispose();
                MemoryStream stream = new MemoryStream();
                bmpCropped.Save(stream, ImageFormat.Jpeg);
                bytes = stream.ToArray();
            }

            try
            {
                var cropFileCommand = new CropAvatarFileCommand(profile.Id, bytes);
                this.profileService.Handle(cropFileCommand);
                this.view.ShowApprovePanel();
            }
            catch (DomainException e)
            {
                this.view.ShowMessage(e.Message);
                return;
            }
            catch (ApplicationException e)
            {
                this.view.ShowMessage(e.Message);
                return;
            }
            catch (Exception)
            {
                this.view.ShowMessage("System has some wrong operation.Please contact administrator");
                return;
            }
        }

        public void UseGravatar(bool isUse)
        {
            if (isUse)
            {
                try
                {
                    var setUseGravatarCommand = new SetUseGravatarCommand(profile.Id);
                    this.profileService.Handle(setUseGravatarCommand);
                    // _alertService.AddNewAvatarAlert();
                    redirector.GoToProfilesProfile();
                }
                catch (DomainException e)
                {
                    this.view.ShowMessage(e.Message);
                    return;
                }
                catch (ApplicationException e)
                {
                    this.view.ShowMessage(e.Message);
                    return;
                }
                catch (Exception)
                {
                    this.view.ShowMessage("System has some wrong operation.Please contact administrator");
                    return;
                }

            }
            else
            {
                this.view.ShowMessage("Did you mean to check the box?");
            }
          
        }

        public void Complete()
        {
            this.redirector.GoToProfilesProfile();
        }

        public void StartNewAvatar()
        {
            this.view.ShowUploadPanel();
        }
    }
}

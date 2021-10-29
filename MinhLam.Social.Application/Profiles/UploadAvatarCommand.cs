using System;

namespace MinhLam.Social.Application.Profiles
{
    public class UploadAvatarCommand
    {
        public UploadAvatarCommand(Guid profileId, byte[] uploadFile, string mimeType)
        {
            this.ProfileId = profileId;
            this.UploadFile = uploadFile;
            this.MimeType = mimeType;
        }

        public Guid ProfileId { get; set; }
        public byte[] UploadFile { get; set; }
        public string MimeType { get; set; }
    }
}

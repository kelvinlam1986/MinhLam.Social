using System;

namespace MinhLam.Social.Application.Profiles
{
    public class CropAvatarFileCommand
    {
        public CropAvatarFileCommand(
            Guid profileId,
            byte[] croppedFile)
        {
            this.ProfileId = profileId;
            this.CroppedFile = croppedFile;
        }

        public Guid ProfileId { get; set; }
        public byte[] CroppedFile { get; set; }
    }
}

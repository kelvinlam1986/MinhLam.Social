namespace MinhLam.Social.Presentors.Profiles
{
    public interface IUploadAvatarView
    {
        void InitGravatar(bool useGravatar);
        void ShowMessage(string message);
        void ShowCropPanel();
        void ShowApprovePanel();
        void ShowUploadPanel();
    }
}

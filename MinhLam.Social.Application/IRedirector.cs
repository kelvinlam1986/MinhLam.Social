namespace MinhLam.Social.Application
{
    public interface IRedirector 
    {
        void GoToHomePage();
        void GoToAccountRegisterPage();
        void GoToAccountRecoverPasswordPage();
        void GoToAccountLoginPage();
        void GoToProfilesProfile();
        void GoToProfilesDefault();
        void GoToProfilesManageProfile();

    }
   
}


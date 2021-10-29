using MinhLam.Framework;
using MinhLam.Social.Domain.Common;
using MinhLam.Social.Domain.Memberships;
using System;

namespace MinhLam.Social.Application.Memberships
{
    public class AccountService : IAccountService
    {
        private IAccountSignIn signIn;
        private IRedirector redirector;
        private IAccountCheckExisting accountCheckExisting;
        private ITermCheckExisting termCheckExisting;
        private IAccountRepository accountRepository;
        private IPermissionDefault permissionDefault;
        private IMembershipProfileQuery membershipProfileQuery;
        private ISendEmail sendEmail;
        private IUserSession userSession;
        private IUnitOfWork unitOfWork;

        public AccountService(
            IAccountSignIn signIn,
            IRedirector redirector,
            IAccountCheckExisting accountCheckExisting,
            ITermCheckExisting termCheckExisting,
            IPermissionDefault permissionDefault,
            IMembershipProfileQuery membershipProfileQuery,
            ISendEmail sendEmail,
            IUserSession userSession,
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork)
        {
            this.signIn = signIn;
            this.redirector = redirector;
            this.accountCheckExisting = accountCheckExisting;
            this.termCheckExisting = termCheckExisting;
            this.permissionDefault = permissionDefault;
            this.sendEmail = sendEmail;
            this.accountRepository = accountRepository;
            this.unitOfWork = unitOfWork;
            this.userSession = userSession;
            this.membershipProfileQuery = membershipProfileQuery;
        }

        public void Handle(object command)
        {
            switch(command)
            {
                case LoginCommand cmd:
                    HandleLogin(cmd);
                    break;
                case RegisterCommand cmd:
                    HandleRegister(cmd);
                    break;
                case VerifyEmailCommand cmd:
                    HandleVerifyEmail(cmd);
                    break;
                case RecoverPasswordCommand cmd:
                    HandleRecoverPassword(cmd);
                    break;
                case UpdateAccountCommand cmd:
                    HandleUpdateAccount(cmd);
                    break;
            }
        }

        private void HandleUpdateAccount(UpdateAccountCommand cmd)
        {
            Account account = this.accountRepository.GetAccountByUsername(cmd.Username);
            if (account == null)
            {
                throw new ApplicationServiceException(MembershipAppExceptionCodes.UserNotFound,
                  "We couldn't find the account you requested");
            }

            try
            {
                var oldPassword = Password.NewFromOriginal(cmd.OldPassword);
                var username = Username.New(cmd.Username);
                var email = UserEmail.New(cmd.Email);
                Password newPassword = Password.EmptyPassword;
                if (string.IsNullOrWhiteSpace(cmd.NewPassword) == false)
                {
                    newPassword = Password.NewFromOriginal(cmd.NewPassword);
                }
                var birthDate = BirthDate.NewBirthDateFromStringFormatMMDDYYY(cmd.BirthDate);
                var zipCode = ZipCode.New(cmd.ZipCode);

                account.UpdateAccount(
                    oldPassword,
                    username,
                    email,
                    newPassword,
                    cmd.FirstName,
                    cmd.LastName,
                    birthDate,
                    zipCode,
                    accountCheckExisting);

                this.accountRepository.Update(account);
                this.unitOfWork.Commit();

                if (account.EmailVerified == false)
                {
                    this.sendEmail.SendVerificationEmail(account.UserName.Value, account.Email.Value);
                }

                var currentProfile = this.membershipProfileQuery.GetCurrentProfile(account.Id);
                var profileId = Guid.Empty;
                if (currentProfile != null)
                {
                    profileId = currentProfile.ProfileId;
                }


                    var currentUserProfile = new SharedAccountProfile(
                               account.Id,
                               account.UserName.Value,
                               account.Email.Value,
                               account.EmailVerified,
                               account.BirthDate.ToMMDDYYYYString(),
                               account.FirstName,
                               account.LastName,
                               account.ZipCode.ToString(),
                               profileId);
                this.userSession.IsLoggedIn = true;
                this.userSession.Username = account.UserName.Value;
                this.userSession.CurrentUser = currentUserProfile;

            }
            catch (DomainException e)
            {
                switch(e.Code)
                {
                    case CommonExceptionCodes.EmailIsEmpty:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.EmailIsBlank,
                            "Please provide your email address!");

                    case CommonExceptionCodes.EmailIsNotCorrectFormat:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.EmailIsNotCorrectFormat,
                            "This does not appear to be a valid email address!");

                    case MembershipExceptionCodes.EmailIsNull:
                        throw new ApplicationServiceException(
                          e, MembershipAppExceptionCodes.SystemException,
                           "System has some wrong operation. Please contact administrator");

                    case MembershipExceptionCodes.UsernameIsBlank:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.UsernameIsBlank, "Please provide a username!");

                    case MembershipExceptionCodes.UserNameIsNotCorrectFormat:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.UsernameIsNotCorrectFormat,
                            "Your username must be at least 6 letters or numbers and no more than 30.");

                    case MembershipExceptionCodes.UsernameIsNull:
                        throw new ApplicationServiceException(
                           e, MembershipAppExceptionCodes.SystemException,
                            "System has some wrong operation. Please contact administrator");

                    case MembershipExceptionCodes.PasswordIsBlank:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.PasswordIsBlank, "Please fill your password");

                    case MembershipExceptionCodes.PasswordIsNotCorrectFormat:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.PaswordIsNotCorrectFormat,
                            "Your password must be at least 8 characters long and contain at " +
                            "least one upper case letter, one lower case letter, one number, and one special character");

                    case MembershipExceptionCodes.PasswordIsNull:
                        throw new ApplicationServiceException(
                          e, MembershipAppExceptionCodes.SystemException,
                           "System has some wrong operation. Please contact administrator");

                    case MembershipExceptionCodes.FirstNameIsBlank:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.FirstNameIsBlank,
                            "Please provide your first name!");

                    case MembershipExceptionCodes.LastNameIsBlank:
                        throw new ApplicationServiceException(
                            e, MembershipExceptionCodes.LastNameIsBlank,
                            "Please provide your last name!");

                    case MembershipExceptionCodes.BirthDateIsNull:
                        throw new ApplicationServiceException(
                         e, MembershipAppExceptionCodes.SystemException,
                          "System has some wrong operation. Please contact administrator");

                    case CommonExceptionCodes.BirthDateIsNotCorrectFormat:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.BirthDateIsNotCorrectFormat,
                            "Please enter a valid date!");

                    case MembershipExceptionCodes.ZipCodeIsNull:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.SystemException,
                             "System has some wrong operation. Please contact administrator");

                    case CommonExceptionCodes.ZipCodeUSInvalid:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.ZipCodeUSInvalid,
                            "This must be a valid US zip code!");

                    case MembershipExceptionCodes.UserAlreadyExistWithEmail:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.UserAlreadyExistWithEmail,
                            "This email is already in use!");

                    case MembershipExceptionCodes.UserNotFound:
                        throw new ApplicationServiceException(MembershipAppExceptionCodes.UserNotFound,
                            "We couldn't find the account you requested");

                    case MembershipExceptionCodes.OldPasswordNotMatchEnterPassword:
                        throw new ApplicationServiceException(
                            MembershipAppExceptionCodes.OldPasswordNotMatchEnterPassword,
                            "The password you entered doesn't match your current password!  Please try again.");
                }
            }
            catch (Exception e)
            {
                throw new ApplicationServiceException(
                  e, MembershipAppExceptionCodes.SystemException,
                  "System has some wrong operation. Please contact administrator");
            }
            
        }

        private void HandleRecoverPassword(RecoverPasswordCommand cmd)
        {
            Account account = this.accountRepository.GetAccountByEmail(cmd.Email);
            if (account == null)
            {
                throw new ApplicationServiceException(MembershipAppExceptionCodes.UserNotFound,
                    "We couldn't find the account you requested");
            }

            sendEmail.SendPasswordReminder(account.Email.Value, account.Password.Value, account.UserName.Value);
        }

        private void HandleVerifyEmail(VerifyEmailCommand cmd)
        {
            Account account = this.accountRepository.GetAccountByUsername(cmd.Username);
            if (account == null)
            {
                throw new ApplicationServiceException(MembershipAppExceptionCodes.UserNotFound,
                    "There appears to be something wrong " +
                    "with your verification link! Please try again.If " +
                    "you are having issues by clicking on the link, please " +
                    "try copying the URL from your email and pasting it " +
                    "into your browser window.");
            }

            try
            {
                account.VerifyEmail();
                this.accountRepository.Update(account);
                this.unitOfWork.Commit();
            }
            catch (DomainException e)
            {
                if (e.Code == MembershipExceptionCodes.UserNotFound)
                {
                    throw new ApplicationServiceException(MembershipAppExceptionCodes.UserNotFound,
                    "There appears to be something wrong " +
                    "with your verification link! Please try again.If " +
                    "you are having issues by clicking on the link, please " +
                    "try copying the URL from your email and pasting it " +
                    "into your browser window.");
                }
            }
            catch (Exception e)
            {
                throw new ApplicationServiceException(
                  e, MembershipAppExceptionCodes.SystemException,
                  "System has some wrong operation. Please contact administrator");
            }
        }

        private void HandleRegister(RegisterCommand cmd)
        {
            try
            {
                var username = Username.New(cmd.UserName);
                var password = Password.NewFromOriginal(cmd.Password);
                var birthDate = BirthDate.NewBirthDateFromStringFormatMMDDYYY(cmd.BirthDate);
                var zipCode = ZipCode.New(cmd.ZipCode);
                var email = UserEmail.New(cmd.Email);
                var registerAccount = Account.NewForRegisterAcount(
                    username,
                    password,
                    email,
                    cmd.FirstName,
                    cmd.LastName,
                    birthDate,
                    zipCode,
                    Guid.Parse(cmd.TermId),
                    accountCheckExisting,
                    termCheckExisting,
                    permissionDefault);
                this.accountRepository.Add(registerAccount);
                this.unitOfWork.Commit();
                this.sendEmail.SendVerificationEmail(registerAccount.UserName.Value, registerAccount.Email.Value);
            }
            catch(DomainException e)
            {
                switch (e.Code)
                {
                    case CommonExceptionCodes.EmailIsEmpty:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.EmailIsBlank,
                            "Please provide your email address!");

                    case CommonExceptionCodes.EmailIsNotCorrectFormat:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.EmailIsNotCorrectFormat,
                            "This does not appear to be a valid email address!");

                    case MembershipExceptionCodes.EmailIsNull:
                        throw new ApplicationServiceException(
                          e, MembershipAppExceptionCodes.SystemException,
                           "System has some wrong operation. Please contact administrator");

                    case MembershipExceptionCodes.UsernameIsBlank:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.UsernameIsBlank, "Please provide a username!");

                    case MembershipExceptionCodes.UserNameIsNotCorrectFormat:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.UsernameIsNotCorrectFormat,
                            "Your username must be at least 6 letters or numbers and no more than 30.");

                    case MembershipExceptionCodes.UsernameIsNull:
                        throw new ApplicationServiceException(
                           e, MembershipAppExceptionCodes.SystemException,
                            "System has some wrong operation. Please contact administrator");

                    case MembershipExceptionCodes.PasswordIsBlank:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.PasswordIsBlank, "Please fill your password");

                    case MembershipExceptionCodes.PasswordIsNotCorrectFormat:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.PaswordIsNotCorrectFormat,
                            "Your password must be at least 8 characters long and contain at " +
                            "least one upper case letter, one lower case letter, one number, and one special character");

                    case MembershipExceptionCodes.PasswordIsNull:
                        throw new ApplicationServiceException(
                          e, MembershipAppExceptionCodes.SystemException,
                           "System has some wrong operation. Please contact administrator");

                    case MembershipExceptionCodes.FirstNameIsBlank:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.FirstNameIsBlank,
                            "Please provide your first name!");

                    case MembershipExceptionCodes.LastNameIsBlank:
                        throw new ApplicationServiceException(
                            e, MembershipExceptionCodes.LastNameIsBlank,
                            "Please provide your last name!");

                    case MembershipExceptionCodes.BirthDateIsNull:
                        throw new ApplicationServiceException(
                         e, MembershipAppExceptionCodes.SystemException,
                          "System has some wrong operation. Please contact administrator");

                    case CommonExceptionCodes.BirthDateIsNotCorrectFormat:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.BirthDateIsNotCorrectFormat,
                            "Please enter a valid date!");

                    case MembershipExceptionCodes.ZipCodeIsNull:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.SystemException,
                             "System has some wrong operation. Please contact administrator");

                    case CommonExceptionCodes.ZipCodeUSInvalid:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.ZipCodeUSInvalid,
                            "This must be a valid US zip code!");

                    case MembershipExceptionCodes.UserAlreadyExistWithUserName:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.UserAlreadyExistWithUserName,
                            "This username is already in use!");

                    case MembershipExceptionCodes.UserAlreadyExistWithEmail:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.UserAlreadyExistWithEmail,
                            "This email is already in use!");

                    case MembershipExceptionCodes.TermNotFound:
                        throw new ApplicationServiceException(e, MembershipAppExceptionCodes.SystemException,
                             "System has some wrong operation. Please contact administrator");

                    case MembershipExceptionCodes.DefaultPublicPermissionMissing:
                        throw new ApplicationServiceException(e,
                            MembershipAppExceptionCodes.DefaultPublicPermissionMissing,
                            "System has some wrong operation. Please contact administrator");

                }
            }
            catch (Exception ex)
            {
                throw new ApplicationServiceException(
                    ex, MembershipAppExceptionCodes.SystemException,
                    "System has some wrong operation. Please contact administrator");
            }
        }

        private void HandleLogin(LoginCommand cmd)
        {
            try
            {
                signIn.Execute(cmd.Username, cmd.Password);
                var currentUser = this.accountRepository.GetAccountByUsername(cmd.Username);
                var profile = this.membershipProfileQuery.GetCurrentProfile(currentUser.Id);
                var profileId = Guid.Empty;
                if (profile != null) 
                {
                    profileId = profile.ProfileId;
                }

                var currentUserProfile = new SharedAccountProfile(
                    currentUser.Id,
                    currentUser.UserName.Value,
                    currentUser.Email.Value,
                    currentUser.EmailVerified,
                    currentUser.BirthDate.ToMMDDYYYYString(),
                    currentUser.FirstName,
                    currentUser.LastName,
                    currentUser.ZipCode.ToString(),
                    profileId
                    );

                this.userSession.IsLoggedIn = true;
                this.userSession.Username = currentUser.UserName.Value;
                this.userSession.CurrentUser = currentUserProfile;

                if (this.userSession != null && this.userSession.CurrentUser != null
                     && this.userSession.CurrentUser.ProfileId != null
                     && this.userSession.CurrentUser.ProfileId != Guid.Empty)
                {
                    this.redirector.GoToProfilesProfile();
                }
                else
                {
                    this.redirector.GoToProfilesManageProfile();
                }

            }
            catch(DomainException e)
            {
                switch(e.Code)
                {
                    case MembershipExceptionCodes.UsernameIsBlank:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.UsernameIsBlank, "Please fill your username");
                    case MembershipExceptionCodes.PasswordIsBlank:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.PasswordIsBlank, "Please fill your password");
                    case MembershipExceptionCodes.UserNotFound:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.UserNotFound, e.Message);
                    case MembershipExceptionCodes.PasswordNotMatch:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.PasswordNotMatch, e.Message);
                    case MembershipExceptionCodes.EmailNotVerified:
                        throw new ApplicationServiceException(
                            e, MembershipAppExceptionCodes.EmailNotVerified, e.Message);
                }
            }
            catch (System.Exception e)
            {
                throw new ApplicationServiceException(
                    e, MembershipAppExceptionCodes.SystemException,
                    "System has some wrong operation. Please contact administrator");
            }
           
        }
    }
}

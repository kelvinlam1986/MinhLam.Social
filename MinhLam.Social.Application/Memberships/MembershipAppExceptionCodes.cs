namespace MinhLam.Social.Application.Memberships
{
    public static class MembershipAppExceptionCodes
    {
        public const string SystemException = "system_exception";

        public const string UsernameIsBlank = "username_is_blank";
        public const string UsernameIsNotCorrectFormat = "username_is_not_correct_format";
        public const string PasswordIsBlank = "password_is_blank";
        public const string PaswordIsNotCorrectFormat = "password_is_not_correct_format";
        public const string UserNotFound = "user_not_found";
        public const string PasswordNotMatch = "passwor_not_match";
        public const string EmailNotVerified = "email_not_verified";
        public const string EmailIsBlank = "email_is_blank";
        public const string EmailIsNotCorrectFormat = "email_is_not_correct_format";
        public const string FirstNameIsBlank = "firstname_is_blank";
        public const string BirthDateIsNotCorrectFormat = "birthdate_is_not_correct_format";
        public const string ZipCodeUSInvalid = "zipcode_us_is_not_valid";
        public const string UserAlreadyExistWithUserName = "user_already_exist_with_username";
        public const string UserAlreadyExistWithEmail = "user_already_exist_with_email";
        public const string DefaultPublicPermissionMissing = "default_public_permission_missing";
        public const string OldPasswordNotMatchEnterPassword = "old_password_not_match_enter_password";
    }
}

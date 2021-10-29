namespace MinhLam.Social.Domain.Memberships
{
    public static class MembershipExceptionCodes
    {
        public const string UsernameIsBlank = "username_is_blank";
        public const string UserNameIsNotCorrectFormat = "username_is_not_correct_format";
        public const string PasswordIsBlank = "password_is_blank";
        public const string PasswordIsNotCorrectFormat = "password_is_not_correct_format";
        public const string UserNotFound = "user_not_found";
        public const string PasswordNotMatch = "passwor_not_match";
        public const string EmailNotVerified = "email_not_verified";
        public const string UserAlreadyExistWithUserName = "user_already_exist_with_username";
        public const string UserAlreadyExistWithEmail = "user_already_exist_with_email";
        public const string BirthDateIsNull = "birthdate_is_null";
        public const string ZipCodeIsNull = "zipcode_is_null";
        public const string TermNotFound = "term_not_found";
        public const string EmailIsNull = "email_is_null";
        public const string UsernameIsNull = "username_is_null";
        public const string PasswordIsNull = "password_is_null";
        public const string FirstNameIsBlank = "first_name_is_blank";
        public const string LastNameIsBlank = "last_name_is_blank";
        public const string DefaultPublicPermissionMissing = "default_public_permission_missing";
        public const string OldPasswordNotMatchEnterPassword = "old_password_not_match_enter_password";
    }
}

namespace MinhLam.Social.Domain.Profiles
{
    public class ProfileExceptionCodes
    {
        public const string UsernameIsBlank = "username_is_blank";
        public const string UserNameIsNotCorrectFormat = "username_is_not_correct_format";
        public const string UserNotFound = "user_not_found";
        public const string UserExperienceLevelNotFound = "user_experience_level_not_found";
        public const string TankYearOutOfRange = "tank_year_out_of_range";
        public const string YearOfFirstTankCanNotBeNull = "year_of_first_tank_can_not_be_null";
        public const string NumberOfTanksOwnCannotNegative = "number_of_tanks_owned_cannot_negative";
        public const string NumberOfFishOwnCannotNegative = "number_of_fish_owned_cannot_nagative";
        public const string ProfileAttributeTypeNotFound = "profile_attribute_type_not_found";
        public const string AttributeResponseMaxLength2000 = "attribute_response_max_length_2000";
        public const string ProfileNotFound = "profile_not_found";
        public const string PrivacyFlagTypeNotFound = "privacy_flag_type_not_found";
        public const string VisibilityNotFound = "visibility_not_found";
        public const string PrivacyFlagNotFound = "privacy_flag_not_found";
    }
}

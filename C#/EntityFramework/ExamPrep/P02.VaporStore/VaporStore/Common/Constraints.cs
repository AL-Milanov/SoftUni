namespace VaporStore.Common
{
    public class Constraints
    {
        //User constraints
        public const int USER_NAME_MIN_LENGTH = 3;
        public const int USER_NAME_MAX_LENGTH = 20;
        public const string USER_FULLNAME_REGEX = @"^[A-Z]{1}[a-z]+\s[A-Z]{1}[a-z]+$";

        //Card constraints 
        public const int CARD_NUMBER_LENGTH = 19;
        public const string CARD_NUMBER_REGEX = @"^\d{4}\s\d{4}\s\d{4}\s\d{4}$";
        public const int CARD_CVC_LENGTH = 3;
        public const string CARD_CVC_REGEX = @"^\d{3}$";

        //Purchase constraints
        public const int PURCHASE_PRODUCTKEY_LENGTH = 14;
        public const string PURCHASE_PRODUCTKEY_REGEX = @"^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$";

        //Game constraints
        public const string GAME_PRICE_MIN_VALUE = "0";
        public const string GAME_PRICE_MAX_VALUE = "79228162514264337593543950335";

    }
}

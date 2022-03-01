namespace FootballManager.Common
{
    public class Constraints
    {
        public const int ID_LENGTH = 36;

        //User
        public const int USER_USERNAME_MIN_LENGTH = 5;
        public const int USER_USERNAME_MAX_LENGTH = 20;

        public const int USER_EMAIL_MIN_LENGTH = 10;
        public const int USER_EMAIL_MAX_LENGTH = 60;

        public const int USER_PASSWORD_MIN_LENGTH = 5;
        public const int USER_PASSWORD_MAX_LENGTH = 20;

        //Player
        public const int PLAYER_FULLNAME_MIN_LENGTH = 5;
        public const int PLAYER_FULLNAME_MAX_LENGTH = 80;

        public const int PLAYER_POSITION_MIN_LENGTH = 5;
        public const int PLAYER_POSITION_MAX_LENGTH = 20;

        public const int PLAYER_DESCRIPTION_MAX_LENGTH = 200;

        public const byte PLAYER_ENDURANCE_MIN_VALUE = 0;
        public const byte PLAYER_ENDURANCE_MAX_VALUE = 10;

        public const byte PLAYER_SPEED_MIN_VALUE = 0;
        public const byte PLAYER_SPEED_MAX_VALUE = 10;
    }
}

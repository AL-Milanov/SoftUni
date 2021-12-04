namespace Theatre.Common
{
    public class Constraints
    {
        //Theatre
        public const int THEATRE_NAME_MIN_LENGTH = 4;

        public const int THEATRE_NAME_MAX_LENGTH = 30;

        public const int THEATRE_DIRECTOR_MIN_LENGTH = 4;

        public const int THEATRE_DIRECTOR_MAX_LENGTH = 30;

        public const int THEATRE_NUMBER_OF_HALLS_MIN = 1;

        public const int THEATRE_NUMBER_OF_HALLS_MAX = 10;

        //Play

        public const int PLAY_TITLE_MIN_LENGTH =  4;

        public const int PLAY_TITLE_MAX_LENGTH =  50;

        public const float PLAY_RATING_MIN = 0.00F;

        public const float PLAY_RATING_MAX = 10.00F;

        public const int PLAY_DESCRIPTION_MAX_LENGTH = 700;

        public const int PLAY_SCREENWRITER_MIN_LENGTH = 4;

        public const int PLAY_SCREENWRITER_MAX_LENGTH = 30;

        //Cast

        public const int CAST_FULLNAME_MIN_LENGTH = 4;

        public const int CAST_FULLNAME_MAX_LENGTH = 30;

        public const string CAST_PHONE_REGEX = @"^\+44\-\d{2}\-\d{3}-\d{4}$";

        //Tickets

        public const double TICKETS_PRICE_MIN = 1.00;

        public const double TICKETS_PRICE_MAX = 100.00;

        public const sbyte TICKETS_ROW_NUMBER_MIN = 1;

        public const sbyte TICKETS_ROW_NUMBER_MAX = 10;
    }
}

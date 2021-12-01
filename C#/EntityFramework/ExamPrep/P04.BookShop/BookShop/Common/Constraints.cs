namespace BookShop.Common
{
    public class Constraints
    {
        //Author
        public const int AUTHOR_FIRSTNAME_MIN_LENGTH = 3; 

        public const int AUTHOR_FIRSTNAME_MAX_LENGTH = 30;

        public const int AUTHOR_LASTNAME_MIN_LENGTH = 3;

        public const int AUTHOR_LASTNAME_MAX_LENGTH = 30;

        public const int AUTHOR_PHONE_MAX_LENGTH = 12;

        public const string AUTHOR_PHONE_REGEX = @"^\d{3}-\d{3}-\d{4}$";

        //Book
        public const int BOOK_NAME_MIN_LENGTH = 3;

        public const int BOOK_NAME_MAX_LENGTH = 30;

        public const int BOOK_GENRE_ENUM_MIN = 1;

        public const int BOOK_GENRE_ENUM_MAX = 3;

        public const double BOOK_PRICE_MIN_VALUE = 0.01;

        public const double BOOK_PRICE_MAX_VALUE = (double)decimal.MaxValue;

        public const int BOOK_PAGE_MIN_VALUE = 50;

        public const int BOOK_PAGE_MAX_VALUE = 5000;
    }
}

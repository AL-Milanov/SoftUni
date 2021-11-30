namespace SoftJail.Common
{
    public class Constraints
    {
        //Prisoner

        public const int PRISONER_NAME_MIN_LENGTH = 3;

        public const int PRISONER_NAME_MAX_LENGTH = 20;

        public const int PRISONER_AGE_MIN_VALUE = 18;

        public const int PRISONER_AGE_MAX_VALUE = 65;

        public const string PRISONER_NICKNAME_REGEX = @"^The\s[A-Z][a-z]+$";

        public const double PRISONER_BAIL_MIN_VALUE = 0.0; 

        public const double PRISONER_BAIL_MAX_VALUE = (double)decimal.MaxValue;

        //Officer

        public const int OFFICER_NAME_MIN_LENGTH = 3;

        public const int OFFICER_NAME_MAX_LENGTH = 30;

        public const double OFFICER_SALARY_MIN_VALUE = 0.0;

        public const double OFFICER_SALARY_MAX_VALUE = (double)decimal.MaxValue;

        //Department

        public const int DEPARTMENT_NAME_MIN_LENGTH = 3;

        public const int DEPARTMENT_NAME_MAX_LENGTH = 25;

        //Cell

        public const int CELL_NUMBER_MIN_VALUE = 1;

        public const int CELL_NUMBER_MAX_VALUE = 1000;

        //Mail

        public const string MAIL_ADDRESS_REGEX = @"^[A-Za-z0-9\s]+str\.$";

    }
}

using System;

namespace FootballTeamGenerator
{
    class NameValidator
    {
        public void ValidName(string value)
        {
            if (value == string.Empty)
            {
                throw new ArgumentException("A name should not be empty.");
            }
        }
    }
}

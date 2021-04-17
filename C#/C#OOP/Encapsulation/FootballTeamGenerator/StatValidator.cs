using System;

namespace FootballTeamGenerator
{
    class StatValidator
    {
        private const int MinStatValue = 0;
        private const int MaxStatValue = 100;

        public void ValidStat(string statName, int statValue)
        {
            if (statValue < MinStatValue || statValue > MaxStatValue)
            {
                throw new ArgumentException($"{statName} should be between {MinStatValue} and {MaxStatValue}.");
            }
        }
    }
}

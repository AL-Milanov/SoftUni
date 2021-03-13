using System;

namespace FootballTeamGenerator
{
    public class Player
    {
        private StatValidator statValidator = new StatValidator();
        private NameValidator nameValidator = new NameValidator();
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name 
        {
            get => name;
            private set
            {
                nameValidator.ValidName(value);
                name = value;
            }
        }

        public int Stats => (int)GetAverage();


        private int Endurance 
        {
            get => endurance;
            set
            {
                statValidator.ValidStat("Endurance", value);
                endurance = value;
            }
        }

        private int Sprint 
        {
            get => sprint;
            set
            {
                statValidator.ValidStat("Sprint", value);
                sprint = value;
            }
        }

        private int Dribble
        {
            get => dribble;
            set
            {
                statValidator.ValidStat("Dribble", value);
                dribble = value;
            }
        }

        private int Passing
        {
            get => passing;
            set
            {
                statValidator.ValidStat("Passing", value);
                passing = value;
            }
        }


        private int Shooting
        {
            get => shooting;
            set
            {
                statValidator.ValidStat("Shooting", value);
                shooting = value;
            }
        }


        private double GetAverage()
        {
            return Math.Round((Endurance + Sprint + Dribble + Passing + Shooting) / 5.0);
        }

    }
}

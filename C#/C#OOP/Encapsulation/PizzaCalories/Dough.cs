using System;

namespace PizzaCalories
{
    public class Dough
    {
        private const int MinValue = 1;
        private const int MaxValue = 200;

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }


        public string FlourType 
        { 
            get => this.flourType;
            private set 
            {
                string valueToLower = value.ToLower();
                if (valueToLower != "white" && valueToLower != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique 
        {
            get => this.bakingTechnique;
            private set
            {
                string valueToLower = value.ToLower();
                if (valueToLower != "crispy" && valueToLower != "chewy" && valueToLower != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            } 
        }

        public int Weight 
        { 
            get => this.weight;
            private set
            {
                if (value < MinValue || value > MaxValue)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinValue}..{MaxValue}].");
                }

                this.weight = value;
            } 
        }

        public double GetDoughCalories()
        {
            double flourTypeModifier = GetFlourTupeModifier(this.FlourType.ToLower());
            double bakingTechniqueModifier = GetBakingTechniqueModifier(this.BakingTechnique.ToLower());
            return (2 * this.Weight) * flourTypeModifier * bakingTechniqueModifier;
        }

        private double GetBakingTechniqueModifier(string bakingTechnique)
        {
            if (bakingTechnique == "crispy")
            {
                return 0.9;
            }

            if (bakingTechnique == "chewy")
            {
                return 1.1;
            }
            return 1;
        }

        private double GetFlourTupeModifier(string flourType)
        {
            if (flourType == "white")
            {
                return 1.5;
            }
            return 1;
        }
    }
}
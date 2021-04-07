using HAD.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace HAD.Entities.Items
{
    public class RecipeItem : IRecipe
    {
        private IList<string> requiredItems;

        public RecipeItem(string name,
            long strengthBonus,
            long agilityBonus,
            long intelligenceBonus,
            long hitPointsBonus,
            long damageBonus,
            IList<string> requiredItems)
        {
            this.requiredItems = requiredItems;
            this.Name = name;
            this.StrengthBonus = strengthBonus;
            this.AgilityBonus = agilityBonus;
            this.IntelligenceBonus = intelligenceBonus;
            this.HitPointsBonus = hitPointsBonus;
            this.DamageBonus = damageBonus;
        }

        public IReadOnlyList<string> RequiredItems => this.requiredItems.ToList();

        public string Name { get; private set; }

        public long StrengthBonus { get; private set; }

        public long AgilityBonus { get; private set; }

        public long IntelligenceBonus { get; private set; }

        public long HitPointsBonus { get; private set; }

        public long DamageBonus { get; private set; }
    }
}

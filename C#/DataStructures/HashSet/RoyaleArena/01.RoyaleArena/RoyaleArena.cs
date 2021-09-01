namespace _01.RoyaleArena
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class RoyaleArena : IArena
    {
        private HashSet<BattleCard> cards;

        public RoyaleArena()
        {
            cards = new HashSet<BattleCard>();
        }

        public int Count => cards.Count;


        public void Add(BattleCard card)
        {
            cards.Add(card);
        }

        public bool Contains(BattleCard card)
        { 
            return cards.Contains(card);
        }


        public void ChangeCardType(int id, CardType type)
        {
            var card = GetBattleCard(id);

            card.Type = type;
        }

        public BattleCard GetById(int id)
        {
            return GetBattleCard(id);
        }

        public void RemoveById(int id)
        {
            var card = GetBattleCard(id);

            cards.Remove(card);
        }

        public IEnumerable<BattleCard> GetByCardType(CardType type)
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return cards.OrderByDescending(c => c.Damage).ThenBy(c => c.Id);
        }

        public IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
        {
            var neededCards = cards.Where(c => c.Type == type)
                .Where(c => c.Damage > lo && c.Damage < hi)
                .OrderByDescending(c => c.Damage)
                .ThenBy(c => c.Id);

            if (neededCards.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return neededCards;
        }

        public IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
        {
            var neededCards = cards.Where(c => c.Type == type)
                  .Where(c => c.Damage <= damage)
                  .OrderByDescending(c => c.Damage)
                  .ThenBy(c => c.Id);

            if (neededCards.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return neededCards;
        }

        public IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name)
        { 
            var neededCards = cards.Where(c => c.Name == name)
                  .OrderByDescending(c => c.Swag)
                  .ThenBy(c => c.Id);

            if (neededCards.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return neededCards;
        }

        public IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi)
        {
            var neededCards = cards.Where(c => c.Swag >= lo && c.Swag < hi)
                  .OrderByDescending(c => c.Swag)
                  .ThenBy(c => c.Id);

            if (neededCards.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return neededCards;
        }

        public IEnumerable<BattleCard> FindFirstLeastSwag(int n)
        {
            if (n > Count)
            {
                throw new InvalidOperationException();
            }

            var neededCards = cards.OrderBy(c => c.Swag).ThenBy(c => c.Id).Take(n);

            return neededCards;
        }

        public IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi)
        {
            List<BattleCard> neededCards = new List<BattleCard>();

            foreach (var card in cards)
            {
                if (card.Swag >= lo && card.Swag <= hi)
                {
                    neededCards.Add(card);
                }
            }

            return neededCards.OrderBy(c => c.Swag);
        }


        public IEnumerator<BattleCard> GetEnumerator()
        {
            foreach (var card in cards)
            {
                yield return card;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private BattleCard GetBattleCard(int id)
        {
            var card = cards.FirstOrDefault(c => c.Id == id);

            if (card == null)
            {
                throw new InvalidOperationException();
            }

            return card;
        }
    }
}
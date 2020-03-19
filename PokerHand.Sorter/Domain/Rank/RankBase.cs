using PokerHand.Sorter.Model;
using System.Collections.Generic;
using System.Linq;

namespace PokerHand.Sorter.Domain.Rank
{
    public interface IRank
    {
        int GetRankValue(IEnumerable<PlayerCard> cards);
    }
    abstract class RankBase : IRank
    {
        protected int FLUSH => 5000000; // + valueHighCard()

        protected int STRAIGHT => 4000000; // + ValueHighCard()

        protected bool IsValid(IEnumerable<PlayerCard> cards)
        {
            return cards?.Count() == 5;
        }
        protected bool IsFlush(IEnumerable<PlayerCard> cards)
        {
            if (cards.GroupBy(h => h.Suit).Count() == 1) //check if all cards have same suit
            {
                return true;  // all cards have same suit found !
            }
            return false;
        }
        protected bool IsStraight(IEnumerable<PlayerCard> cards)
        {
            var orderedCards = cards.OrderBy(c => c.Value);

            var straightStart = (int)orderedCards.First().Value;

            for (var i = 1; i < orderedCards.Count(); i++)
            {
                if ((int)orderedCards.ElementAt(i).Value != straightStart + i)
                {
                    return false;// Straight failed...
                }
            }
            return true;  // Straight found !
        }
        protected int ValueHighCard(IEnumerable<PlayerCard> cards)
        {
            int val;

            var ordered = cards.OrderBy(c => c.Value);

            val = (int) ordered.ElementAt(0).Value + 
                14 * (int) ordered.ElementAt(1).Value + 
                14 * 14 * (int)ordered.ElementAt(2).Value + 
                14 * 14 * 14 *(int)ordered.ElementAt(3).Value + 
                14 * 14 * 14 * 14 * (int) ordered.ElementAt(4).Value;

            return val;
        }

        public abstract int GetRankValue(IEnumerable<PlayerCard> cards);
    }
}

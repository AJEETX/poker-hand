using PokerHand.Sorter.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHand.Sorter.Domain.Rank
{
    public interface IPair : IRank { }
    class Pair: RankBase, IPair
    {
        readonly IHighCard _highCard;
        protected int ONE_PAIR => 1000000;  // + high*14^2 + high2*14^1 + low
        public Pair(IHighCard highCard)
        {
            _highCard= highCard;
        }
        public override int GetRankValue(IEnumerable<PlayerCard> cards)
        {
            if (!IsValid(cards)) return -1;// always validate input at the entrance of a public method

            try
            {
                //logic to calculate the rank value
                if (cards.GroupBy(h => h.Value).Where(g => g.Count() == 2).Count() == 1) //get only single pair
                {
                    return ValueOnePair(cards);
                }
            }
            catch (Exception)
            {
                // shout out // throw;
            }
            return +_highCard.GetRankValue(cards);  //go to the next rank

        }
        int ValueOnePair(IEnumerable<PlayerCard> cards)
        {
            int val = 0;

            var ordered = cards.OrderBy(c => c.Value);

            if (ordered.ElementAt(0).Value== ordered.ElementAt(1).Value)
                val = 14 * 14 * 14 *(int) ordered.ElementAt(0).Value +(int) ordered.ElementAt(2).Value + 14 * (int) ordered.ElementAt(3).Value + 14 * 14 * (int) ordered.ElementAt(4).Value;
            else if (ordered.ElementAt(1).Value == ordered.ElementAt(2).Value)
                val = 14 * 14 * 14 * (int)ordered.ElementAt(1).Value + (int) ordered.ElementAt(0).Value + 14 * (int)ordered.ElementAt(3).Value + 14 * 14 * (int)ordered.ElementAt(4).Value;
            else if (ordered.ElementAt(2).Value == ordered.ElementAt(3).Value)
                val = 14 * 14 * 14 * (int) ordered.ElementAt(2).Value + (int) ordered.ElementAt(0).Value + 14 * (int)ordered.ElementAt(1).Value + 14 * 14 * (int)ordered.ElementAt(4).Value;
            else
                val = 14 * 14 * 14 * (int) ordered.ElementAt(3).Value + (int)ordered.ElementAt(0).Value + 14 * (int)ordered.ElementAt(1).Value + 14 * 14 * (int)ordered.ElementAt(2).Value;

            return ONE_PAIR + val;
        }
    }
}

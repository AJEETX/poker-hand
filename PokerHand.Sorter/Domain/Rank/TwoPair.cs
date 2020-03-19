using PokerHand.Sorter.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHand.Sorter.Domain.Rank
{
    public interface ITwoPair : IRank { }
    class TwoPair:RankBase,ITwoPair
    {
        readonly IPair _pair;
        readonly int same2TypeCount = 2;
        protected int TWO_PAIRS => 2000000;  // + High2*14^4+ Low2*14^2 + card
        public TwoPair(IPair pair)
        {
            _pair = pair;
        }
        public override int GetRankValue(IEnumerable<PlayerCard> cards)
        {
            if (!IsValid(cards)) return -1;// always validate input at the entrance of a public method

            try
            {
                if (cards.GroupBy(h => h.Value).Where(g => g.Count() == same2TypeCount).Count() == 2)
                {
                    return ValueTwoPairs(cards);
                }
            }
            catch (Exception)
            {
                //SHOUT OUT // LOG // throw;
            }

            return _pair.GetRankValue(cards);    //go to the next rank
        }
        int ValueTwoPairs(IEnumerable<PlayerCard> cards)
        {
            int val = 0;

            var ordered = cards.OrderBy(c => c.Value);

            if (ordered.ElementAt(0).Value == ordered.ElementAt(1).Value && ordered.ElementAt(2).Value == ordered.ElementAt(3).Value)
                val = 14 * 14 * (int) ordered.ElementAt(2).Value + 14 *(int) ordered.ElementAt(0).Value + (int) ordered.ElementAt(4).Value;
            else if (ordered.ElementAt(0).Value == ordered.ElementAt(1).Value && ordered.ElementAt(3).Value == ordered.ElementAt(4).Value)
                val = 14 * 14 * (int)ordered.ElementAt(3).Value + 14 * (int)ordered.ElementAt(0).Value  + (int)ordered.ElementAt(2).Value;
            else
                val = 14 * 14 * (int)ordered.ElementAt(3).Value + 14 *(int) ordered.ElementAt(1).Value + (int)ordered.ElementAt(0).Value;

            return TWO_PAIRS + val;
        }
    }
}

using PokerHand.Sorter.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHand.Sorter.Domain.Rank
{
    public interface IThreeOfAKind : IRank { }
    class ThreeOfAKind: RankBase, IThreeOfAKind
    {
        readonly  ITwoPair _twoPair;
        readonly int same3TypeCount = 3;
        protected int SET  => 3000000; // + Set card value
        public ThreeOfAKind(ITwoPair twoPair)
        {
            _twoPair = twoPair;
        }
        public override int GetRankValue(IEnumerable<PlayerCard> cards)
        {
            if (!IsValid(cards)) return -1;// always validate input at the entrance of a public method

            try
            {
                //logic to calculate the value
                if (cards.GroupBy(h => h.Value).Where(g => g.Count() == same3TypeCount).Any())
                {
                    return ValueSet(cards);
                }
            }
            catch (Exception)
            {
                //shout out // log //throw;
            }

            return _twoPair.GetRankValue(cards);    //go to the next rank
        }

        int ValueSet(IEnumerable<PlayerCard> cards)
        {
            var ordered = cards.OrderBy(c => c.Value);

            return SET + (int)ordered.ElementAt(2).Value;
        }
    }
}

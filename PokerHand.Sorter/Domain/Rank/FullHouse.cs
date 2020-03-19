using PokerHand.Sorter.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHand.Sorter.Domain.Rank
{
    public interface IFullHouse : IRank { }
    class FullHouse: RankBase, IFullHouse
    {
        readonly IFlush _flush;
        readonly int threeSameTypeCount = 3,twoSameTypeCount=2;
        protected int FULL_HOUSE => 6000000; 

        public FullHouse(IFlush flush)
        {
            _flush = flush;
        }
        public override int GetRankValue(IEnumerable<PlayerCard> cards)
        {
            if (!IsValid(cards)) return -1;// always validate input at the entrance of a public method

            try
            {
                //logic to calculate the rank value
                if (cards.GroupBy(c => c.Value).Where(g => g.Count() == threeSameTypeCount).Any() && //get three of same rank value
                    cards.GroupBy(c => c.Value).Where(g => g.Count() == twoSameTypeCount).Count() == 1) // get 2 of the same rank value
                {
                    return ValueFullHouse(cards);
                }
            }
            catch (Exception)
            {
                //shout out // log // throw;
            }

            return _flush.GetRankValue(cards);  //go to the next rank
        }
        public int ValueFullHouse(IEnumerable<PlayerCard> cards)
        {
            var ordered = cards.OrderBy(c => c.Value);

            return FULL_HOUSE + (int)ordered.ElementAt(2).Value;
        }
    }
}

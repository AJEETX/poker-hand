using PokerHand.Sorter.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHand.Sorter.Domain.Rank
{
    public interface IFlush : IRank { }
    class Flush:RankBase,IFlush
    {
        readonly IStraight _straight;
        public Flush(IStraight straight)
        {
            _straight = straight;
        }
        public override int GetRankValue(IEnumerable<PlayerCard> cards)
        {
            if (!IsValid(cards)) return -1;// always validate input at the entrance of a public method
            try
            {
                //logic to calculate the rank value
                if (cards.GroupBy(h => h.Suit).Count() == 1) //check if all cards have same suit
                {
                    return FLUSH + ValueHighCard(cards);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return _straight.GetRankValue(cards);   //go to the next rank
        }
    }
}

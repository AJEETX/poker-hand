using PokerHand.Sorter.Model;
using System;
using System.Collections.Generic;

namespace PokerHand.Sorter.Domain.Rank
{
    public interface IHighCard : IRank { }
    class HighCard: RankBase, IHighCard
    {
        public override int GetRankValue(IEnumerable<PlayerCard> cards)
        {
            if (!IsValid(cards)) return -1;// always validate input at the entrance of a public method

            try
            {
                //just calculate the rank value of the cards
                return ValueHighCard(cards); 
            }
            catch (Exception)
            {
                //shout out // log // throw;
            }
            return 0;
        }
    }
}

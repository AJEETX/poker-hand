using PokerHand.Sorter.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHand.Sorter.Domain.Rank
{
    public interface IRoyalStraightFlush : IRank { }
    class RoyalFlush: RankBase,IRoyalStraightFlush
    {
        readonly IStraightFlush _straightFlush;
        protected int ROYAL_FLUSH => STRAIGHT + FLUSH + 14;
        public RoyalFlush(IStraightFlush straightFlush)
        {
            _straightFlush = straightFlush;
        }
        public override int GetRankValue(IEnumerable<PlayerCard> cards)
        {
            if (!IsValid(cards)) return -1;// always validate input at the entrance of a public method

            try
            {
                //logic to calculate the value
                var match = cards.Where(c => c.Value == Value.A && c.Value == Value.K && c.Value == Value.Q && c.Value == Value.J && c.Value == Value.T);

                if (match.Any())
                {
                    return ROYAL_FLUSH;
                }

            }
            catch (Exception)
            {
                //shout out //log // throw;
            }

            return _straightFlush.GetRankValue(cards); //go to the next rank
        }
    }
}

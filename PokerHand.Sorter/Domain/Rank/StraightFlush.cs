using PokerHand.Sorter.Model;
using System;
using System.Collections.Generic;

namespace PokerHand.Sorter.Domain.Rank
{
    public interface IStraightFlush : IRank { }

    class StraightFlush:RankBase, IStraightFlush
    {
        readonly IFourOfAKind _fourOfAKind;

        protected int STRAIGHT_FLUSH => 8000000; // + ValueHighCard()
        public StraightFlush(IFourOfAKind fourOfAKind)
        {
            _fourOfAKind = fourOfAKind;
        }
        public override int GetRankValue(IEnumerable<PlayerCard> cards)
        {
            if (!IsValid(cards)) return -1;// always validate input at the entrance of a public method

            try
            {
                if (IsFlush(cards) && IsStraight(cards))
                {
                    return STRAIGHT_FLUSH + ValueHighCard(cards);
                }
            }
            catch (Exception)
            {
                //shout out // log // throw;
            }

            return _fourOfAKind.GetRankValue(cards); //go to the next rank
        }
    }
}

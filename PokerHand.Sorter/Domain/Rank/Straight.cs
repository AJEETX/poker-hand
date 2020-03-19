using PokerHand.Sorter.Model;
using System;
using System.Collections.Generic;

namespace PokerHand.Sorter.Domain.Rank
{
    public interface IStraight : IRank { }
    class Straight:RankBase,IStraight
    {
        readonly IThreeOfAKind _threeOfAKind;
        public Straight(IThreeOfAKind threeOfAKind)//:base(cards)
        {
            _threeOfAKind = threeOfAKind;
        }
        public override int GetRankValue(IEnumerable<PlayerCard> cards)
        {
            if (!IsValid(cards)) return -1;// always validate input at the entrance of a public method

            try
            {
                //logic to calculate the value
                if (IsStraight(cards))
                {
                    return STRAIGHT + ValueHighCard(cards);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return _threeOfAKind.GetRankValue(cards);   //go to the next rank
        }
    }
}

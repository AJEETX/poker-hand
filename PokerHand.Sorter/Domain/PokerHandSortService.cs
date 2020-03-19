using PokerHand.Sorter.Domain.Rank;
using PokerHand.Sorter.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHand.Sorter.Domain
{
    public interface IPokerHandSortService
    {
        int GetPokerHandsWinner(PokerHands strPokerHands);
    }
    class PokerHandSortService : IPokerHandSortService
    {
        readonly IRoyalStraightFlush _rank;
        readonly int cardPerhand = 5;
        public PokerHandSortService(IRoyalStraightFlush rank)
        {
            _rank = rank;
        }
        public int GetPokerHandsWinner(PokerHands pokerHands)
        {
            var result = -1;
            if (pokerHands == null || pokerHands?.Hands == null || pokerHands?.Hands.Length== 0 || pokerHands?.Hands.Length % cardPerhand !=0 ) // always validate input at the entrance of a public method
                return result;
            try
            {
                var player1HandValue = _rank.GetRankValue(GetHandCards(pokerHands.Hands.Take(cardPerhand)));

                var player2HandValue = _rank.GetRankValue(GetHandCards(pokerHands.Hands.Skip(5).Take(cardPerhand)));

                if (player1HandValue > player2HandValue)
                {
                    return 1;
                }
                return 0;
            }
            catch (Exception)
            {
                // shout out// throw;
            }

            return 0;
        }

        IEnumerable<PlayerCard> GetHandCards(IEnumerable<string> hands)
        {
            foreach (var item in hands)
            {
                yield return new PlayerCard
                {
                    Suit = (Suit)Enum.Parse(typeof(Suit), item.Substring(1)),
                    Value = (Value)Enum.Parse(typeof(Value), item.Substring(0, 1))
                };
            }
        }
    }
}

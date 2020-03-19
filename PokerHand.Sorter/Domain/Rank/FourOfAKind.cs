using PokerHand.Sorter.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHand.Sorter.Domain.Rank
{
    public interface IFourOfAKind : IRank { }
    class FourOfAKind:RankBase,IFourOfAKind
    {
        readonly IFullHouse _fullHouse;
        readonly int sameTypeCount=4;
        protected int FOUR_OF_A_KIND => 7000000; // + Quads Card Rank

        public FourOfAKind(IFullHouse fullHouse) 
        {
            _fullHouse = fullHouse;
        }
        public override int GetRankValue(IEnumerable<PlayerCard> cards)
        {
            if (!IsValid(cards)) return -1;// always validate input at the entrance of a public method

            try
            {
                //logic to calculate the rank value
                var fourOfSameKinds = cards.GroupBy(c => c.Value).Where(g => g.Count() == sameTypeCount);   // chek if the hand has same type of cards

                if (fourOfSameKinds.Any())
                {
                    return ValueFourOfAKind(cards);
                }
            }
            catch (Exception)
            {
                // shout out //log //throw;
            }

            return _fullHouse.GetRankValue(cards);  //go to the next rank
        }

        public int ValueFourOfAKind(IEnumerable<PlayerCard> cards)
        {
            var ordered=cards.OrderBy(c=>c.Value);

            return FOUR_OF_A_KIND + (int) ordered.ElementAt(2).Value;
        }
    }
}

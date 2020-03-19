using System.ComponentModel;

namespace PokerHand.Sorter.Model
{
    public enum Suit
    {
        [Description("Club")]
        C,
        [Description("Diamonds")]
        D,
        [Description("Hearts")]
        H,
        [Description("Spades")]
        S
    }

    public enum Value
    {
        Two=2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        [Description("Ten")]
        T,
        [Description("Jack")]
        J,
        [Description("Queen")]
        Q,
        [Description("King")]
        K,
        [Description("Ace")]
        A
    }

}

using Microsoft.Extensions.DependencyInjection;
using PokerHand.Sorter.Common;
using PokerHand.Sorter.Domain;
using System;

namespace PokerHand.Sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = Container.RegisterServices().GetService<IPokerHandManagerService>();

            var results=manager.GetPokerHandsWinner();

            Console.WriteLine("Player 1 : " + results.Player1);
            Console.WriteLine("Player 2 : " + results.Player2);

            Container.DisposeServices();
            Console.Read();
        }
    }
}

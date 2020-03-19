using Microsoft.Extensions.DependencyInjection;
using PokerHand.Sorter.Domain;
using PokerHand.Sorter.Domain.Rank;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHand.Sorter.Common
{
    class Container
    {
        static IServiceProvider _serviceProvider;
        public static IServiceProvider RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddSingleton<IConsole, ConsoleWrapper>()
                .AddSingleton<IPokerHandManagerService, PokerHandManagerService>()
                .AddSingleton<IPokerHandsProviderService, PokerHandsProviderService>()
                .AddSingleton<IPokerHandSortService, PokerHandSortService>()
                .AddSingleton<IHighCard, HighCard>()
                .AddSingleton<IPair, Pair>()
                .AddSingleton<ITwoPair, TwoPair>()
                .AddSingleton<IFlush, Flush>()
                .AddSingleton<IFourOfAKind, FourOfAKind>()
                .AddSingleton<IFullHouse, FullHouse>()
                .AddSingleton<IRoyalStraightFlush, RoyalFlush>()
                .AddSingleton<IStraight, Straight>()
                .AddSingleton<IStraightFlush, StraightFlush>()
                .AddSingleton<IThreeOfAKind,ThreeOfAKind>();

            _serviceProvider= collection.BuildServiceProvider();
            return _serviceProvider;
        }
        public static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}

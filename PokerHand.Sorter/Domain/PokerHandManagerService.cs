using System;
using Microsoft.Extensions.Configuration;
using PokerHand.Sorter.Model;

namespace PokerHand.Sorter.Domain
{
    public interface IPokerHandManagerService
    {
        PokerHandsResult GetPokerHandsWinner();
    }
    class PokerHandManagerService : IPokerHandManagerService
    {
        readonly IPokerHandSortService _pokerHandSortService;
        readonly IPokerHandsProviderService _pokerHandsProviderService;
        readonly IConsole _console;
        PokerHandsResult result = new PokerHandsResult();
        public PokerHandManagerService(IPokerHandSortService pokerHandSortService, IPokerHandsProviderService pokerHandsProviderService,IConsole console)
        {
            _pokerHandsProviderService = pokerHandsProviderService;
            _pokerHandSortService = pokerHandSortService;
            _console = console;
        }
        public PokerHandsResult GetPokerHandsWinner()
        {
            try
            {
                _console.WriteLine("Please enter input or press ENTER to fetch input from file");
                var input = _console.ReadLine();
                result = !string.IsNullOrWhiteSpace(input)? GetwinnerForInput(input): GetwinnerForFile();
            }
            catch (Exception)
            {
                //shout out //throw;
            }
            return result;
        }

        PokerHandsResult GetwinnerForFile()
        {
            _console.WriteLine("No input provided, getting input from file...");
            
            var strPokerHands = _pokerHandsProviderService.GetPokerHands(new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build()["path"]); //get poker hands from path

            if (strPokerHands?.Length == 0) return result;

            foreach (var strPokerHand in strPokerHands)
            {
                result = GetwinnerForInput(strPokerHand);
            }
            return result;
        }
        PokerHandsResult GetwinnerForInput(string strPokerHand)
        {
            var handResult = _pokerHandSortService.GetPokerHandsWinner(new PokerHands(strPokerHand.Split(' ')));

            if (handResult == 1) result.Player1++; //player 1 winner

            if (handResult == 0) result.Player2++; //player 2 winner

            return result;
        }
    }
}

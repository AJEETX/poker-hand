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
        readonly IConsoleService _consoleService;
        PokerHandsResult result = new PokerHandsResult();
        public PokerHandManagerService(IPokerHandSortService pokerHandSortService, IPokerHandsProviderService pokerHandsProviderService, IConsoleService consoleService)
        {
            _pokerHandsProviderService = pokerHandsProviderService;
            _pokerHandSortService = pokerHandSortService;
            _consoleService = consoleService;
        }
        public PokerHandsResult GetPokerHandsWinner()
        {
            try
            {
                _consoleService.WriteLine("Please enter input or press ENTER to fetch input from file");
                var input = _consoleService.ReadLine();
                result = input!=null && input.Length==10? GetwinnerForInput(input): GetwinnerForFile();
            }
            catch (Exception)
            {
                //shout out //throw;
            }
            return result;
        }

        PokerHandsResult GetwinnerForFile()
        {
            _consoleService.WriteLine("No input provided, getting input from file...");
            
            var strPokerHands = _pokerHandsProviderService.GetPokerHands(new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build()["path"]); //get poker hands from path

            if (strPokerHands?.Length == 0) return result;

            foreach (var strPokerHand in strPokerHands)
            {
                var pokerHand = _consoleService.ValidateInput(strPokerHand);
                result = GetwinnerForInput(pokerHand);
            }
            return result;
        }
        PokerHandsResult GetwinnerForInput(string[] pokerHand)
        {
            var handResult = _pokerHandSortService.GetPokerHandsWinner(new PokerHands(pokerHand));

            if (handResult == 1) result.Player1++; //player 1 winner

            if (handResult == 0) result.Player2++; //player 2 winner

            return result;
        }
    }
}

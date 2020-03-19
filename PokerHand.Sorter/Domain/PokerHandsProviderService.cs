using System;
using System.IO;

namespace PokerHand.Sorter.Domain
{
    public interface IPokerHandsProviderService
    {
        string[] GetPokerHands(string path);
    }
    class PokerHandsProviderService : IPokerHandsProviderService
    {
        public string[] GetPokerHands(string path)
        {
            string[] filedata = default(string[]);
            if (string.IsNullOrWhiteSpace(path))
                return filedata;
            try
            {
                filedata= File.ReadAllText(path).Split(new[] { "\n" }, StringSplitOptions.None);
            }
            catch (Exception)
            {
                // throw;
            }
            return filedata;
        }
    }
}

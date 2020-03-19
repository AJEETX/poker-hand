using System;

namespace PokerHand.Sorter.Domain
{
    public interface IConsoleService
    {
        void WriteLine(string message);
        string ReadLine();
    }
    class ConsoleService : IConsoleService
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}

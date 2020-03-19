using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHand.Sorter.Domain
{
    public interface IConsole
    {
        void WriteLine(string message);
        string ReadLine();
    }
    class ConsoleWrapper : IConsole
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

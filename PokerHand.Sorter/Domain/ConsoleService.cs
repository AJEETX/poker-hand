using System;
using System.Text.RegularExpressions;

namespace PokerHand.Sorter.Domain
{
    public interface IConsoleService
    {
        void WriteLine(string message);
        string[] ReadLine();
        string[] ValidateInput(string strInput);
    }
    class ConsoleService : IConsoleService
    {
        Regex regex = new Regex("[23456789TJQKA]{1}[SDCH]{1}");
        public void WriteLine(string message)
        {
            if (!string.IsNullOrWhiteSpace(message)) //always good to validate at the entrance
            {
                try
                {
                    Console.WriteLine(message);
                }
                catch (Exception)
                {
                    //shout out //throw;
                }
            }
        }

        public string[] ReadLine()
        {
            string[] result = null;
            try
            {
                var input= Console.ReadLine();
                result= ValidateInput(input);
            }
            catch (Exception)
            {
                //shout out //throw;
            }
            return result;
        }
        public string[] ValidateInput(string strInput)
        {
            string[] inputItems = null;
            if (string.IsNullOrWhiteSpace(strInput)) //always good to validate at the entrance
                return inputItems;
            try
            {
                inputItems = ValidateString(strInput);
            }
            catch (Exception)
            {
                //shout out //throw;
            }
            return inputItems;

        }
        string[] ValidateString(string strInput)
        {
            var inputItems = strInput.Split(' ');

            foreach (var inputItem in inputItems)
            {
                if (!regex.IsMatch(inputItem))
                {
                    return null;
                }
            }
            return inputItems;
        }
    }
}

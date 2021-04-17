using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallOtherPhones, ISearchInTheWWW
    {
        public void Calling(int number)
        {
            Console.WriteLine($"Calling... {number:D10}");
        }

        public void SearchInTheWWW(string site)
        {
            Console.WriteLine($"Browsing: {site}!");
        }
    }
}

using System;

namespace Telephony
{
    public class StationaryPhone : ICallOtherPhones
    {
        public void Calling(int number)
        {
            Console.WriteLine($"Dialing... {number:D7}");
        }
    }
}

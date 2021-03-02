using System;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string sitePattern = @"\d+";
            Regex siteRegex = new Regex(sitePattern);

            string numberPattern = @"\d{7,10}";
            Regex numberRegex = new Regex(numberPattern);

            string[] phoneNumbersData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] sitesData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            StationaryPhone stationaryphone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();

            foreach (var phoneNumber in phoneNumbersData)
            {
                if (Regex.IsMatch(phoneNumber, numberPattern))
                {
                    if (phoneNumber.Length == 7)
                    {
                        stationaryphone.Calling(int.Parse(phoneNumber));
                    }
                    else
                    {
                        smartphone.Calling(int.Parse(phoneNumber));
                    }
                    continue;
                }

                Console.WriteLine("Invalid number!");
            }

            foreach (var site in sitesData)
            {
                if (Regex.IsMatch(site, sitePattern))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }

                Console.WriteLine($"Browsing: {site}!");
            }
        }
    }
}

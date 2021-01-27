using System;
using System.IO;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ZipArchive zipArchive = ZipFile.Open("zipFile.zip", ZipArchiveMode.Create))
            {
                ZipArchiveEntry zipArchiveEntry = zipArchive.CreateEntryFromFile("copyMe.png", "copyMeInArchive.png");

            }
            ZipFile.ExtractToDirectory("zipFile.zip", "../../../../");
        }
    }
}

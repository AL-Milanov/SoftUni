using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream picture = new FileStream("copyMe.png", FileMode.Open, FileAccess.Read))
            {
                using (FileStream newCopy = new FileStream("newCopy.png",
                FileMode.Create, FileAccess.Write))
                {
                    while (picture.Position != picture.Length)
                    {
                        byte[] buffer = new byte[4096];
                        int count = picture.Read(buffer, 0, buffer.Length);
                        newCopy.Write(buffer);
                    }

                }
            }
        }
    }
}

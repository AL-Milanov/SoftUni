using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StreamsFilesAndDirectories
{
    class Program
    {
        static void Main(string[] args)
        {

            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                int counter = 0;
                string line = reader.ReadLine();
                Stack<string> stack = new Stack<string>();
                
                while (line != null)
                {
                    if (counter % 2 == 0)
                    {
                        if (line.Contains('-') || line.Contains(',') ||
                             line.Contains(", ") || line.Contains('.') ||
                             line.Contains('!') || line.Contains('?'))
                        {
                            line = line.Replace('-', '@');
                            line = line.Replace(',', '@');
                            line = line.Replace('.', '@');
                            line = line.Replace('!', '@');
                            line = line.Replace('?', '@');
                        }
                        stack = new Stack<string>(line.Split());
                        Console.Write(string.Join(" ", stack));
                        Console.WriteLine();
                    }

                    line = reader.ReadLine();
                    counter++;

                }
            }
        }
    }
}

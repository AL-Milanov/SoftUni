using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Library
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> bookShelf = Console.ReadLine()
                                            .Split("&" , StringSplitOptions.RemoveEmptyEntries)
                                            .ToList();
            string command = Console.ReadLine();

            while (command != "Done")
            {
                string[] cmdArgs = command.Split(" | ");
                string action = cmdArgs[0];
                string book = cmdArgs[1];

                if (action == "Add Book")
                {
                    if (!bookShelf.Contains(book))
                    {
                        bookShelf.Insert(0, book);
                    }
                    
                }
                else if (action == "Take Book")
                {
                    if (bookShelf.Contains(book))
                    {
                        bookShelf.Remove(book);
                    }
                }
                else if (action == "Swap Books")
                {
                    string otherBook = cmdArgs[2];
                    if (bookShelf.Contains(book) && bookShelf.Contains(otherBook))
                    {
                        int firstIndex = bookShelf.IndexOf(book);
                        int secoundIndex = bookShelf.IndexOf(otherBook);
                        bookShelf.RemoveAt(firstIndex);
                        bookShelf.Insert(firstIndex, otherBook);
                        bookShelf.RemoveAt(secoundIndex);
                        bookShelf.Insert(secoundIndex, book);
                    }
                }
                else if (action == "Insert Book")
                {
                    bookShelf.Add(book);
                }
                else if (action == "Check Book")
                {
                    int index = int.Parse(book);
                    if (index >= 0 && index < bookShelf.Count)
                    {
                        Console.WriteLine(bookShelf[index]);
                    }
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", bookShelf));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(", ").ToArray();
            int n = int.Parse(Console.ReadLine());
            Article article = new Article(tokens[0], tokens[1], tokens[2]);

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                                          .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                                          .ToArray();
                string firstCmd = cmdArgs[0].ToLower();
                string secondCmd = cmdArgs[1];
                if (firstCmd == "edit")
                {
                    article.Edit(secondCmd);
                }
                else if (firstCmd == "changeauthor")
                {
                    article.ChangeAuthor(secondCmd);
                }
                else if (firstCmd == "rename")
                {
                    article.Rename(secondCmd);
                }

            }
            Console.WriteLine(article);
        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Edit(string content)
        {
            Content = content;
        }
        public void ChangeAuthor(string author)
        {
            Author = author;
        }
        public void Rename(string title)
        {
            Title = title;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}

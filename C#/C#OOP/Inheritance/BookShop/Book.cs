using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop
{
    public class Book
    {
        private string author;
        private string title;
        private decimal price;
        
        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public string Author 
        {
            get 
            {
                return this.author;
            }
            set
            {
                string[] authurName = value.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (authurName.Length == 2 && char.IsDigit(authurName[1][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
                this.author = value;
            } 
        }

        public string Title 
        { 
            get 
            { 
                return this.title; 
            } 
            set 
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                this.title = value;
            } 
        }

        public virtual decimal Price {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Type: {GetType().Name}");
            sb.AppendLine($"Title: {Title}");
            sb.AppendLine($"Author: {Author}");
            sb.AppendLine($"Price: {Price:f2}");

            return sb.ToString().TrimEnd();
        }
    }
}

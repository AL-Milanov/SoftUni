using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            bool isMirrored = false;
            
            foreach (var item in input)
            {
                
                if (item == '(' || item == '{' || item == '[')
                {
                    stack.Push(item);
                }
                else if (item == ')' || item == '}' || item == ']')
                {
                    if (stack.Any() == false)
                    {
                        isMirrored = false;
                        break;
                    }
                    char currChar = stack.Peek();
                    if (currChar == '(' && item == ')')
                    {
                        isMirrored = true;
                        stack.Pop();
                    }
                    else if(currChar == '{' && item == '}')
                    {
                        isMirrored = true;
                        stack.Pop();
                    }
                    else if (currChar == '[' && item == ']')
                    {
                        isMirrored = true;
                        stack.Pop();
                    }
                    else
                    {
                        isMirrored = false;
                        break;
                    }
                }
            }
            if (isMirrored)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}

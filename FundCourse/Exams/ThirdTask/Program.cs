using System;
using System.Linq;

namespace Third
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] priceRaitings = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int entryPoint = int.Parse(Console.ReadLine());
            string valuable = Console.ReadLine();
            string raiting = Console.ReadLine();

            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < entryPoint; i++)
            {
                if (raiting == "positive")
                {
                    if (priceRaitings[i] > 0)
                    {
                        if (valuable == "cheap")
                        {
                            if (priceRaitings[i] < priceRaitings[entryPoint])
                            {
                                leftSum += priceRaitings[i];
                            }

                        }
                        else if (valuable == "expensive")
                        {
                            if (priceRaitings[i] >= priceRaitings[entryPoint])
                            {
                                leftSum += priceRaitings[i];
                            }
                        }
                    }

                }
                else if (raiting == "negative")
                {
                    if (priceRaitings[i] < 0)
                    {
                        if (valuable == "cheap")
                        {
                            if (priceRaitings[i] < priceRaitings[entryPoint])
                            {
                                leftSum += priceRaitings[i];
                            }

                        }
                        else if (valuable == "expensive")
                        {
                            if (priceRaitings[i] >= priceRaitings[entryPoint])
                            {
                                leftSum += priceRaitings[i];
                            }
                        }
                    }
                }
                else if (raiting == "all")
                {
                    if (valuable == "cheap")
                    {
                        if (priceRaitings[i] < priceRaitings[entryPoint])
                        {
                            leftSum += priceRaitings[i];
                        }

                    }
                    else if (valuable == "expensive")
                    {
                        if (priceRaitings[i] >= priceRaitings[entryPoint])
                        {
                            leftSum += priceRaitings[i];
                        }
                    }
                }
            }
            for (int i = priceRaitings.Length - 1; i >= entryPoint ; i--)
            {
                if (raiting == "positive")
                {
                    if (priceRaitings[i] > 0)
                    {
                        if (valuable == "cheap")
                        {
                            if (priceRaitings[i] < priceRaitings[entryPoint])
                            {
                                rightSum += priceRaitings[i];
                            }

                        }
                        else if (valuable == "expensive")
                        {
                            if (priceRaitings[i] >= priceRaitings[entryPoint])
                            {
                                rightSum += priceRaitings[i];
                            }
                        }
                    }

                }
                else if (raiting == "negative")
                {
                    if (priceRaitings[i] < 0)
                    {
                        if (valuable == "cheap")
                        {
                            if (priceRaitings[i] < priceRaitings[entryPoint])
                            {
                                rightSum += priceRaitings[i];
                            }

                        }
                        else if (valuable == "expensive")
                        {
                            if (priceRaitings[i] >= priceRaitings[entryPoint])
                            {
                                rightSum += priceRaitings[i];
                            }
                        }
                    }
                }
                else if (raiting == "all")
                {
                    if (valuable == "cheap")
                    {
                        if (priceRaitings[i] < priceRaitings[entryPoint])
                        {
                            rightSum += priceRaitings[i];
                        }

                    }
                    else if (valuable == "expensive")
                    {
                        if (priceRaitings[i] >= priceRaitings[entryPoint])
                        {
                            rightSum += priceRaitings[i];
                        }
                    }
                }
            }
            if (rightSum > leftSum)
            {
                Console.WriteLine($"Right - {rightSum}");
            }
            else if (leftSum > rightSum)
            {
                Console.WriteLine($"Left - {leftSum}");
            }
            else if (leftSum == rightSum)
            {
                Console.WriteLine($"Left - {leftSum}");
            }
        }
    }
}

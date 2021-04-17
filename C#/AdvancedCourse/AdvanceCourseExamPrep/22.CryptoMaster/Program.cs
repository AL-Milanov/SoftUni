using System;
using System.Linq;

class Program
{
    
    static void Main()
    {
        var nums = Console.ReadLine()
            .Split(new[] { ", " },
                StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        int seqLength = nums.Count;
        int maxLength = 0;

        for (int step = 1; step < seqLength; step++)
        {
            for (int stNode = 0; stNode < seqLength; stNode++)
            {
                var localMax = 1;

                var currentElementIndex = stNode;
                var nextElementIndex = (currentElementIndex + step) % seqLength;

                while (nums[nextElementIndex] > nums[currentElementIndex])
                {
                    localMax++;

                    currentElementIndex = nextElementIndex;
                    nextElementIndex = (currentElementIndex + step) % seqLength;
                }

                if (maxLength < localMax)
                {
                    maxLength = localMax;
                }
            }
        }

        Console.WriteLine(maxLength);
    }
}
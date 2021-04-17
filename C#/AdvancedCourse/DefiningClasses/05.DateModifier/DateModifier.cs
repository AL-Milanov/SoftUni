using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public int Calculation(string firstDate, string secondDate)
        {
            int[] firstDateSplited = firstDate.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] secondDateSplited = secondDate.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse).ToArray();

            int earlierYear = EarlierYear(firstDateSplited, secondDateSplited);
            int otherYear = OtherYear(firstDateSplited, secondDateSplited);

            int earlierMonth = firstDateSplited[1];
            int otherMonth = secondDateSplited[1];

            int firstYearDay = firstDateSplited[2];
            int secondYearDay = secondDateSplited[2];

            if (earlierYear == secondDateSplited[0])
            {
                if (earlierMonth > otherMonth)
                {
                    earlierMonth = secondDateSplited[1];
                    otherMonth = firstDateSplited[1];
                    firstYearDay = secondDateSplited[2];
                    secondYearDay = firstDateSplited[2];

                }
            }

            int sum = DateTime.DaysInMonth(earlierYear, earlierMonth) - firstYearDay;
            int firstCylce = earlierMonth + 1;

            if (firstCylce == 13)
            {
                firstCylce = 1;
            }

            bool isLastMonth = false;
            int lastMonthCycle = 12;

            while (earlierYear <= otherYear)
            {
                if (earlierYear == otherYear)
                {
                    lastMonthCycle = otherMonth;
                    isLastMonth = true;
                }

                for (int i = firstCylce; i <= lastMonthCycle; i++)
                {
                    if (isLastMonth && i == lastMonthCycle)
                    {
                        sum += secondYearDay;
                    }
                    else
                    {
                        sum += DateTime.DaysInMonth(earlierYear, i);
                    }
                }
                earlierYear++;
                firstCylce = 1;

            }

            return sum;

        }

        private int OtherYear(int[] firstDateSplited, int[] secondDateSplited)
        {
            int firstYear = firstDateSplited[0];
            int secondYear = secondDateSplited[0];
            if (firstYear >= secondYear)
            {
                return firstYear;
            }
            else
            {
                return secondYear;
            }
        }

        private int EarlierYear(int[] firstDateSplited, int[] secondDateSplited)
        {
            int firstYear = firstDateSplited[0];
            int secondYear = secondDateSplited[0];
            if (firstYear >= secondYear)
            {
                return secondYear;
            }
            else
            {
                return firstYear;
            }
        }
    }
}

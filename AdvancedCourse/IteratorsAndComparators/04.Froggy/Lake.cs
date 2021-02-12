using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Froggy
{
    class Lake : IEnumerable<int>
    {
        private List<int> stones;

        public Lake(int[] stones)
        {
            this.stones = stones.ToList();
        }


        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Count; i += 2)
            {
                yield return stones[i];
            }

            int index = stones.Count - 1;
            index = index % 2 == 0 ?
                 stones.Count - 2 : index;

            for (int i = index; i >= 0; i -= 2)
            {
                yield return stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

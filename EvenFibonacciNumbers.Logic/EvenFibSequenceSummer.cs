using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenFibonacciNumbers.Logic
{
    public class EvenFibSequenceSummer
    {
        public List<int> GetFibonacciSequence(int ceiling)
        {            
            int seed = 1;
            List<int> sequence = new List<int>{ seed };
            int current = seed + seed;
            int currentIndex = 1;
            
            while (current < ceiling)
            {
                sequence.Add(current);
                current = sequence[currentIndex - 1] + sequence[currentIndex];

                currentIndex++;
            }

            return sequence;
        }
        
        //pre-optimization
        //public int GetEvenFibSequenceSum(int ceiling)
        //{
        //    int seed = 1;
        //    List<int> sequence = new List<int> { seed };
        //    int current = seed + seed;
        //    int currentIndex = 1;
        //    int sum = 0;

        //    while (current < ceiling)
        //    {
        //        sequence.Add(current);
        //        if (current % 2 == 0)
        //        {
        //            sum += current;
        //        }

        //        current = sequence[currentIndex - 1] + sequence[currentIndex];                

        //        currentIndex++;
        //    }

        //    return sum;
        //}

        //post-optimization because we don't really need to store
        // the full sequence in memory
        //could also be refactored to a recursive pattern
        public int GetEvenFibSequenceSum(int ceiling)
        {
            int sum = 0;
            int previousValue = 1;
            int currentValue = 2;

            while (currentValue < ceiling)
            {
                if (currentValue % 2 == 0)
                {
                    sum += currentValue;
                }
                
                int tempCurrentValue = currentValue;
                currentValue = previousValue + currentValue;
                previousValue = tempCurrentValue;
            }

            return sum;
        }
    }
}

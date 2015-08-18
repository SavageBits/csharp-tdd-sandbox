using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplesOf3And5.Logic
{
    public class MultipleSummer
    {
        //original
        //public int SumMultiples(int ceiling)
        //{
        //    //int sum = 0;

        //    List<int> multiples = new List<int>();

        //    while (ceiling-- > 0)
        //    {
        //        if (ceiling % 3 == 0 || ceiling % 5 == 0)
        //        {
        //            multiples.Add(ceiling);
        //        }
        //    }

        //    return multiples.Sum();
        //}




        ////recursive with List
        //List<int> multiples = new List<int>();
        
        //public int SumMultiples(int ceiling)
        //{
        //    if (ceiling > 0)
        //    {
        //        ceiling--;
        //        if (ceiling % 3 == 0 || ceiling % 5 == 0)
        //        {
        //            multiples.Add(ceiling);                    
        //        }

        //        SumMultiples(ceiling);
        //    }
                
        //    return multiples.Sum();
        //}


        
        
        //recursive without using class-scoped List
        public void SumMultiples(int ceiling, ref int sum)
        {
            if (ceiling > 0)
            {
                ceiling--;
                if (ceiling % 3 == 0 || ceiling % 5 == 0)
                {
                    sum = sum + ceiling;
                }
                SumMultiples(ceiling, ref sum);
            }            
        }
    }
}

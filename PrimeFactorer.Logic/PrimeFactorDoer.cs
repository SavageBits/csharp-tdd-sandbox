using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactorer.Logic
{
    public class PrimeFactorDoer
    {
        private List<long> primesList;
        public PrimeFactorDoer()
        {
            primesList = new List<long>(ReadPrimesFromFile());
        }

        //possible optimizations:
        // list of prime numbers     
        // if it's not divisible by 2, it won't be divisible by any factor of 2
        public static List<long> GetFactors(long number)
        {
            long divisor = 1;
            List<long> factors = new List<long>();

            bool divisibleBy2 = number%2 == 0;

            while (divisor <= number)
            {
                if (!divisibleBy2 && divisor%2 == 0)
                {
                        
                }
                else if (number%divisor == 0)
                { 
                    factors.Add(divisor);                                       
                }

                divisor++;
            }

            return factors;
        }

        public List<long> GetPrimeFactors(long number)
        {            
            List<long> factors = new List<long>(GetFactors(number));
            List<long> primeFactors = new List<long>();            

            foreach (long factor in factors)
            {
                if (IsPrime(factor))
                {
                    primeFactors.Add(factor);
                }
            }

            return primeFactors;
        }

        //this will be slow
        //make this self-memoizing so it can learn primes as it goes
        //public bool IsPrime(long number, long? divisor = null)
        //{            
        //    bool isPrime = true;

        //    if (divisor == null)
        //    {
        //        divisor = 2;
        //    }

        //    //no reason to check the actual number
        //    if (divisor < number)
        //    {
        //        if (primesList.Contains(number))
        //        {
        //            return true;
        //        }

        //        if (number % divisor == 0)
        //        {
        //            return false;
        //        }
         
        //        divisor++;

        //        isPrime = IsPrime(number, divisor);
        //    }

        //    if (isPrime && !primesList.Contains((long)divisor))
        //    {
        //        primesList.Add((long)divisor);
        //        SavePrimeToFile(divisor);
        //    }

        //    return isPrime;
        //}

        public bool IsPrime(long number)
        {
            bool isPrime = true;
           
            long divisor = 2;            

            //no reason to check the actual number
            while (divisor < number)
            {
                if (primesList.Contains(number))
                {
                    return true;
                }
                               
                if (number % divisor == 0)
                {
                    return false;
                }

                if (!primesList.Contains(divisor) && IsPrime(divisor))
                {
                    primesList.Add(divisor);
                    SavePrimeToFile(divisor);

                }

                divisor++;                
            }            

            return isPrime;
        }

        private static List<long> ReadPrimesFromFile()
        {
            List<long> primes = new List<long>();

            try
            {
                StreamReader sr = new StreamReader("C:\\primes\\primes.txt");


                var line = sr.ReadLine();

                while (line != null)
                {
                    primes.Add(Convert.ToInt64(line));

                    line = sr.ReadLine();
                }

                sr.Close();
            }
            catch
            {
                
            }
               
            return primes;
        }  

        private static void SavePrimeToFile(long? divisor)
        {
            StreamWriter sw = new StreamWriter("C:\\primes\\primes.txt", true);

            sw.WriteLine(divisor.ToString());

            sw.Close();
        }


        public long GetHighestPrimeFactor(long number)
        {
            return GetPrimeFactors(number).Max();
        }
    }
}

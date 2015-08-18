using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation
{
    public class StringCalculator
    {
        public ILogger StringCalculatorLogger { get; set; }

        public StringCalculator(ILogger stringCalculatorLogger)
        {
            this.StringCalculatorLogger = stringCalculatorLogger;
        }

        public int Add()
        {
            return 0;
        }

        public int Add(string s)
        {
            string[] customDelimiters = GetCustomDelimiters(ref s);

            s = s.Trim();

            string[] numbers = s.Split(customDelimiters, StringSplitOptions.None);
            //string[] numbers = s.Split(new string[] {",", "\n", customDelimiter}, StringSplitOptions.None);
            

            string invalidNumbers = GetInvalidNumbersString(numbers);

            if (invalidNumbers.Length > 0)
            {
                throw new Exception(String.Concat("negatives not allowed", invalidNumbers.ToString()));
            }


            int sum = AddNumbers(numbers);

            StringCalculatorLogger.Write(sum.ToString());

            return sum;
            //return numbers.Sum(n => Convert.ToInt32(n));
        }

        private int AddNumbers(string[] numbers)
        {
            int total = numbers.Select(n => Convert.ToInt32(n)).Where(i => i <= 1000).Sum();


            //foreach (string n in numbers)
            //{
            //    int i = Convert.ToInt32(n);

            //    if (i <= 1000)
            //    {
            //        total += i;
            //    }
            //}

            return total;
        }
        
        private string[] GetCustomDelimiters(ref string s)
        {
            List<string> customDelimiters = new List<string>();

            //default delimiters
            customDelimiters.Add(",");
            customDelimiters.Add("\n");

            while (StartsWithDelimiters(s))
            {
                customDelimiters.Add(GetCustomDelimiter(ref s));
            }

            return customDelimiters.ToArray();
        }

        private string GetCustomDelimiter(ref string s)
        {
            string customDelimiter = "";

            if (s.StartsWith("//"))
            {
                s = s.Remove(0, 2);
            }

            if (s.StartsWith("["))
            {
                customDelimiter = s.Substring(1, s.IndexOf(']') - 1);

                s = s.Remove(0, customDelimiter.Length + 2);
            }
            else
            {
                customDelimiter = s.Substring(0, s.IndexOf('\n'));

                s = s.Remove(0, customDelimiter.Length);

            }

            return customDelimiter;
        }

        private bool StartsWithDelimiters(string s)
        {
            return s.StartsWith("//") || s.StartsWith("[");
        }       

        private string GetInvalidNumbersString(string[] numbers)
        {
            StringBuilder invalidNumbers = new StringBuilder();
            foreach (string n in numbers)
            {
                if (n.Contains('-'))
                {
                    invalidNumbers.Append(n);
                }
            }

            return invalidNumbers.ToString();
        }
    }

    public interface ILogger
    {
        void Write(string msg);
    }

    public class StringCalculatorLogger : ILogger
    {
        public void Write(string msg)
        {
            Console.Write(msg);
        }
    }
}

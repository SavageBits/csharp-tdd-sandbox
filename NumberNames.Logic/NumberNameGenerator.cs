using System;
using System.Collections.Generic;

namespace NumberNames.Logic
{
    public class NumberNameGenerator
    {
        private string[] ones = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };
        private string[] tens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private Dictionary<int, string> places = new Dictionary<int, string>()
        {
            { 100, "hundred" },
            { 1000, "thousand" }          
        };

        //count the length in original number
        //while remainder > 0 do        
        // create a number with length starting with 1 and filled with 0s
        // originalNumber = originalNumber%[number we got above ie. 100, 10000, etc]        
        public string ConvertNumberToString(int numberToConvert)
        {
            string numberName = "";
            
            //could also convert to string and .Length()
            int countOfPlaces = Convert.ToInt32(Math.Floor(Math.Log10(numberToConvert) + 1));
            string divisorString = "1";
            int divisor = Convert.ToInt32(divisorString.PadRight(countOfPlaces, '0'));

            numberName = GetStringName(numberToConvert, divisor, places[divisor]);
            

            return numberName;
        }

        public string GetStringNameForNumberLessThanOneHundred(int numberToConvert)
        {
            //string hundredsName = GetHundredsString(numberToConvert);
            string tensName = GetTensString(numberToConvert);

            if (tensName.Length > 0)
            {
                tensName += " ";
            }

            return tensName + ones[numberToConvert % 10];
        }

        public string GetTensString(int numberToConvert)
        {
            return tens[numberToConvert / 10];
        }

        public string GetHundredsString(int numberToConvert)
        {
            return GetStringName(numberToConvert, 100, "hundred");
        }

        public string GetStringName(int numberToConvert, int place, string scope)
        {
            return ones[numberToConvert / place] + " " + scope;
        }
    }
}

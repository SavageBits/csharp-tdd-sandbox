using System.Linq;

namespace Haiku.Logic
{
    public class HaikuParser
    {
        private string[] _haikuLinesArray;

        public HaikuParser(string haikuToParse)
        {
            _haikuLinesArray = haikuToParse.Split('/');
        }

        public bool IsHaiku()
        {
            bool isHaiku = false;

            if (CountLines() == 3)
            {
                bool firstLineHas5Syllables = CountSyllables(_haikuLinesArray[0]) == 5;
                bool secondLineHas7Syllables = CountSyllables(_haikuLinesArray[1]) == 7;
                bool thirdLineHas5Syllables = CountSyllables(_haikuLinesArray[2]) == 5;

                isHaiku = firstLineHas5Syllables && secondLineHas7Syllables && thirdLineHas5Syllables;
            }

            return isHaiku;
        }

        public int CountSyllables(string line)
        {
            int syllableCount = 0;
            bool foundVowel = false;
            foreach (char c in line)
            {
                if (IsVowel(c))
                {
                    if (!foundVowel)
                    {             
                        syllableCount++;
                        foundVowel = true;
                    }
                }
                else
                {
                    foundVowel = false;
                }
            }

            return syllableCount;
        }

        public bool IsVowel(char letter)
        {
            char[] vowelsArray = {'a','e','i','o','u','y'};

            return vowelsArray.Contains(letter);
        }

        public int CountLines()
        {           
            //string[] haikuLinesArray = haikuToCount.Split('/');

            return _haikuLinesArray.Count();

            //return haikuToCount.Count(c => c == '/') + 1;

            //foreach (char c in haikuToCount)
            //{
            //    if (c == '/')
            //        lineCount++;
            //}
        }        
    }
}

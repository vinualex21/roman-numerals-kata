using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeral2Number
{
    public class Converter
    {
        public int ConvertRomanNumeralToNumber(string numeral)
        {
            Dictionary<char, int> charSet = new Dictionary<char, int>()
            {{'I',1 }, {'V',5 }, {'X',10 }, {'L',50 },{'C',100 },{'D',500 },{'M',1000 } };

            //Compute from right to left
            var rnReverse = numeral.Reverse().ToArray();

            ValidateNumeral(charSet, rnReverse);

            var currentElement = rnReverse[0];
            var previousElement = char.MinValue;
            int number = charSet[currentElement];

            //flag to keep track of additive or subtractive operation
            bool isSubtraction = false;


            for (int i = 1; i < rnReverse.Length; i++)
            {
                previousElement = rnReverse[i];
                if (charSet[previousElement] < charSet[currentElement])
                {
                    //Subtractive element should be I, X or C
                    //Cannot have consecutive subtractive elements
                    if (!"IXC".Contains(previousElement) || isSubtraction)
                    {
                        throw new ArgumentException("Invalid input. Please enter valid Roman numeral.");
                    }
                    number -= charSet[rnReverse[i]];
                    isSubtraction = true;
                }
                else
                {
                    //Cannot have repeating subtractive element
                    if(charSet[previousElement] == charSet[currentElement] && isSubtraction)
                    {
                        throw new ArgumentException("Invalid input. Please enter valid Roman numeral.");
                    }
                    number += charSet[rnReverse[i]];
                    isSubtraction = false;
                }

                currentElement = previousElement;
            }
            return number;
        }

        private static void ValidateNumeral(Dictionary<char, int> charSet, char[] rnReverse)
        {
            //Contains characters other than roman letters
            if (!rnReverse.All(character => charSet.Keys.Contains(character)))
                throw new ArgumentException("Invalid input. Please enter valid Roman numeral.");

            //I,X,C,M can occur max of 3 times
            var isMoreThanThrice = rnReverse.Where(rn => "IXCM".Contains(rn))
                .GroupBy(g => g)
                .Select(g => new { chara = g.Key, Count = g.Count() })
                .Any(g => g.Count > 3);

            //V,L,D can occur only once
            var isMoreThanOnce = rnReverse.Where(rn => "VLD".Contains(rn))
                .GroupBy(g => g)
                .Select(g => new { chara = g.Key, Count = g.Count() })
                .Any(g => g.Count > 1);

            if (isMoreThanThrice || isMoreThanOnce)
                throw new ArgumentException("Invalid input. Please enter valid Roman numeral.");
        }
    }
}

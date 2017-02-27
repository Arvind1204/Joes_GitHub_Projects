using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDExercises.Classes
{
    public class NumbersToWords
    {
        public string ConvertToWords(int number)
        {
            string[] zeroThroughNine = new string[] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] tenThroughNineteen = new string[] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] factorsOfTen = new string[] { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] hundreds = new string[] { "", "one hundred", "two hundred", "three hundred", "four hundred", "five hundred", "six hundred", "seven hundred", "eight hundred", "nine hundred" };
            string[] thousands = new string[] { "", "one thousand", "two thousand", "three thousand", "four thousand", "five thousand", "six thousand", "seven thousand", "eight thousand", "nine thousand" };
            string[] millions = new string[] { "", "one million", "two million", "three million", "four million", "five million", "six million", "seven million", "eight million", "nine million" };

            string numberString = number.ToString();
            //0 - 9
            if (numberString.Length == 1)
            {
                if (number == 0)
                {
                    return "zero";
                }
                else
                {
                    return zeroThroughNine[number].Replace("  ", " ");
                }
            }
            //10 - 99
            else if (numberString.Length == 2)
            {
                if (numberString[0] == '1')
                {
                    return tenThroughNineteen[(int)Char.GetNumericValue(numberString[1])].Replace("  ", " ");
                }
                else
                {
                    string resultTens = factorsOfTen[(int)Char.GetNumericValue(numberString[0])] + " " + zeroThroughNine[(int)Char.GetNumericValue(numberString[1])];
                    return resultTens.Trim().Replace("  ", " ");
                }
            }
            //100 - 999
            else if (numberString.Length == 3)
            {
                string resultHundreds = hundreds[(int)Char.GetNumericValue(numberString[0])] + " and " + factorsOfTen[(int)Char.GetNumericValue(numberString[1])] + " " + zeroThroughNine[(int)Char.GetNumericValue(numberString[2])];
                string resultHundredsTrimmed =  resultHundreds.Trim();
                if (resultHundredsTrimmed.Substring(resultHundredsTrimmed.Length - 3) == "and")
                {
                    return resultHundredsTrimmed.Substring(0, resultHundredsTrimmed.Length - 3).Trim().Replace("  ", " ");
                }
                else
                {
                    return resultHundredsTrimmed.Replace("  ", " ");
                }
            }
            //1,000 - 9,999
            else if (numberString.Length == 4)
            {
                string resultThousands = thousands[(int)Char.GetNumericValue(numberString[0])] + " " + hundreds[(int)Char.GetNumericValue(numberString[1])] + " and " + factorsOfTen[(int)Char.GetNumericValue(numberString[2])] + " " + zeroThroughNine[(int)Char.GetNumericValue(numberString[3])];
                return resultThousands.Trim().Replace("  ", " ");
            }
            //10,000 - 99,999
            else if (numberString.Length == 5)
            {
                string resultHundreds = hundreds[(int)Char.GetNumericValue(numberString[2])] + " and " + factorsOfTen[(int)Char.GetNumericValue(numberString[3])] + " " + zeroThroughNine[(int)Char.GetNumericValue(numberString[4])];

                if (numberString[0] == '1')
                {
                    string resultAmountOfTeenThousands = tenThroughNineteen[(int)Char.GetNumericValue(numberString[1])] + " thousand";
                    string resultTeenThousandsTotal = resultAmountOfTeenThousands.Trim() + " " + resultHundreds.Trim();
                  if (resultTeenThousandsTotal.Substring(resultTeenThousandsTotal.Length - 3) == "and")
                    {
                        return resultTeenThousandsTotal.Substring(0, resultTeenThousandsTotal.Length - 3).Trim().Replace("  ", " ");
                    }
                    else
                    {
                        return resultTeenThousandsTotal.Trim().Replace("  ", " ");
                    }
                }
                else
                {
                    string resultAmountTensThousands = factorsOfTen[(int)Char.GetNumericValue(numberString[0])] + " " + zeroThroughNine[(int)Char.GetNumericValue(numberString[1])] + " thousand";
                    string resultTensThousandsTotal = (resultAmountTensThousands + " " + resultHundreds).Trim();
                    if (resultTensThousandsTotal.Substring(resultTensThousandsTotal.Length - 3) == "and")
                    {
                        return resultTensThousandsTotal.Substring(0, resultTensThousandsTotal.Length - 3).Trim();
                    }
                    else
                    {
                        return resultTensThousandsTotal.Trim().Replace("  ", " ");
                    }
                }
            }
            //100,000 - 999,999
            else if (numberString.Length == 6)
            {
                string resultHundreds = hundreds[(int)Char.GetNumericValue(numberString[3])] + " and " + factorsOfTen[(int)Char.GetNumericValue(numberString[4])] + " " + zeroThroughNine[(int)Char.GetNumericValue(numberString[5])];
                string resultHundredsTrimmed = resultHundreds.Trim();
                if (resultHundredsTrimmed.Substring(resultHundredsTrimmed.Length - 3) == "and")
                {
                    resultHundreds = resultHundredsTrimmed.Substring(0, resultHundredsTrimmed.Length - 3).Trim();
                }
                else
                {
                    resultHundreds = resultHundredsTrimmed;
                }
                string resultHundredsThousands = (hundreds[(int)Char.GetNumericValue(numberString[0])] + " and " + factorsOfTen[(int)Char.GetNumericValue(numberString[1])] + " " + zeroThroughNine[(int)Char.GetNumericValue(numberString[2])]).Trim();

            if (resultHundredsThousands.Substring(resultHundredsThousands.Length - 3) == "and")
                {
                    resultHundredsThousands = resultHundredsThousands.Substring(0, resultHundredsThousands.Length - 3);
                }
                string resultHundredsThousandsTrimmed = resultHundredsThousands.Trim();
                if (resultHundredsThousandsTrimmed.Substring(resultHundredsTrimmed.Length - 3) == "and")
                {
                    resultHundredsThousands = resultHundredsThousandsTrimmed.Substring(0, resultHundredsTrimmed.Length - 3).Trim();
                }
                else
                {
                    resultHundredsThousands = resultHundredsThousandsTrimmed;
                }
                return (resultHundredsThousands.Trim() + " thousand " + resultHundreds.Trim()).Trim().Replace("  "," ");
            }
            return "";
        }
    }
}

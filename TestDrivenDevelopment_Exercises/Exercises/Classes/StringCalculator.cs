using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDExercises.Classes
{
    public class StringCalculator
    {

        public string Add(string numbers)
        {
            string[] splitLine = numbers.Split(new string[] { "//;", ";", "//!", "!", "\r\n", "\n", ",", " " }, StringSplitOptions.None);

            int totalSum = 0;
            foreach (string item in splitLine)
            {
                if (item == "")
                {
                    totalSum += 0;
                }
                else
                {
                    totalSum += int.Parse(item);
                }
            }
            if (numbers.Contains("//;"))
            {
                return "the delimeter is a semi-colon and returns " + totalSum.ToString();
            }
            else if (numbers.Contains("//!"))
            {
                return "the delimeter is an exclamation point and returns " + totalSum.ToString();
            }
            else
            {
                return totalSum.ToString();
            }
        }
    }
}

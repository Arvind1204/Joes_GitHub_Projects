using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDExercises.Classes;
using TDDExercises;

namespace TDDExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();
            int inputNumber = int.Parse(input);

            Console.ReadKey();

            NumbersToWords example = new NumbersToWords();

            Console.WriteLine(input + " is written as \"" + example.ConvertToWords(inputNumber));

            Console.ReadKey();
        }
    }
}

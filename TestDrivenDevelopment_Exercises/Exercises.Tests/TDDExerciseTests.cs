using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDExercises.Classes;

namespace TDDExercises.Tests
{
    [TestClass]
    public class TDDExerciseTests
    {
        [TestMethod]
        public void StringCalculator()
        {
            StringCalculator test1 = new StringCalculator();
            Assert.AreEqual("0", test1.Add(""));

            StringCalculator test2 = new StringCalculator();
            Assert.AreEqual("1", test2.Add("1"));

            StringCalculator test3 = new StringCalculator();
            Assert.AreEqual("3", test3.Add("1,2"));

            StringCalculator test4 = new StringCalculator();
            Assert.AreEqual("13", test4.Add("1,5,7"));

            StringCalculator test5 = new StringCalculator();
            Assert.AreEqual("25", test5.Add("1,10,11,3"));

            StringCalculator test6 = new StringCalculator();
            Assert.AreEqual("6", test6.Add("1,\n2,3"));

            StringCalculator test7 = new StringCalculator();
            Assert.AreEqual("14", test7.Add("3\n5\n2,4"));

            StringCalculator test8 = new StringCalculator();
            Assert.AreEqual("the delimeter is a semi-colon and returns 3", test8.Add("//;\n1;2"));

        }
        [TestMethod]
        public void ConvertToString()
        {
            //Tests for 0 through 99
            NumbersToWords test = new NumbersToWords();

            Assert.AreEqual("twenty", test.ConvertToWords(20));
            Assert.AreEqual("thirty seven", test.ConvertToWords(37));
            Assert.AreEqual("eighty four", test.ConvertToWords(84));
            Assert.AreEqual("thirty seven", test.ConvertToWords(37));
            Assert.AreEqual("five", test.ConvertToWords(5));
            Assert.AreEqual("zero", test.ConvertToWords(0));

            //Tests 100 through 999
            Assert.AreEqual("one hundred and twenty five", test.ConvertToWords(125));
            Assert.AreEqual("one hundred", test.ConvertToWords(100));
            Assert.AreEqual("nine hundred and ninety nine", test.ConvertToWords(999));
            
            //Tests 1000 through 9999));
            Assert.AreEqual("one thousand two hundred and twenty five", test.ConvertToWords(1225));
            Assert.AreEqual("nine thousand nine hundred and ninety five", test.ConvertToWords(9995));

            //Tests 10,000 through 99,999
            Assert.AreEqual("ten thousand", test.ConvertToWords(10000));
            Assert.AreEqual("twelve thousand", test.ConvertToWords(12000));
            Assert.AreEqual("fifteen thousand", test.ConvertToWords(15000));
            Assert.AreEqual("ninety nine thousand", test.ConvertToWords(99000));
            Assert.AreEqual("forty seven thousand one hundred and twenty five", test.ConvertToWords(47125));

            //***These numbers from the instructions are not grammatically correct***
            //eight hundred and three thousand and three hundred and eight
            //nine hundred and ninetynine thousand and nine-hundred and ninety-nine

            //Tests 100,000 through 999,999
            Assert.AreEqual("four hundred and fifty three thousand six hundred and seventy two", test.ConvertToWords(453672));
            Assert.AreEqual("nine hundred and sixty seven thousand four hundred and fifty eight", test.ConvertToWords(967458));
            Assert.AreEqual("five hundred thousand", test.ConvertToWords(500000));
            Assert.AreEqual("eight hundred and three thousand", test.ConvertToWords(803000));
            Assert.AreEqual("three hundred and eight", test.ConvertToWords(308));
            Assert.AreEqual("nine hundred and ninety nine thousand nine hundred and ninety nine", test.ConvertToWords(999999));
    }
    }
}

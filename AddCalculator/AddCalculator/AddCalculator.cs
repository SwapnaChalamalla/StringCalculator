using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class AddCalculator
    {
        /// <summary>
        /// Seperates numbers from string and make sum
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public int Add(string numbers)
        {

            int result = 0;
            if (!string.IsNullOrEmpty(numbers))
            {
                //Seperate numbers from string 
                var lstNumbers = GetNumbersfromString(numbers);

                //Validate if any negative numbers present in the list
                ValidateNumbers(lstNumbers);

                result = lstNumbers.Sum();
            }
            return result;          
        }

        /// <summary>
        /// Validates if any negative numbers present in the list
        /// </summary>
        /// <param name="numbersList">ex:1,-2,3</param>
        public static void ValidateNumbers(List<int> numbersList)
        {
            if (numbersList.Any(x => x < 0))
            {
                var negativeNumbers = string.Join(",", numbersList.Where(x => x < 0).Select(x => x.ToString()).ToArray());
                throw new System.Exception("negatives not allowed " + " " + negativeNumbers);
            }
        }
        /// <summary>
        /// Seperates the numbers from string and converts to list
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static List<int> GetNumbersfromString(string numbers)
        {
            List<int> strNumber = new List<int>();
            string strNumbers = string.Empty;
            string[] strSeperator = { ",", "\n" };
            if (numbers.StartsWith("//"))
            {
                int y = 0;
                strNumber = Regex.Split(numbers, @"\D+").Where(x => int.TryParse(x, out y)).Select(x => y).ToList();
            }
            else
            {
                strNumbers = numbers.Replace("\\n", ",");

                //Split the string and convert it to integer list
                strNumber = strNumbers.Split(strSeperator, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            }

            return strNumber;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the input");
            string numbers = Console.ReadLine();

            //Create object and invoke the add method
            int result = new AddCalculator().Add(numbers);

            Console.WriteLine("The result is " + " " + result);
            Console.ReadLine();
        }
      
    }
}

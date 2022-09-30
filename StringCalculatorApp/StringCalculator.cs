using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string a)
        {
            if (string.IsNullOrWhiteSpace(a))
            {
                return 0;
            }

            var delimiters = ",\n";
            
            if (a.StartsWith("//"))
            {
                var firstLine = a.Split('\n')[0];
                delimiters += firstLine.Substring(2, 1);
                a = a.Replace(firstLine + "\n", "");
            }

            var numbers = a.Split(delimiters.ToCharArray());

            var result = 0;
            var tmpNumber = 0;
            var negativeNumbers = new List<int>();
            foreach (var number in numbers)
            {
                if (!int.TryParse(number, out tmpNumber))
                {
                    throw new ArgumentException();
                }

                if(tmpNumber < 0)
                {
                    negativeNumbers.Add(tmpNumber);
                }

                result += tmpNumber;
            }

            if(negativeNumbers.Any())
            {
                throw new ArgumentException(string.Join(',', negativeNumbers));
            }

            return result;

        }
    }
}

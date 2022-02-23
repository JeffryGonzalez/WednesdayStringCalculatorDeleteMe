using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorUnitTests;

public class StringCalculator
{
    public int Add(string numbers)
    {
        return numbers switch
        {
            string x when x == "" => 0,
            
            _ => GetNumbers(numbers),
        };

        (char[], string) GetDelimeters(string numbers)
        {
            var delimeters = new List<char> { ',', '\n' };
            if (numbers.StartsWith("//"))
            {
                delimeters.Add(char.Parse(numbers.Substring(2, 1)));
                numbers = numbers.Substring(4);
            }
            return (delimeters.ToArray(), numbers);
        }

        int GetNumbers(string numbers)
        {
            var (delimeters, nums) = GetDelimeters(numbers);
            var ints = nums.Split(delimeters).Select(int.Parse);
            return ints switch
            {
                var i when i.Any(i => i < 0) => throw new NoNegativesAllowedException(),
                _ => ints.Sum()
            };
         
        }

    }
   
}

public class NoNegativesAllowedException : ArgumentOutOfRangeException { }
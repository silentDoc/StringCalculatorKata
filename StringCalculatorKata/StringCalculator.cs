using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            string strNumbers = numbers;

            if (string.IsNullOrEmpty(numbers))
                return 0;

            string delimiter = ",";
            if (numbers.StartsWith("//["))
            {
                delimiter = numbers[3].ToString();
                strNumbers = numbers.Substring(numbers.IndexOf("\n") + 1);
            }

            var groups = strNumbers.Split("\n").ToList();
            List<int> nums = new();

            foreach(var group in groups) 
            {
                var numGroup = group.Split(delimiter, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                var nums_in_row = numGroup.Select(x => int.Parse(x)).ToList();
                nums.AddRange(nums_in_row);
            }
            
            return nums.Sum();
        }
    }
}

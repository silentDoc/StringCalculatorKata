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
                var endline = numbers.IndexOf("\n");
                delimiter = numbers.Substring(3, endline - 1 - 3);
                strNumbers = numbers.Substring(endline + 1);
            }

            var groups = strNumbers.Split("\n").ToList();
            List<int> nums = new();

            foreach(var group in groups) 
            {
                var numGroup = group.Split(delimiter, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                var nums_in_row = numGroup.Select(x => int.Parse(x)).ToList();
                nums.AddRange(nums_in_row);
            }

            nums = nums.Select(x => (x > 1000) ? 0 : x).ToList();

            if (nums.Any(x => x < 0))
            {
                var numEx = string.Join(",", nums.Where(x => x < 0).Select(x => x.ToString()).ToList());
                throw new InvalidOperationException("Negatives not allowed " + numEx);
            }

            return nums.Sum();
        }
    }
}

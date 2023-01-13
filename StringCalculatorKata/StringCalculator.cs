using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                var delimiterline = numbers.Substring(0, endline);
                strNumbers = numbers.Substring(endline + 1);

                Regex regex = new Regex(@"(\[[^\[\]]+\])");
                var regexGroups = regex.Matches(delimiterline).ToList();
                
                List<string> delimiters = new List<string>();
                foreach (var group in regexGroups)
                    delimiters.Add(group.Value.Replace("[","").Replace("]", ""));

                foreach (var customDelimiter in delimiters)
                    strNumbers = strNumbers.Replace(customDelimiter, ",");
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

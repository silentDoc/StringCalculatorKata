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
            if (string.IsNullOrEmpty(numbers))
                return 0;

            var groups = numbers.Split("\n").ToList();
            List<int> nums = new();

            foreach(var group in groups) 
            {
                var numGroup = group.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                var nums_in_row = numGroup.Select(x => int.Parse(x)).ToList();
                nums.AddRange(nums_in_row);
            }
            
            return nums.Sum();

        }
    }
}

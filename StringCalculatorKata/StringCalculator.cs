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

            var groups = numbers.Split(",");

            if (groups.Count() == 1)
            {
                int number = 0;
                if (!int.TryParse(groups[0], out number))
                    throw new InvalidOperationException();
                else return number;
            }
            else
            {
                int num1 = 0;
                int num2 = 0;
                if (!int.TryParse(groups[0], out num1))
                    throw new InvalidOperationException();
                if (!int.TryParse(groups[1], out num2))
                    throw new InvalidOperationException();
                return num1+num2;
            }
        }
    }
}

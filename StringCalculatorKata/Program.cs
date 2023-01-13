namespace StringCalculatorKata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringCalculator sc = new();

            string input = "1, 2";
            var result = sc.Add("1, 2");
            Console.WriteLine(input + " -> " + result.ToString());
            
            input = "";
            result = sc.Add(input);
            Console.WriteLine(input + " -> " + result.ToString());

            input = "1,2,3,4,5,6";
            result = sc.Add(input);
            Console.WriteLine(input + " -> " + result.ToString());

            input = "1\n2,3\n4,5,6";
            result = sc.Add(input);
            Console.WriteLine(input + " -> " + result.ToString());

            input = "//[++][;;][***]\n1++3;;5***6***10";
            result = sc.Add(input);
            Console.WriteLine(input + " -> " + result.ToString());
        }
    }
}
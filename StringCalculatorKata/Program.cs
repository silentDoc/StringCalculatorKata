namespace StringCalculatorKata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringCalculator sc = new();
            sc.Add("//[+][;][*]\n1+3;5*6*10");
        }
    }
}
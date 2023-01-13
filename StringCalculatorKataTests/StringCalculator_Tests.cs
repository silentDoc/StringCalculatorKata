using StringCalculatorKata;

namespace StringCalculatorKataTests
{
    [TestClass]
    public class StringCalculator_ShouldSum
    {
        [TestMethod]
        public void ShouldReturnSameNumber_IfOneNumberString()
        {
            string inputString = "19";
            int expected = 19;
            StringCalculator _stringCalculator = new();

            int result = _stringCalculator.Add(inputString);

            Assert.AreEqual(expected, result, "One number string not handled properly");
        }

        [TestMethod]
        public void ShouldReturnSum_IfTwoNumberString()
        {
            string inputString = "19,27";
            int expected = 46;
            StringCalculator _stringCalculator = new();

            int result = _stringCalculator.Add(inputString);

            Assert.AreEqual(expected, result, "Two number string not handled properly");
        }

        [TestMethod]
        public void ShouldReturnSum_IfManyNumberString()
        {
            string inputString = "19,27,4,25,12";
            int expected = 87;
            StringCalculator _stringCalculator = new();

            int result = _stringCalculator.Add(inputString);

            Assert.AreEqual(expected, result, "Two number string not handled properly");
        }
    }
    
    [TestClass]
    public class StringCalculator_HandleInput
    {
        [TestMethod]
        public void ShouldReturnZero_IfEmptyString()
        {
            string inputString = "";
            int expected = 0;
            StringCalculator _stringCalculator = new();

            int result = _stringCalculator.Add(inputString);

            Assert.AreEqual(expected, result, "Empty string not handled properly");
        }
        

        [DataTestMethod]
        [DataRow("1\n2,3", 6)]
        [DataRow("1\n2,3\n4,5,6", 21)]
        [DataRow("1\n2\n3\n4", 10)]
        public void ShouldHandleNewLineDelimiter(string input, int expected)
        {
            StringCalculator _stringCalculator = new();
            int result = _stringCalculator.Add(input);
            Assert.AreEqual(expected, result, "Empty string not handled properly");
        }

        [DataTestMethod]
        [DataRow("//[+]\n1+3+5", 9)]
        [DataRow("//[;]\n1;3", 4)]
        public void ShouldHandleCustomDelimiter(string input, int expected)
        {
            StringCalculator _stringCalculator = new();
            int result = _stringCalculator.Add(input);
            Assert.AreEqual(expected, result, "Empty string not handled properly");
        }

        [DataTestMethod]
        [DataRow("//[+]\n1+3+-5", "Negatives not allowed -5")]
        [DataRow("-1,-3,-2", "Negatives not allowed -1,-3,-2")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldThrowException_IfNegativeNum(string input, string expected)
        {
            StringCalculator _stringCalculator = new();
            try
            {
                int result = _stringCalculator.Add(input);
            }
            catch(InvalidOperationException io_ex)
            {
                StringAssert.Contains(io_ex.Message, expected);
            }
            
        }

    }
}
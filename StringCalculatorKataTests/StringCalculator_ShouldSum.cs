using StringCalculatorKata;

namespace StringCalculatorKataTests
{
    [TestClass]
    public class StringCalculator_ShouldSum
    {
        [TestMethod]
        public void ShouldReturnSum_IfTwoNumberString()
        {
            string inputString = "19,27";
            int expected = 46;
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
        public void ShouldThrowException_IfNonNumberString()
        {
            string inputString = "bla";
            StringCalculator _stringCalculator = new();
            Assert.ThrowsException<InvalidOperationException>(() => _stringCalculator.Add(inputString));
        }
    }
}
using System;
using Xunit;

namespace SimpleMath
{
    public class Math
    {
        [Fact]
        public void WhenUserInputNumberAsString_ThenConvertToNumber()
        {
            // Arrange
            string inputNumber = "1";
            int expected = 1;   
            // Act
            int actual = ConvertToNumber(inputNumber);
            // Assert
            Assert.Equal(actual.GetType(), expected.GetType());

        }

        [Fact]
        public void WhenUserInputNumber_ThenDoSimpleMath()
        {
            // Arrange
            string input1 = "2";   
            string  input2 = "2";
            // Act
            (int sum, int minus, int multiply, int divide) = DoSimpleMath(input1, input2);
            // Assert
            Assert.Equal("4", sum.ToString());
            Assert.Equal("0", minus.ToString());
            Assert.Equal("4", multiply.ToString());
            Assert.Equal("1", divide.ToString());

        }

        private (int sum, int minus, int multiply, int divide) DoSimpleMath(string input1, string input2)
        {
            int _input1 = ConvertToNumber(input1);
            int _input2 = ConvertToNumber(input2);  

            int sum = _input1 + _input2;
            int minus = _input1 - _input2;  
            int multiply = _input1 * _input2;  
            int divide = _input1 / _input2;  

            return (sum, minus, multiply, divide);  
        }

        private int ConvertToNumber(string inputNumber)
        {
            return Convert.ToInt32(inputNumber);
        }
    }
}
using System;
using Xunit;

namespace Hello
{
    public class SayingHello
    {
        [Fact]
        public void WhenUserGiveTheName_ThenSayHello()
        {
            // Arrange

            string name = "Hussein";

            // Act
            string expected = $"Hello,{name},Nice too meet you!";

            string actual = SayHello(name);
            // Assert

            Assert.Equal(expected, actual);
        }

        private string SayHello(string name)
        {
            return $"Hello,{name},Nice too meet you!";
        }
    }
}
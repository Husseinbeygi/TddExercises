using Xunit;

namespace PrintingQuote
{
    public class QuoteTest
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            string quote = "This is a quote";
            string author = "Test";
            string expected = "Test Says :\"This is a quote\"";
            //Act
            string actual = GenrateQuote(quote, author);

            //Assert

            Assert.Equal(expected.Trim(), actual.Trim());

        }

        private string GenrateQuote(string quote, string author)
        {
            return author + " Says :" + "\"" + quote + "\"";
        }
    }
}
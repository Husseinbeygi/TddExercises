using Xunit;

namespace PizaParty
{
    public class PizzaPartyTest
    {
        [Theory]
        [InlineData(8, 2, 8, 2, 0)]
        [InlineData(10, 2, 8, 1, 6)]
        public void WhenUserEnterANumber_ThenCalculateThePizzaSlices(int NumberOfPeople, int Pizza, int SlicesPerPizza, int SPP_expexted, int leftover_expected)
        {
            //Act
            (int actual, int LeftOver) = CalculateThePizzaSlices(NumberOfPeople, Pizza, SlicesPerPizza);


            //Assert
            Assert.Equal(SPP_expexted.ToString(), actual.ToString());
            Assert.Equal(leftover_expected.ToString(), LeftOver.ToString());

        }

        private (int actual, int LeftOver) CalculateThePizzaSlices(int numberOfPeople, int pizza, int slicesPerPizza)
        {
            int actual = (pizza * slicesPerPizza) / numberOfPeople;
            int leftOver = (pizza * slicesPerPizza) % numberOfPeople;
            return (actual, leftOver);
        }
    }
}
using System;
using Xunit;

namespace AreaOfARectangularRoom
{
    public class AreaTest
    {
        [Fact]
        public void Test1()
        {
            double lengthinfeet = 15;
            double widthinfeet = 20;
            double expectedinfeet = 300;
            double expectedinmeter = 27.871;

            double actualinfeet = CalculateArea(lengthinfeet, widthinfeet, Types.Imperial);
            double actualinMeter = CalculateArea(lengthinfeet, widthinfeet, Types.Metrics);

            Assert.Equal(expectedinfeet, actualinfeet);
            Assert.Equal(expectedinmeter, actualinMeter);

        }

        private double CalculateArea(double lengthinfeet, double widthinfeet, Types type)
        {
            if (type == Types.Imperial)
            {
                double area = lengthinfeet * widthinfeet;
                return area;
            }
            else
            {
                double area = lengthinfeet * widthinfeet;
                return Math.Round(area / 10.764,3);
            }
        }

        enum Types
        {
            Metrics,
            Imperial

        }
    }
}
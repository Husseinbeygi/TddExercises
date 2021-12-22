using System;
using System.Collections.Generic;
using Xunit;

namespace MadLibs
{
    public class UnitTest1
    {

        [Fact]
        public void Test1()
        {
            //  Arrange 
            string noun = "dog";
            string verb = "walk";
            string adjective = "blue";
            string adverb = "quickly";

            // Act
            string actual = MakeMadlib(noun, verb, adjective, adverb);
            string expected = "Do you walk your blue dog quickly? That's hilarious!";

            // Assert
            Assert.Equal(expected, actual);     
        }

        private string MakeMadlib(string noun, string verb, string adjective, string adverb)
        {
            return $"Do you {verb} your {adjective} {noun} {adverb}? That's hilarious!";
        }
    }
}
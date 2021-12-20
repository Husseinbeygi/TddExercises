using Xunit;

namespace CountTheNumberOFCharacters
{
    public class CountTest
    {
        private string Name { get; set; }       
        public CountTest()
        {
            Name = "Hussein";
        }

        [Fact]
        public void WhenUserInsertText_ThenCheckIsInputEmptyOrNull()
        {
            // Act
            var IsEmptyOrNull = IsInputEmptyOrNull(Name);
            // Assert
            Assert.False(IsEmptyOrNull);  

        }

        [Fact]
        public void WhenUserInsertText_ThenReturnTheCountOfText()
        {
            // Act
            var count = CountTheText(Name);
            // Assert
            Assert.Equal(7, count);
        }

        [Fact]
        public void WhenUserInsertNullText_ThenReturnZero()
        {
            // Act
            var countNull = CountTheText(null);
            // Assert
            Assert.Equal(0, countNull);
        }

        [Fact]
        public void WhenUserInsertEmptyText_ThenReturnZero()
        {
            // Act
            var countEmpty = CountTheText("");
            // Assert
            Assert.Equal(0, countEmpty);
        }

        private int CountTheText(string name)
        {
            if (IsInputEmptyOrNull(name))
            {
                return 0;
            }        
            return name.Length;   
        }

        private bool IsInputEmptyOrNull(string v)
        {
            if (string.IsNullOrWhiteSpace(v))
                return  true;

            return false;       
        }
    
        
    
    }


}
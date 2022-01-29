using System;

namespace Course_Test
{
    public class identifierFixture : IDisposable
    {
        public Guid guid { get; set; } 
        public identifierFixture()
        {
            guid = Guid.NewGuid();   
        }

        public void Dispose()
        {
            guid = Guid.Empty;  
        }
    }
}
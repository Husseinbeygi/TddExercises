using System;

namespace Academy.Domain.Tests.Unit.ClassFixtures
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
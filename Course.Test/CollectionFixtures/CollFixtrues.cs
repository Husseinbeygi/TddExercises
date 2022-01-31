using System;

namespace Academy.Domain.Tests.Unit.CollectionFixtures
{
    public class CollFixtrues : IDisposable
    {
        public Guid guid { get; set; }
        public CollFixtrues()
        {
            guid = Guid.NewGuid();
        }


        public void Dispose()
        {
            guid  = Guid.Empty;
        }
    }
}

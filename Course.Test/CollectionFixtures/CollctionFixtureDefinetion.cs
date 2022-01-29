using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Course_Test.CollectionFixtures
{

    [CollectionDefinition("ColFix")]
    public class CollctionFixtureDefinetion : ICollectionFixture<CollFixtrues>
    {
    }
}

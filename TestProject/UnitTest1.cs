using System;
using Xunit;
using Xunit.Abstractions;

namespace TestProject
{
    public class UnitTest
    {
        private readonly ITestOutputHelper OP /*output*/;

        public UnitTest(ITestOutputHelper helper)
        => OP = helper;


        [Fact]
        public void Test1()
        {

        }
    }
}

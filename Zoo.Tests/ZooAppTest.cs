using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Zoos.Tests
{
    public class ZooAppTest
    {
        [Fact]
        public void ShouldBeAbleToCreateZooApp()
        {
            ZooApp zooApp = new ZooApp();
            zooApp.AddZoo(new Zoo());
            Assert.NotNull(zooApp);
        }
    }
}

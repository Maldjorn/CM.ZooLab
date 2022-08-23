using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ZooA.Animals.Bird;
using ZooA.Animals.Mammals;

namespace Zoos.Tests
{
    public class AnimalTests
    {
        [Fact]
        public void ShouldBeAbleToCreateAnimal()
        {
            Parrot parrot = new Parrot();
            Assert.InRange(parrot.ID, 0, int.MaxValue);
        }
        [Fact]
        public void ShouldBeAbleToCreateAnimalWitUniqueID()
        {
            Parrot parrot = new Parrot();
            Assert.InRange(parrot.ID, 0, int.MaxValue);
            Bison bison = new Bison();
            Assert.InRange(bison.ID, 0, int.MaxValue);
            Assert.NotEqual(parrot.ID, bison.ID);
        }
    }
}

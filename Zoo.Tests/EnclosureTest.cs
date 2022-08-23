using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ZooA.Animals;
using ZooA.Animals.Mammals;
using Zoos;
using ZooA.Exceptions;
using ZooA.Animals.Bird;

namespace Zoos.Tests
{
    public class EnclosureTest
    {
        [Fact]
        public void ShouldNotBeFriendly()
        {
            Zoo zoo = new Zoo();
            zoo.AddEnclosure("Los", 7000);
            var enclosure = zoo.FindAvaibleEnclosure(new Elephant());
            Assert.NotNull(enclosure);
            Assert.Throws<NotFriendlyAnimalException>(() => enclosure = zoo.FindAvaibleEnclosure(new Snake()));
            Assert.Throws<NotFriendlyAnimalException>(() => enclosure = zoo.FindAvaibleEnclosure(new Lion()));
            Assert.Throws<NotFriendlyAnimalException>(() => enclosure = zoo.FindAvaibleEnclosure(new Elephant()));
            Assert.Throws<NotFriendlyAnimalException>(() => enclosure = zoo.FindAvaibleEnclosure(new Penguin()));
        }
        [Fact]
        public void ShouldBeFriendlySnakes()
        {
            Zoo zoo = new Zoo();
            zoo.AddEnclosure("Los", 7000);
            var enclosure = zoo.FindAvaibleEnclosure(new Snake());
            Assert.NotNull(enclosure);
            enclosure = zoo.FindAvaibleEnclosure(new Snake());
        }

        [Fact]
        public void ShouldBeFriendlyBisons()
        {
            Zoo zoo = new Zoo();
            zoo.AddEnclosure("Los", 7000);
            var enclosure = zoo.FindAvaibleEnclosure(new Elephant());
            Assert.NotNull(enclosure);
            enclosure = zoo.FindAvaibleEnclosure(new Bison());
        }

        [Fact]
        public void ShouldBeFriendlyParrot()
        {
            Zoo zoo = new Zoo();
            zoo.AddEnclosure("Los", 7000);
            var enclosure = zoo.FindAvaibleEnclosure(new Elephant());
            Assert.NotNull(enclosure);
            enclosure = zoo.FindAvaibleEnclosure(new Parrot());
        }
        [Fact]
        public void ShouldBeFriendlyPenguin()
        {
            Zoo zoo = new Zoo();
            zoo.AddEnclosure("Los", 7000);
            var enclosure = zoo.FindAvaibleEnclosure(new Penguin());
            Assert.NotNull(enclosure);
            enclosure = zoo.FindAvaibleEnclosure(new Penguin());
        }
        [Fact]
        public void ShouldBeFriendlyLion()
        {
            Zoo zoo = new Zoo();
            zoo.AddEnclosure("Los", 7000);
            var enclosure = zoo.FindAvaibleEnclosure(new Lion());
            Assert.NotNull(enclosure);
            enclosure = zoo.FindAvaibleEnclosure(new Lion());
        }

        [Fact]
        public void ShouldBeFriendlyElephant()
        {
            Zoo zoo = new Zoo();
            zoo.AddEnclosure("Los", 7000);
            var enclosure = zoo.FindAvaibleEnclosure(new Bison());
            Assert.NotNull(enclosure);
            enclosure = zoo.FindAvaibleEnclosure(new Elephant());
        }
        [Fact]
        public void ShouldNotBeFriendlyTurtle()
        {
            Zoo zoo = new Zoo();
            zoo.AddEnclosure("Los", 7000);
            var enclosure = zoo.FindAvaibleEnclosure(new Snake());
            Assert.NotNull(enclosure);
            Assert.Throws<NotFriendlyAnimalException>(()=>zoo.FindAvaibleEnclosure(new Turtle()));
        }
        [Fact]
        public void ShouldNotBeFriendlyParrot()
        {
            Zoo zoo = new Zoo();
            zoo.AddEnclosure("Los", 7000);
            var enclosure = zoo.FindAvaibleEnclosure(new Snake());
            Assert.NotNull(enclosure);
            Assert.Throws<NotFriendlyAnimalException>(() => zoo.FindAvaibleEnclosure(new Parrot()));
        }
        [Fact]
        public void ShouldNotBeFriendlyBison()
        {
            Zoo zoo = new Zoo();
            zoo.AddEnclosure("Los", 7000);
            var enclosure = zoo.FindAvaibleEnclosure(new Bison());
            Assert.NotNull(enclosure);
            Assert.Throws<NotFriendlyAnimalException>(() => zoo.FindAvaibleEnclosure(new Bison()));
        }
        [Fact]
        public void ShouldNotBeAvaibleEnclosures()
        {
            Zoo zoo = new Zoo();
            zoo.AddEnclosure("Los", 1500);
            var enclosure = zoo.FindAvaibleEnclosure(new Bison());
            Assert.NotNull(enclosure);
            Assert.Throws<NoAvaibleSpaceException>(() => enclosure = zoo.FindAvaibleEnclosure(new Bison()));
        }
    }
}

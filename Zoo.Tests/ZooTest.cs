using System;
using Xunit;
using ZooA.Animals;
using ZooA.Animals.Bird;
using ZooA.Animals.Mammals;
using System.Collections.Generic;
using ZooA.Exceptions;
using ZooA.Medicines;

namespace Zoos.Tests
{
    public class ZooTest
    {
        [Fact]
        public void ShouldBeAbleTocreateZooObject()
        {
            var zoo = new Zoo();
            Assert.NotNull(zoo);
        }
        [Fact]
        public void ShouldBeAbleTocreateZooObjectWithArgs()
        {
            var zoo = new Zoo("France");
            Assert.NotNull(zoo);
            Assert.Equal("France", zoo.Location);
        }

        [Fact]
        public void ShouldBeAbletoHireVeterianrian()
        {
            var zoo = new Zoo();
            {
                zoo.AddEnclosure("q",1000);
                zoo.FindAvaibleEnclosure(new Parrot());
                zoo.FindAvaibleEnclosure(new Turtle());
                var veterinarian = new Veterinarian("Adam","Gass");
                veterinarian.AddAnimalExperience(new Parrot());
                veterinarian.AddAnimalExperience(new Turtle());
                zoo.HireEmployee(veterinarian);
                Assert.Equal("Veterinarian", zoo.Employees[0].GetType().Name);
            }
        }
        [Fact]
        public void ShouldBeAbletoHireZooKeeper()
        {
            var zoo = new Zoo();
            {
                zoo.AddEnclosure("q", 1000);
                zoo.FindAvaibleEnclosure(new Parrot());
                var zooKeeper = new ZooKeeper("Adam", "Gass");
                zooKeeper.AddAnimalExperience(new Parrot());
                zoo.HireEmployee(zooKeeper);
                Assert.Equal("ZooKeeper", zoo.Employees[0].GetType().Name);
            }
        }
        [Fact]
        public void ShouldBeAbleToAddEnclouser()
        {
            var zoo = new Zoo();
            zoo.AddEnclosure("Mohave", 1000);
            zoo.AddEnclosure("Los", 2000);
            Assert.Equal("Mohave", zoo.Enclosures[0].Name);
            Assert.Equal("Los", zoo.Enclosures[1].Name);
            Assert.Equal(1000, zoo.Enclosures[0].SquareFeet);
            Assert.Equal(2000, zoo.Enclosures[1].SquareFeet);
            
        }
        [Fact]
        public void ShouldBeAbleToFindAvaibleEnclousere()
        {
            var zoo = new Zoo();
            zoo.AddEnclosure("Los", 1000);
            Parrot parrot = new Parrot();
            Assert.Equal(5, parrot.RequiredSpaceSqFt);
            Enclosure enclosure = zoo.FindAvaibleEnclosure(parrot);
            Assert.NotNull(enclosure);
            Assert.Equal("Los", enclosure.Name);
        }
        [Fact]
        public void ShouldBeAbleToFeedAnimals()
        {
            var zoo = new Zoo();
            zoo.AddEnclosure("Los", 1000);
            Parrot parrot = new Parrot();
            Parrot parrot2 = new Parrot();
            Enclosure enclosure = zoo.FindAvaibleEnclosure(parrot);
            enclosure = zoo.FindAvaibleEnclosure(parrot2);
            ZooKeeper zooKeeper = new ZooKeeper("Name", "NotName");
            ZooKeeper zooKeeper2 = new ZooKeeper("Name2", "NotName2");
            zooKeeper.AddAnimalExperience(parrot);
            zooKeeper2.AddAnimalExperience(parrot);
            zoo.HireEmployee(zooKeeper);
            zoo.HireEmployee(zooKeeper2);
            var todayDate = DateTime.Now;
            parrot.AddFeedSchedule( new List<int>() { todayDate.AddHours(-1).Hour, todayDate.AddHours(1).Hour });
            parrot2.AddFeedSchedule(new List<int>() { todayDate.AddHours(-1).Hour, todayDate.AddHours(1).Hour });
            zoo.FeedAnimals(todayDate);
            Assert.Equal("NotName2", zoo.Enclosures[0].Animals[1].FeedTimes[1].feedByZooKeper.LastName);
        }

        [Fact]
        public void ShouldBeAbleToFeedAnimalsWithGoodFood()
        {
            var zoo = new Zoo();
            zoo.AddEnclosure("Los", 1000);
            Parrot parrot = new Parrot();
            Parrot parrot2 = new Parrot();
            Enclosure enclosure = zoo.FindAvaibleEnclosure(parrot);
            enclosure = zoo.FindAvaibleEnclosure(parrot2);
            ZooKeeper zooKeeper = new ZooKeeper("Name", "NotName");
            ZooKeeper zooKeeper2 = new ZooKeeper("Name2", "NotName2");
            zooKeeper.AddAnimalExperience(parrot);
            zooKeeper2.AddAnimalExperience(parrot);
            zoo.HireEmployee(zooKeeper);
            zoo.HireEmployee(zooKeeper2);
            var todayDate = DateTime.Now;
            parrot.AddFeedSchedule(new List<int>() { todayDate.AddHours(-1).Hour, todayDate.AddHours(1).Hour });
            parrot2.AddFeedSchedule(new List<int>() { todayDate.AddHours(-1).Hour, todayDate.AddHours(1).Hour });
            zoo.FeedAnimals(todayDate);
            Assert.Equal("NotName2", zoo.Enclosures[0].Animals[1].FeedTimes[1].feedByZooKeper.LastName);
        }

        [Fact]
        public void ShouldBeAbleToHealAnimal()
        {
            var zoo = new Zoo();
            zoo.AddEnclosure("Los", 1000);
            Parrot parrot = new Parrot() { IsSick = true};
            Parrot parrot2 = new Parrot();
            Enclosure enclosure = zoo.FindAvaibleEnclosure(parrot);
            enclosure = zoo.FindAvaibleEnclosure(parrot2);
            var veterinarian = new Veterinarian("Name", "NotName");
            veterinarian.AddAnimalExperience(new Parrot());
            zoo.HireEmployee(veterinarian);
            zoo.HealAnimals();
            Assert.False(parrot.IsSick);
        }
        [Fact]
        public void ShouldNotValidateZooKeeper()
        {
            var zoo = new Zoo();
            zoo.AddEnclosure("Los", 1000);
            var zooKeeper = new ZooKeeper("Name", "NotName");
            Parrot parrot2 = new Parrot();
            Enclosure enclosure = zoo.FindAvaibleEnclosure(parrot2);
            Assert.Throws<NoNeededExperienceException>(() => zoo.HireEmployee(zooKeeper));
        }
        [Fact]
        public void ShouldNotValidateVeterinarian()
        {
            var zoo = new Zoo();
            zoo.AddEnclosure("Los", 1000);
            var veterinarian = new Veterinarian("Name", "NotName");
            Parrot parrot2 = new Parrot();
            Enclosure enclosure = zoo.FindAvaibleEnclosure(parrot2);
            Assert.Throws<NoNeededExperienceException>(() => zoo.HireEmployee(veterinarian));
        }
        [Fact]
        public void ShouldNotBeableToFindAvaibleEnclosure()
        {
            var zoo = new Zoo();
            zoo.AddEnclosure("Los", 500);
            Assert.Throws<NoAvaibleSpaceException>(() => {
                Enclosure enclosure = zoo.FindAvaibleEnclosure(new Bison());});
        }
    }
}

using System;
using System.Collections.Generic;
using ZooA.Animals;
using ZooA.Animals.Bird;
using ZooA.Animals.Mammals;
using ZooA.IConsole;
using Zoos;
using Zoos.Animals;

namespace MainZoo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.RunZooApp(new MyConsole());
        }

        public void RunZooApp(IConsole console)
        {
            ZooApp zooApp = new ZooApp();
            zooApp.MyConsole = console;
            Zoo zoo1 = new Zoo("Mohave");
            zoo1.MyConsole = console;
            zooApp.AddZoo(zoo1);
            Zoo zoo2 = new Zoo("Africa");
            zoo2.MyConsole = console;
            zooApp.AddZoo(zoo2);
            
            foreach (var item in zooApp.zoos)
            {
                item.AddEnclosure("Enclosure:" + item.Location, 2000);
            }
            List<Animal> animals = new List<Animal>() { new Parrot(), new Elephant(), new Turtle() };
            foreach (var item in zooApp.zoos)
            {
                foreach (var animal in animals)
                {
                    animal.MyConsole = console;
                    item.FindAvaibleEnclosure(animal);
                }              
            }
            List<ZooKeeper> zooKeepers = new List<ZooKeeper>() { new ZooKeeper("Zoo1", "Keeper1"), new ZooKeeper("Zoo2", "Keeper2") };
            List<Veterinarian> veterinarians = new List<Veterinarian>() { new Veterinarian("New1", "Veterinarian1"), new Veterinarian("New2", "Veterinarian2") };
            var todayDate = new DateTime();
            foreach (var item in animals)
            {
                item.AddFeedSchedule(new List<int>() {todayDate.AddHours(1).Hour });
            }
            foreach (var item in zooKeepers)
            {
                foreach (var animal in animals)
                {

                    item.AddAnimalExperience(animal);
                } 
            }

            foreach (var item in veterinarians)
            {
                item.MyConsole = console;
                foreach (var animal in animals)
                {
                    item.AddAnimalExperience(animal);
                }
            }

            foreach (var item in zooApp.zoos)
            {
                foreach (var keeper in zooKeepers)
                {
                    item.HireEmployee(keeper);
                }
            }

            foreach (var item in zooApp.zoos)
            {
                foreach (var veterinarian in veterinarians)
                {
                    item.HireEmployee(veterinarian);
                }
            }

            zooApp.zoos[0].FeedAnimals(new DateTime());
            zooApp.zoos[1].FeedAnimals(new DateTime());
            zooApp.zoos[0].HealAnimals();
            zooApp.zoos[1].HealAnimals(); 
        }
    }

}

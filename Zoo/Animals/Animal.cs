using System;
using System.Collections.Generic;
using ZooA.Foods;
using ZooA.IConsole;
using ZooA.Medicines;

namespace Zoos.Animals
{
    public abstract class Animal
    {
        public abstract int RequiredSpaceSqFt { get; }
        public abstract string[] FavouriteFood { get; }
        public List<FeedTime> FeedTimes { get; } = new List<FeedTime>();
        public List<int> FeedSchedule { get; private set; } = new List<int>();
        public IConsole MyConsole = new MyConsole();
        public bool IsSick { get; set; }
        public int ID { get; }

        public Animal()
        {
            var random = new Random();
            ID = random.Next(0, int.MaxValue);
            if (ID % 2 == 0)
            {
                IsSick = true;
            }
        }
        public abstract bool IsFriendlyWithAnimal(Animal animal);
        public void Feed(DateTime dateTime, ZooKeeper zooKeeper)
        {
            var foodArray = new Food[] { new Meat(), new Grass(), new Vegetable() };
            Random random = new Random();
            var randomFood = foodArray[random.Next(0, 2)];
            foreach (var item in FavouriteFood)
            {
                if (item == randomFood.GetType().Name)
                {
                    FeedTimes.Add(new FeedTime(dateTime, zooKeeper));
                    MyConsole.WriteLine(this.GetType().Name + " was fed by " + zooKeeper.FirstName);
                    break;
                }
                else
                {
                    FeedTimes.Add(new FeedTime(dateTime, zooKeeper));
                    MyConsole.WriteLine(this.GetType().Name + " was fed by " + zooKeeper.FirstName);
                    IsSick = true;
                    break;
                }
            }
        }
        public void AddFeedSchedule(List<int> hours)
        {
            FeedSchedule = hours;
        }
        public void Heal(Medicine medicine)
        {
            IsSick = false;
        }
    }
}
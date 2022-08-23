using System;
using ZooA.Foods;
using ZooA.IConsole;
using Zoos.Animals;

namespace Zoos
{
    public class ZooKeeper : IEmployee
    {
        public ZooKeeper(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public IConsole MyConsole = new MyConsole();
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string AnimalExperience { get; private set; } = "";

        public void AddAnimalExperience(Animal animal)
        {
            AnimalExperience += animal.GetType().Name + ",";
        }
        public bool HasAnimalExperience(Animal animal)
        {
            return AnimalExperience.Contains(animal.GetType().Name);
        }
        public void FeedAnimal(Animal animal, DateTime dateTime)
        {
                animal.Feed(dateTime, this);
        }

    }
}

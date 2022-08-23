using System;
using Zoos.Animals;

namespace ZooA.Animals.Mammals
{
    public class Lion : Mammal
    {
        public override int RequiredSpaceSqFt { get; } = 1000;
        public override string[] FavouriteFood { get; } = { "Grass", "Vegetable", "Meat" };

        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            string FriendlyAnimals = "Lion";
            if (FriendlyAnimals.Contains(animal.GetType().Name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

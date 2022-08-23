using System;
using Zoos.Animals;

namespace ZooA.Animals.Mammals
{
    public class Elephant : Mammal
    {
        public override int RequiredSpaceSqFt { get; } = 1000;
        public override string[] FavouriteFood { get; } = { "Grass", "Vegetable" };

        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            string FriendlyAnimals = "Parrot, Bison, Turtle";
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

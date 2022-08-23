using System;
using Zoos.Animals;

namespace ZooA.Animals.Bird
{
    public class Parrot : Bird
    {
        public override int RequiredSpaceSqFt { get; } = 5;
        //TODO: Add food parrot
        public override string[] FavouriteFood { get; } = { "Grass", "Vegetable" };

        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            string FriendlyAnimals = "Parrot, Bison, Elephant, Turtle";
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

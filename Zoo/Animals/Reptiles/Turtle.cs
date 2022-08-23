using System;
using Zoos.Animals;

namespace ZooA.Animals
{
    public class Turtle : Reptile
    {
        public override string[] FavouriteFood { get; } = { "Grass", "Vegetable" };
        //TODO: Add Food
        public override int RequiredSpaceSqFt { get; } = 5;

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

using System;
using Zoos.Animals;

namespace ZooA.Animals
{
    public class Snake : Reptile
    {
        public override int RequiredSpaceSqFt { get; } = 2;
        //TODO: Add Food Snake
        public override string[] FavouriteFood { get; } = { "Vegetable", "Meat" };

        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            string FriendlyAnimals = "Snake";
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

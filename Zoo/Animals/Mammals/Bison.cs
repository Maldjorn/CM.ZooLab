using System;
using Zoos.Animals;

namespace ZooA.Animals.Mammals
{
    public class Bison : Mammal
    {
        public override int RequiredSpaceSqFt { get; } = 1000;
        //TODO: add food bison
        public override string[] FavouriteFood { get; } = { "Grass", "Vegetable" };

        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            string FriendlyAnimals = "Elephant";
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

using System;
using Zoos.Animals;

namespace ZooA.Animals.Bird
{
    public class Penguin : Bird
    {
        public override int RequiredSpaceSqFt { get; } = 10;
        //TODO Add food animal
        public override string[] FavouriteFood { get; } = { "Grass", "Vegetable" };

        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            string FriendlyAnimals = "Penguin";
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

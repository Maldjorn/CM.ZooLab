using System.Collections.Generic;
using ZooA.Exceptions;
using Zoos.Animals;

namespace Zoos
{
    public class Enclosure
    {
        public string Name { get; private set; }
        public List<Animal> Animals { get; private set; } = new List<Animal>();
        public Zoo ParentZoo { get; private set; }
        public int SquareFeet { get; private set; }


        public Enclosure(string name, int squreFeet, Zoo parentZoo)
        {
            Name = name;
            SquareFeet = squreFeet;
            ParentZoo = parentZoo;
        }
        public void AddAnimals(Animal animal)
        {
            if (this.SquareFeet < animal.RequiredSpaceSqFt)
            {
                throw new NoAvaibleSpaceException();
            }
            if (Animals.Count != 0)
            {
                foreach (var item in Animals)
                {
                    if (!animal.IsFriendlyWithAnimal(item))
                    {
                        throw new NotFriendlyAnimalException();
                    }
                }
            }
            SquareFeet -= animal.RequiredSpaceSqFt;
            this.Animals.Add(animal);
        }

    }
}
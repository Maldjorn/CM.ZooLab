using ZooA.IConsole;
using ZooA.Medicines;
using Zoos.Animals;

namespace Zoos
{
    public class Veterinarian : IEmployee
    {
        IConsole MyConsole = new MyConsole();
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string AnimalExperience { get; set; } = "";
        public Veterinarian(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void AddAnimalExperience(Animal animal)
        {
            AnimalExperience += animal.GetType().Name + ",";
        }
        public bool HasAnimalExperience(Animal animal)
        {
            return AnimalExperience.Contains(animal.GetType().Name);
        }

        public void HealAnimal(Animal animal, Medicine medicine)
        {
            if (animal.IsSick && HasAnimalExperience(animal))
            {
                animal.Heal(medicine);
                MyConsole.WriteLine(animal.GetType().Name + " wa healed by " + this.FirstName);
            }
        }
    }
}

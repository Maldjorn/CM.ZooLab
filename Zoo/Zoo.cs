using System;
using System.Collections.Generic;
using ZooA.Exceptions;
using ZooA.IConsole;
using ZooA.Medicines;
using ZooA.Validator;
using Zoos.Animals;

namespace Zoos
{
    public class Zoo
    {
        public List<IEmployee> Employees { get; private set; } = new List<IEmployee>();
        public List<Enclosure> Enclosures { get; private set; } = new List<Enclosure>();
        public string Location { get; set; }
        public IConsole MyConsole = new MyConsole();

        public Zoo()
        {

        }

        public Zoo(string location)
        {
            Location = location;
        }
        public void AddEnclosure(string name, int squreFeet)
        {
            Enclosures.Add(new Enclosure(name, squreFeet, this));
        }
        public void HireEmployee(IEmployee employee)
        {
            HireValidatorProvider validatorProvider = new HireValidatorProvider();
            List<string> validateErrors = validatorProvider.ValidateEmployee(employee, this);
            if (validateErrors.Count != 0)
            {
                throw new NoNeededExperienceException();
            }
            else
            {
                Employees.Add(employee);
            }
        }
        public Enclosure FindAvaibleEnclosure(Animal animal)
        {
            Enclosure avaibleEnclosure = null;
            foreach (var enclosure in Enclosures)
            {

                    enclosure.AddAnimals(animal);
                    avaibleEnclosure = enclosure;
                    break;

            }
            return avaibleEnclosure;
        }

        public void FeedAnimals(DateTime dateTime)
        {
            List<Animal> animals = GetAnimals();
            int avaibleZookeeperIndex = 0;
            foreach (var animal in animals)
            {
                List<ZooKeeper> zooKeepers = GetZooKeepers();
                foreach (var item in animal.FeedSchedule)
                {
                    if (zooKeepers[avaibleZookeeperIndex].HasAnimalExperience(animal) )
                    {
                        zooKeepers[avaibleZookeeperIndex].FeedAnimal(animal,dateTime);

                        avaibleZookeeperIndex++;
                        if (avaibleZookeeperIndex >= zooKeepers.Count)
                        {
                            avaibleZookeeperIndex = 0;
                        }
                    }

                }
            }
        }
        public void HealAnimals( )
        {
            List<Animal> animals = GetAnimals();
            int avaibleVeterinarianIndex = 0;
            foreach (var animal in animals)
            {
                List<Veterinarian> veterinarians = GetVeterinarians();
                    if (veterinarians[avaibleVeterinarianIndex].HasAnimalExperience(animal))
                    {
                        veterinarians[avaibleVeterinarianIndex].HealAnimal(animal,new Antibiotics());

                        avaibleVeterinarianIndex++;
                        if (avaibleVeterinarianIndex >= veterinarians.Count)
                        {
                            avaibleVeterinarianIndex = 0;
                        }
                    }
            }
        }
        public List<Animal> GetAnimals()
        {
            var animals = new List<Animal>();
            foreach (var enclosure in Enclosures)
            {
                foreach (var animal in enclosure.Animals)
                {
                    animals.Add(animal);
                }
            }
            return animals;
        }

        public List<ZooKeeper> GetZooKeepers()
        {
            var zooKeepers = new List<ZooKeeper>();
            foreach (var employee in Employees)
            {
                if (employee.GetType().Name == "ZooKeeper")
                {
                    zooKeepers.Add((ZooKeeper)employee);
                }
            }
            return zooKeepers;
        }

        public List<Veterinarian> GetVeterinarians()
        {
            var veterinarians = new List<Veterinarian>();
            foreach (var employee in Employees)
            {
                if (employee.GetType().Name == "Veterinarian")
                {
                    veterinarians.Add((Veterinarian)employee);
                }
            }
            return veterinarians;
        }
    }
}

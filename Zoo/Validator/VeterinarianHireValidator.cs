using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZooA.Exceptions;
using Zoos;

namespace ZooA.Validator
{
    public class VeterinarianHireValidator : HireValidator
    {
        public override List<string> ValidateEmployee(IEmployee employee, Zoo zoo)
        {
            var veterinarian = (Veterinarian)employee;
            List<string> animals = new List<string>();
            List<string> errors = new List<string>();
            foreach (var item in zoo.Enclosures)
            {
                for (int i = 0; i < item.Animals.Count; i++)
                {
                    animals.Add(item.Animals[i].GetType().Name);
                }
            }
            List<string> experience = new List<string>();
            experience = animals.Except(veterinarian.AnimalExperience.Split(",")).ToList();
            if (experience.Count() != 0)
            {
                errors.Add("Don't have animal experience");
            }
            return errors;
        }
    }
}

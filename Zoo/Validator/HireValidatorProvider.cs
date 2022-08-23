using System.Collections.Generic;
using Zoos;

namespace ZooA.Validator
{
    class HireValidatorProvider : IHireValidator
    {
        public List<string> ValidateEmployee(IEmployee employee, Zoo zoo)
        {
            var errors = new List<string>();
            if (employee.GetType().Name == "Veterinarian")
            {
                var validator = new VeterinarianHireValidator();
                errors = validator.ValidateEmployee(employee, zoo);
            }
            if (employee.GetType().Name == "ZooKeeper")
            {
                var validator = new ZooKeeperHireValidator();
                errors = validator.ValidateEmployee(employee, zoo);
            }
            return errors;
        }
    }
}

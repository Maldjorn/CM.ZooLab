using System.Collections.Generic;
using Zoos;

namespace ZooA.Validator
{
    public abstract class HireValidator
    {
        public abstract List<string> ValidateEmployee(IEmployee employee, Zoo zoo);
    }
}

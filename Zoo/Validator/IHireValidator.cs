using System.Collections.Generic;
using Zoos;

namespace ZooA.Validator
{
    public interface IHireValidator
    {
        public List<string> ValidateEmployee(IEmployee employee, Zoo zoo);
    }
}
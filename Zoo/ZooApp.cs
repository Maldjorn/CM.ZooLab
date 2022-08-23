using System.Collections.Generic;
using ZooA.IConsole;

namespace Zoos
{
    public class ZooApp
    {
        public List<Zoo> zoos { get; private set; } = new List<Zoo>();
        public IConsole MyConsole { get; set; } = new MyConsole();
        public void AddZoo(Zoo zoo)
        {
            zoos.Add(zoo);
            MyConsole.WriteLine("Zoo was added");
        }
    }
}

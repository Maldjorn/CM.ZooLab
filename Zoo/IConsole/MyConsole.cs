using System;
using System.Collections.Generic;
using System.Text;

namespace ZooA.IConsole
{
    public class MyConsole : IConsole
    {
        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }
    }
}

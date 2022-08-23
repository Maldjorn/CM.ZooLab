using System;
using System.Collections.Generic;
using System.Text;
using ZooA.IConsole;

namespace Zoo.Tests
{
    class ConsoleMock : IConsole
    {
        public List<string> Output = new List<string>(); 
        public void WriteLine(string input)
        {
            Output.Add(input);
        }
    }
}

using MainZoo;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Zoo.Tests
{
    public class ZooMainProgramTest
    {
        [Fact]
        public void ShouldBeAbleToRunZooCorp()
        {
            ConsoleMock console = new ConsoleMock();
            Program program = new Program();
            program.RunZooApp(console);
            List<string> expectedOutput = new List<string>()
            {                       "Zoo was added" ,
                                    "Zoo was added" ,
                                    "Parrot was fed by Zoo1" ,
                                    "Elephant was fed by Zoo2" ,
                                    "Turtle was fed by Zoo1" ,
                                    "Parrot was fed by Zoo1" ,
                                    "Elephant was fed by Zoo2" ,
                                    "Turtle was fed by Zoo1" ,
                                    "Parrot wa healed by New1" ,
                                    "Elephant wa healed by New2" ,
                                    "Turtle wa healed by New1" };
            Assert.Equal(expectedOutput.Count, console.Output.Count);
            
            
        }
    }
}

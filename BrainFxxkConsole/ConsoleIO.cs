using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BrainFxxkInterpreter;
namespace BrainFxxkConsole
{
    class ConsoleIO : IO
    {
        public string Output { get; private set; } = "\n";
        public int Read()
        {
            return Console.ReadKey().KeyChar;
        }

        public void Write(object chr)
        {
            Output += chr.ToString();
        }
        public void Print()
        {
            Console.WriteLine(Output);
        }
    }
}

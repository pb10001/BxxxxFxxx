using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFxxkInterpreter
{
    public class StdIO : IO
    {
        public int Read()
        {
            return Console.Read();
        }
        public void Write(object chr)
        {
            Console.Write(chr);
        }
    }
}

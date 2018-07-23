using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using BrainFxxkInterpreter;

namespace BrainFxxkGUI
{
    public class GraphicIO : IO
    {
        public GraphicIO(string input)
        {
            reader = new StringReader(input);
        }
        StringReader reader;
        public event Action<object> OnWrite = delegate { };

        public int Read()
        {
            return reader.Read();
        }

        public void Write(object chr)
        {
            OnWrite(chr);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFxxkInterpreter
{
    public interface IO
    {
        int Read();
        void Write(object chr);
    }
}

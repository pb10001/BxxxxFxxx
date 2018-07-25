using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using BrainFxxkInterpreter;
namespace BrainFxxkConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                return;
            }
            using (StreamReader sr = new StreamReader(args[0]))
            {
                var b = new Brain(sr.ReadToEnd());
                b.IO = new ConsoleIO();
                try
                {
                    b.Fxxk();
                    ((ConsoleIO)b.IO).Print();
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

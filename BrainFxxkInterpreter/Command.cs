using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFxxkInterpreter
{

    public class Command
    {
        /*シングルトン*/
        private Command()
        {

        }
        protected static Command instance;
        public static Command Instance
        {
            get
            {
                if (instance == null) return Default();
                else return instance;
            }
        }
        public void Set(string s)
        {
            if (s.Length != 8) throw new InvalidOperationException("Invalid number of commands.");
            HashSet<char> table = new HashSet<char>();
            foreach (var chr in s)
            {
                if (!table.Add(chr)) throw new InvalidOperationException("Duplicate command is found.");
            }
            Input = s[0];
            Output = s[1];
            Increment = s[2];
            Decrement = s[3];
            Left = s[4];
            Right = s[5];
            While = s[6];
            EndWhile = s[7];
        }
        public char Left { get; private set; }
        public char Right { get; private set; }
        public char Increment { get; private set; }
        public char Decrement { get; private set; }
        public char Input { get; private set; }
        public char Output { get; private set; }
        public char While { get; private set; }
        public char EndWhile { get; private set; }
        public static Command Default()
        {
            var c = new Command()
            {
                Left = '<',
                Right = '>',
                Increment = '+',
                Decrement = '-',
                Input = ',',
                Output = '.',
                While = '[',
                EndWhile = ']',
            };
            return c;
        }
    }
}

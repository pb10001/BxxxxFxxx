using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFxxkInterpreter
{
    public class Brain
    {
        public Brain(string code)
        {
            Code = code.Replace(" ", "").Replace("\n", "").Replace("\t", "").Replace("\r", "");
        }
        const int MAX_LENGTH = 65535;
        Command cmd = Command.Instance;
        int currentCmd = 0;
        int current = 0;
        IO io = new StdIO();
        public IO IO
        {
            get
            {
                return io;
            }
            set
            {
                io = value;
            }
        }
        public MyByte[] Memory { get; private set; } = Enumerable.Repeat(0, MAX_LENGTH).Select(x => new MyByte(x)).ToArray();
        public string Code { get; private set; }
        public void Fxxk()
        {
            for (; currentCmd < Code.Length; currentCmd++)
            {
                ExecuteCmd(Code[currentCmd]);
            }
        }
        public void ConfigureCommand(string s)
        {
            cmd.Set(s);
        }
        public void ExecuteCmd(char command)
        {
            if (command == cmd.Input)
            {
                Memory[current] = new MyByte(io.Read());
            }
            else if (command == cmd.Output)
            {
                io.Write((char)Memory[current].Value);
            }
            else if (command == cmd.Increment)
            {
                Memory[current]++;
            }
            else if (command == cmd.Decrement)
            {
                Memory[current]--;
            }
            else if (command == cmd.Left)
            {
                current--;
            }
            else if (command == cmd.Right)
            {
                current++;
            }
            else if (command == cmd.While)
            {
                if (Memory[current].Value == 0)
                {
                    var count = 0;
                    while (count <= 0)
                    {
                        currentCmd++;
                        if (Code[currentCmd] == cmd.While) count--;
                        else if (Code[currentCmd] == cmd.EndWhile) count++;
                    }
                }
            }
            else if (command == cmd.EndWhile)
            {
                var count = 0;
                while (count <= 0)
                {
                    currentCmd--;
                    if (Code[currentCmd] == cmd.EndWhile) count--;
                    else if (Code[currentCmd] == cmd.While) count++;
                }
                currentCmd--;
            }
            else
            {
                throw new InvalidOperationException(string.Format("Invalid command is used:{0}", (int)Code[currentCmd]));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFxxkInterpreter
{
    public struct MyByte
    {
        public MyByte(int val)
        {
            Value = val % 256;
        }
        public int Value { get; private set; }
        public static MyByte operator ++(MyByte b)
        {
            if (b.Value == 255) return new MyByte(0);
            else return new MyByte(b.Value + 1);
        }
        public static MyByte operator --(MyByte b)
        {
            if (b.Value == 0) return new MyByte(255);
            else return new MyByte(b.Value - 1);
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}

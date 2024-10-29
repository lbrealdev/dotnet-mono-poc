using System;

namespace ExampleDotNetLib
{
    public class Class1
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public Class1(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public int DoubleValue()
        {
            return Value * 2;
        }

        public bool IsValueGreaterThan(int threshold)
        {
            return Value > threshold;
        }
    }
}

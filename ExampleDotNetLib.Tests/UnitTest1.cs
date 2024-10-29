using NUnit.Framework;
using ExampleDotNetLib;

namespace ExampleDotNetLib.Tests
{
    public class Class1Tests
    {
        [Test]
        public void TestDoubleValue()
        {
            var instance = new Class1("Teste", 5);
            var result = instance.DoubleValue();
            Assert.AreEqual(10, result);
        }
    }
}

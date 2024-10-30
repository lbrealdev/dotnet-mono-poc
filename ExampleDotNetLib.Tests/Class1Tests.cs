using NUnit.Framework;

namespace ExampleDotNetLib.Tests
{
    [TestFixture]
    public class Class1Tests
    {
        private Class1 _instance;

        [SetUp]
        public void SetUp()
        {
            _instance = new Class1("Test", 5);
        }

        [Test]
        public void DoubleValue_ShouldReturnDoubleTheInput_WhenCalled()
        {
            var result = _instance.DoubleValue();
            Assert.AreEqual(10, result);
        }

        [Test]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            Assert.AreEqual("Test", _instance.Name);
            Assert.AreEqual(5, _instance.Value);
        }
    }
}
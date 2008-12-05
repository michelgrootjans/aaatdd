using NUnit.Framework;

namespace TestUtilities
{
    public static class BooleanExtensions
    {
        public static void ShouldBeFalse(this bool item)
        {
            Assert.IsFalse(item);
        }
        public static void ShouldBeTrue(this bool item)
        {
            Assert.IsTrue(item);
        }
    }
}
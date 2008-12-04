using NUnit.Framework;

namespace FindADate.Tests.Utilities
{
    public static class StringExtensions
    {
        public static void ShouldContain(this string value, string expectedValue)
        {
            Assert.IsTrue(value.Contains(expectedValue));
        }

        public static void ShouldNotContain(this string value, string expectedValue)
        {
            Assert.IsFalse(value.Contains(expectedValue));
        }
    }
}
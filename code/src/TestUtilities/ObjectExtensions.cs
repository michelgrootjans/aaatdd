using System;
using NUnit.Framework;

namespace TestUtilities
{
    public static class ObjectExtensions
    {
        public static void ShouldBeSameAs(this object value, object expectedValue)
        {
            Assert.AreSame(expectedValue, value);
        }

        public static void ShouldNotBeSameAs(this object value, object expectedValue)
        {
            Assert.AreNotSame(expectedValue, value);
        }

        public static void ShouldBeEqualTo(this object value, object expectedValue)
        {
            Assert.AreEqual(expectedValue, value);
        }

        public static void ShouldNotBeEqualTo(this object value, object expectedValue)
        {
            Assert.AreNotEqual(expectedValue, value);
        }

        public static void ShouldNotBeNull(this object value)
        {
            Assert.IsNotNull(value);
        }

        public static void ShouldBeInstanceOf<T>(this object value)
        {
            Assert.IsInstanceOfType(typeof (T), value);
        }

        public static void ShouldBeGreaterThan(this int  value, int expectedValue)
        {
            Assert.Greater(value, expectedValue);
        }

        public static void ShouldBeNull(this object value)
        {
            Assert.IsNull(value);
        }

        public static void ShouldBeOfType(this object value, Type type)
        {
            Assert.AreEqual(type, value.GetType());
        }
    }
}
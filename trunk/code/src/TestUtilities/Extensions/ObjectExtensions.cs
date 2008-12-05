using System;
using NUnit.Framework;
using Rhino.Mocks;

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

        public static T GetArgument<T, Subject>(this object subject, Action<Subject> action) 
            where Subject : class where T : class
        {
            return GetArgument<T, Subject>(subject, action, 1);
        
        }
        public static T GetArgument<T, Subject>(this object subject, Action<Subject> action, int parameterIndex) 
            where T : class where Subject : class
        {
            var typedSubject = subject as Subject;
            var arguments = typedSubject.GetArgumentsForCallsMadeOn<Subject>(action, constraint => constraint.IgnoreArguments());
            arguments.Count.ShouldBeEqualTo(1);
            arguments[0].Length.ShouldBeEqualTo(parameterIndex);
            arguments[0][0].ShouldBeInstanceOf<T>();

            return arguments[0][0] as T;
        }
    }
}
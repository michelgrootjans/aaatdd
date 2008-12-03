using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace BDD
{
    public static class The
    {
        public static Action action(Action action) {
            return action;
        }
    }

    public static class RhinoMocksExtensions
    {
        public static void was_told_to<T>(this T mock, Action<T> item) {
            mock.AssertWasCalled(item);
        }

        public static IMethodOptions<R> when_told_to<T, R>(this T mock, Func<T, R> func) {
            return mock.Stub(func).Repeat.Any();
        }

        public static IMethodOptions<R> setup_result<T, R>(this T mock, Func<T, R> func) {
            return mock.Stub(func).Repeat.Any();
        }
    }

    public static class BDDExtensions
    {
        public static void force_traversal<T>(this IEnumerable<T> items) {
            items.Count();
        }

        public static void should_be_null(this object item) {
            Assert.IsNull(item);
        }

        public static void should_be_equal_to(this object item, object other) {
            Assert.AreEqual(other, item);
        }

        public static void should_contain<T>(this IEnumerable<T> items, T item) {
            Assert.IsTrue(new List<T>(items).Contains(item));
        }

        public static void should_be_greater_than<T>(this T item, T other) where T : IComparable<T> {
            (item.CompareTo(other) > 0).should_be_true();
        }

        public static void should_not_be_equal_to<T>(this T item, T other) {
            Assert.AreNotEqual(other, item);
        }

        public static void should_be_equal_ignoring_case(this string item, string other) {
            StringAssert.AreEqualIgnoringCase(item, other);
        }

        public static void should_only_contain<T>(this IEnumerable<T> items, params T[] itemsToFind) {
            var results = new List<T>(items);
            itemsToFind.Length.should_be_equal_to(items.Count());
            foreach (var itemToFind in itemsToFind) {
                results.Contains(itemToFind).should_be_true();
            }
        }

        public static void should_only_contain_in_order<T>(this IEnumerable<T> items, params T[] itemsToFind) {
            var results = new List<T>(items);
            itemsToFind.Length.should_be_equal_to(items.Count());
            for (var i = 0; i < itemsToFind.Count(); i++) {
                itemsToFind[i].should_be_equal_to(results[i]);
            }
        }

        public static void should_be_true(this bool item) {
            item.should_be_equal_to(true);
        }

        public static void should_be_false(this bool item) {
            item.should_be_equal_to(false);
        }

        public static void should_be_equal_to<T>(this T actual, T expected) {
            Assert.AreEqual(expected, actual);
        }

        public static ExceptionType should_throw_an<ExceptionType>(this Action workToPerform)
            where ExceptionType : Exception {
            var resulting_exception = get_exception_from_performing(workToPerform);
            resulting_exception.should_not_be_null();
            resulting_exception.should_be_an_instance_of<ExceptionType>();
            return (ExceptionType)resulting_exception;
        }

        public static void should_not_throw_any_exceptions(this Action workToPerform) {
            workToPerform();
        }

        public static void should_be_an_instance_of<Type>(this object item) {
            Assert.IsInstanceOfType(typeof(Type), item);
        }

        public static void should_not_be_null(this object item) {
            Assert.IsNotNull(item);
        }

        private static Exception get_exception_from_performing(Action work) {
            try {
                work();
                return null;
            }
            catch (Exception e) {
                return e;
            }
        }
    }
}
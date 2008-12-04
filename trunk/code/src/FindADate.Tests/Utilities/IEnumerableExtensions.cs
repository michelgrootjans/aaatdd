using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace FindADate.Tests.Utilities
{
    public static class IEnumerableExtensions
    {
        public static void ShouldContain<T>(this IEnumerable<T> list, T value)
        {
            var itemHasBeenFound = false;
            foreach (var t in list)
            {
                if (t.Equals(value)) itemHasBeenFound = true;
            }
            Assert.IsTrue(itemHasBeenFound, string.Format("{0} has not been found in the list", value));
        }

        public static void ShouldContain<T>(this IEnumerable<T> list, Predicate<T> predicate)
        {
            var listOfT = new List<T>(list);
            Assert.IsNotNull(listOfT.Find(predicate), string.Format("The list doesn't contain any matches"));
        }
    }
}
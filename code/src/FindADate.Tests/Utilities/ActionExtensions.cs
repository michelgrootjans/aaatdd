using System;

namespace FindADate.Tests.Utilities
{
    public static class ActionExtensions
    {
        public static T ShouldThrow<T>(this Action action) where T : Exception
        {
            try
            {
                action.Invoke();
            }
            catch (T t)
            {
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Expected exception: {0}, Actual exception: {1}", typeof(T).Name, ex));    
            }

            throw new Exception(string.Format("Expected exception: {0}, Actual exception: none", typeof(T).Name));
        }

        public static void ExecuteAndIgnoreExceptions(this Action action)
        {
            try
            {
                action.Invoke();
            }
            catch{}
        }
    }
}
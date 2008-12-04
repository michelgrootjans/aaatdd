using System;

namespace Utilities.Containers
{
    /// <summary>
    /// Arta exception
    /// </summary>
    public class UnsatisfiedDependencyException : Exception
    {
        public UnsatisfiedDependencyException()
        {
        }

        public UnsatisfiedDependencyException(string message) : base(message)
        {
        }

        public UnsatisfiedDependencyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
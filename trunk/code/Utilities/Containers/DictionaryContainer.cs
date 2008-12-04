using System;
using System.Collections.Generic;

namespace Utilities.Containers
{
    /// <summary>
    /// </summary>
    public class DictionaryContainer : IContainer
    {
        private readonly Dictionary<Type, object> _types = new Dictionary<Type, object>();

        /// <summary>
        /// Registers the specified implementation for a type.
        /// </summary>
        /// <typeparam name="T">Type to register an implementation for.</typeparam>
        /// <param name="implementationToRegister">The implementation to register.</param>
        public void Register<T>(T implementationToRegister)
        {
            _types.Add(typeof (T), implementationToRegister);
        }

        /// <summary>
        /// Gets the implementation of a type.
        /// </summary>
        /// <typeparam name="T">Type to retrieve</typeparam>
        /// <returns>Implementation of a type</returns>
        public T GetImplementationOf<T>()
        {
            return (T) _types[typeof (T)];
        }
    }
}
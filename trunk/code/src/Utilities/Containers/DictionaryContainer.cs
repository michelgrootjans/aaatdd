using System;
using System.Collections.Generic;

namespace Utilities.Containers
{
    public class DictionaryContainer : IContainer
    {
        private readonly Dictionary<Type, object> registrations = new Dictionary<Type, object>();

        public void Register<T>(T implementationToRegister)
        {
            registrations.Add(typeof (T), implementationToRegister);
        }

        public T GetImplementationOf<T>()
        {
            if (registrations.ContainsKey(typeof(T)))
                return (T) registrations[typeof (T)];

            return (T) GetInferredImplementationOf<T>();
        }

        private object GetInferredImplementationOf<T>()
        {
            foreach (var implementation in registrations.Values)
            {
                if (!(implementation is T)) continue;
                
                Register((T) implementation); // caches the result of this method
                return implementation;
            }
            return null;
        }
    }
}
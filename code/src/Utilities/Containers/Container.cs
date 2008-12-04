using System;

namespace Utilities.Containers
{
    public static class Container
    {
        private static IContainer _container;

        public static void Initialize(IContainer container)
        {
            _container = container;
        }

        public static void Register<T>(T implementationToRegister)
        {
            if (_container == null)
            {
                throw new InvalidOperationException("The container is not initialized");
            }
            _container.Register(implementationToRegister);
        }

        public static T GetImplementationOf<T>() where T : class
        {
            return _container.GetImplementationOf<T>();
        }
    }
}
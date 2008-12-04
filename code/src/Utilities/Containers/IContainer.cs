namespace Utilities.Containers
{
    public interface IContainer
    {
        void Register<T>(T implementation);
        T GetImplementationOf<T>();
    }
}
namespace Utilities
{
    public interface IMapper<From, To>
    {
        To Map(From from);
    }
}
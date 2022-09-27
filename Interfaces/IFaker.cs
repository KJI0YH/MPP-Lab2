namespace Core.Interfaces
{
    public interface IFaker
    {
        T Create<T>();
    }
}

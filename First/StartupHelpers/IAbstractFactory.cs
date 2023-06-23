namespace First.StartupHelpers
{
    public interface IAbstractFactory<T>
    {
        T Create();
    }
}
namespace AirOpsTest.Interfaces
{
    public interface IWriteRepository<T> where T : class
    {
        void Insert(T obj);
    }
}
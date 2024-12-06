namespace ThalesAssesment.Business.Repositories.Interfaces
{
    public interface IRepository<T, TId>
    {
        ValueTask<T[]> GetAllAsync();
    }
}

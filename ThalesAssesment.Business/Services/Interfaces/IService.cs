namespace ThalesAssesment.Business.Services.Interfaces
{
    public interface IService<T, TId>
    {
        ValueTask<T[]> GetAllAsync();
    }
}

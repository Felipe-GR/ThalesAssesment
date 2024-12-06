using ThalesAssesment.Model.Entities;
namespace ThalesAssesment.Business.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee, int>
    {
        ValueTask<Employee> GetByIdAsync(int id);
    }
}

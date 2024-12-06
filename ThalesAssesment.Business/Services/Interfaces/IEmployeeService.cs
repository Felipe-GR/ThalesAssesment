using ThalesAssesment.Business.Dtos;

namespace ThalesAssesment.Business.Services.Interfaces
{
    public interface IEmployeeService : IService<EmployeeDto, int>
    {
        ValueTask<EmployeeDto> GetByIdAsync(int id);

        ValueTask<EmployeeDto[]> GetListByNameAsync(string name);
    }
}

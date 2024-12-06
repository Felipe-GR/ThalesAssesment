using Moq;
using AutoMapper;
using ThalesAssesment.Business.Dtos;
using ThalesAssesment.Business.Services;
using ThalesAssesment.Business.Repositories.Interfaces;
using ThalesAssesment.Model.Entities;

namespace ThalesAssesment.Test
{
    [TestClass]
    public class EmployeeServiceTests
    {
        private Mock<IEmployeeRepository>? _mockRepository;
        private Mock<IMapper>? _mockMapper;
        private EmployeeService? _employeeService;

        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new Mock<IEmployeeRepository>();
            _mockMapper = new Mock<IMapper>();
            _employeeService = new EmployeeService(_mockRepository.Object, _mockMapper.Object);
        }

        [TestMethod]
        public async Task GetAllAsync_ReturnsMappedEmployeeDtos()
        {
            // Arrange
            var employees = new[] { new Employee() };
            var employeeDtos = new[] { new EmployeeDto() };

            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(employees);
            _mockMapper.Setup(m => m.Map<EmployeeDto[]>(employees)).Returns(employeeDtos);

            // Act
            var result = await _employeeService.GetAllAsync();

            // Assert
            Assert.AreEqual(employeeDtos, result);
        }

        [TestMethod]
        public async Task GetByIdAsync_ReturnsMappedEmployeeDto()
        {
            // Arrange
            var employee = new Employee();
            var employeeDto = new EmployeeDto();

            _mockRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(employee);
            _mockMapper.Setup(m => m.Map<EmployeeDto>(employee)).Returns(employeeDto);

            // Act
            var result = await _employeeService.GetByIdAsync(1);

            // Assert
            Assert.AreEqual(employeeDto, result);
        }

        [TestMethod]
        public async Task GetListByNameAsync_ReturnsFilteredAndMappedEmployeeDtos()
        {
            // Arrange
            var employees = new[]
            {
                new Employee { EmployeeName = "Tiger Nixon" },
                new Employee { EmployeeName = "Garrett Winters" }
            };

            var employeeDtos = new[]
            {
                new EmployeeDto { Name = "Tiger Nixon" }
            };

            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(employees);
            _mockMapper.Setup(m => m.Map<EmployeeDto[]>(It.Is<Employee[]>(e => e.Length == 1 && e[0].EmployeeName == "Tiger Nixon"))).Returns(employeeDtos);

            // Act
            var result = await _employeeService.GetListByNameAsync("Or");

            // Assert
            Assert.AreEqual(employeeDtos, result);
        }

        [TestMethod]
        public async Task GetListByNameAsync_ReturnsEmptyArrayWhenNoMatches()
        {
            // Arrange
            var employees = new[]
            {
                new Employee { EmployeeName = "Tiger Nixon" },
                new Employee { EmployeeName = "Garrett Winters" }
            };

            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(employees);

            // Act
            var result = await _employeeService.GetListByNameAsync("Tiger");

            // Assert
            Assert.AreEqual(0, result.Length);
        }
    }
}
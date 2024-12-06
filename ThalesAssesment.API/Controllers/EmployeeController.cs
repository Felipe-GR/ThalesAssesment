using Microsoft.AspNetCore.Mvc;
using ThalesAssesment.Business.Dtos;
using ThalesAssesment.Business.Services.Interfaces;

namespace ThalesAssesment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeService service) : ControllerBase
    {
        private readonly IEmployeeService _service = service;

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult<EmployeeDto[]>> GetAsync()
        {
            var result = await _service.GetAllAsync();

            if (result.Length <= 0)
            {
                return NoContent();
            }

            return Ok(result);
        }

        // GET: api/<EmployeeController>/name/name
        [HttpGet("name/{name}")]
        public async Task<ActionResult<EmployeeDto[]>> GetAsync(string name)
        {
            ActionResult<EmployeeDto[]> result = NoContent();

            if (!string.IsNullOrEmpty(name))
            {
                var serviceResult = await _service.GetListByNameAsync(name);

                if (serviceResult != null && serviceResult.Length > 0)
                {
                    result = Ok(serviceResult);
                }
                else
                {
                    result = NotFound();
                }
            }

            return result;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetAsync(int id)
        {
            ActionResult<EmployeeDto> result = NoContent();

            if (id != 0)
            {
                var serviceResult = await _service.GetByIdAsync(id);

                if (serviceResult != null)
                {
                    result = Ok(serviceResult);
                }
                else
                {
                    result = NotFound();
                }
            }

            return result;
        }
    }
}

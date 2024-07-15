using Microsoft.AspNetCore.Mvc;
using RestaurantOrdersManager.Core.ServiceContracts;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO;
using RestaurantOrdersManager.Core.Services;
using System.ComponentModel.DataAnnotations;


namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("addEmployee")]
        public async Task<IActionResult> AddEmployee(EmployeeAddRequest addEmployeeRequest)
        {
            try
            {
                EmployeeResponse addEmployee = await _employeeService.AddEmployee(addEmployeeRequest);
                return Ok(new EmployeeResponse { EmployeeId = addEmployee.EmployeeId, Name = addEmployee.Name, LastName = addEmployeeRequest.LastName});
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { Message = ex.Message });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet("getAllEmpolyees")]
        public async Task<IActionResult> getAllEmployess()
        {
            try
            {
                IEnumerable<EmployeeResponse> allEmployess = await _employeeService.GetAllEmployee();
                return Ok(allEmployess);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
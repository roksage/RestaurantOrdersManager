using Microsoft.AspNetCore.Mvc;
using RestaurantOrdersManager.Core.Enums;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.TableDTO;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;

namespace RestaurantOrdersManager.WebAPI.Controllers.RestaurantOrdersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpPost("CreateTable")]
        public async Task<IActionResult> CreateTable(TableCreateRequest createTableRequest)
        {
            try
            {
                TableResponse createTable = await _tableService.CreateTable(createTableRequest);
                return Ok(new TableResponse
                {
                    TableId = createTable.TableId,
                    TableName = createTable.TableName,
                    Seats = createTable.Seats,
                    Status = createTable.Status,
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = "Table name already exists" });
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }

        }



        [HttpDelete("DeleteTable")]
        public async Task<IActionResult> DeleteTable(TableDeleteRequest deleteRequest)
        {
            try
            {
                bool deleteTable = await _tableService.DeleteTable(deleteRequest);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { Message = "Table doesn't exist" });
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }

        }


        [HttpGet("GetAllTablesFreeOccupied")]
        public async Task<IActionResult> GetAllTablesFreeOccupied(TableStatusEnums status)
        {
            try
            {
                IEnumerable<TableResponse> getTables = await _tableService.GetAllTablesFreeOccupied(status);
                return Ok(getTables);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { ex.Message });
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }

        }


        [HttpGet("GetTableById/{tableId}")]
        public async Task<IActionResult> GetTableById(int tableId)
        {
            try
            {
                TableResponse getTable = await _tableService.GetTableById(tableId);
                return Ok(new TableResponse
                {
                    TableId = getTable.TableId,
                    TableName = getTable.TableName,
                    Seats = getTable.Seats,
                    Status = getTable.Status,
                });
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { Message = "Table doesn't exist" });
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }




        [HttpPut("UpdateTable")]
        public async Task<IActionResult> UpdateTable(TableUpdateRequest UpdateRequest)
        {
            try
            {
                TableResponse updateTable = await _tableService.UpdateTable(UpdateRequest);
                return Ok(new TableResponse
                {
                    TableId = updateTable.TableId,
                    TableName = updateTable.TableName,
                    Seats = updateTable.Seats,
                    Status = updateTable.Status,
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }


    }
}


using RestaurantOrdersManager.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace RestaurantOrdersManager.Core.ServiceContracts.DTO.TableDTO
{
    public class TableCreateRequest
    {
        [Required]
        public required string TableName { get; set; }
        [Required]
        public required int Seats {  get; set; }

        public Table ToTable()
        {
            return new Table { TableName = TableName , Seats = Seats};
        } 
    }
}

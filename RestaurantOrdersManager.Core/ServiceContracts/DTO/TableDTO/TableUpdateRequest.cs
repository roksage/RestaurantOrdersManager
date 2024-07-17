using RestaurantOrdersManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.DTO.TableDTO
{
    public class TableUpdateRequest
    {
        public int TableId { get; set; }
        public  string? TableName { get; set; }
        public  int? Seats { get; set; }

        public Table ToTable()
        {
            return new Table { TableId = TableId, TableName = TableName, Seats = (int)Seats };
        }
    }
}

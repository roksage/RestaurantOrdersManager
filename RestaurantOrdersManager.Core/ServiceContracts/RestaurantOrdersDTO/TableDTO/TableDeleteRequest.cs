using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.DTO.TableDTO
{
    public class TableDeleteRequest
    {
        public int TableId { get; set; }
        public Table ToTable()
        {
            return new Table { TableId = TableId };
        }
    }
}

using RestaurantOrdersManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.DTO.TableDTO
{
    public class TableResponse
    {
        public int TableId { get; set; }
        public string TableName { get; set; }
        public int Seats { get; set; }
        public Enums.TableStatusEnums Status { get; set; }

    }

    public static class TableResponseExtension
    {
        public static TableResponse ToTableResponse(this Table request)
        {
            return new TableResponse
            {
                TableId = request.TableId,
                TableName = request.TableName,
                Status = request.Status,
                Seats = request.Seats,
            };
        }

        public static Table ToTable(this TableResponse request)
        {
            return new Table
            {
                TableId = request.TableId,
                TableName = request.TableName,
                Status = request.Status,
                Seats = request.Seats,
            };
        }
    }
}

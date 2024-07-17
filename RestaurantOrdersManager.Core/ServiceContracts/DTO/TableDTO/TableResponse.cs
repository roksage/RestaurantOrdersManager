﻿using RestaurantOrdersManager.Core.Entities;
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

        public Enums.TableStatus Status { get; set; }

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
            };
        }
    }
}

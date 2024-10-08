﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantOrdersManager.Core.Enums;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.TableDTO;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;
using RestaurantOrdersManager.Infrastructure;
using Table = RestaurantOrdersManager.Core.Entities.RestaurantOrders.Table;

namespace RestaurantOrdersManager.Core.Services.RestaurantOrdersServices
{
    public class TableService : ITableService
    {
        private readonly RestaurantOrdersDbContext _dbContext;

        public TableService(RestaurantOrdersDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TableResponse> CreateTable(TableCreateRequest createTableRequest)
        {
            if (createTableRequest == null)
            {
                throw new ArgumentNullException(nameof(createTableRequest));
            }

            bool tableNameExists = await _dbContext.Tables.AnyAsync(t => t.TableName == createTableRequest.TableName);

            if (tableNameExists)
            {
                throw new ArgumentException(nameof(createTableRequest));
            }

            Table newTable = createTableRequest.ToTable();

            await _dbContext.AddAsync(newTable);

            await _dbContext.SaveChangesAsync();



            return newTable.ToTableResponse();

        }

        public async Task<bool> DeleteTable(TableDeleteRequest deleteRequest)
        {
            if (deleteRequest == null)
            {
                throw new ArgumentNullException(nameof(deleteRequest));
            }
            Table? findTable = await _dbContext.Tables.FirstOrDefaultAsync(t => t.TableId == deleteRequest.TableId);

            if (findTable == null)
            {
                throw new ArgumentException($"Table not found with id {deleteRequest.TableId}");
            }

            _dbContext.Attach(findTable);
            _dbContext.Remove(findTable);
            await _dbContext.SaveChangesAsync();

            return true;

        }

        public async Task<IEnumerable<TableResponse>> GetAllTables()
        {
            return _dbContext.Tables.Select(t => t.ToTableResponse());
        }

        public async Task<IEnumerable<TableResponse>> GetAllTablesFreeOccupied(TableStatusEnums status)
        {
            if (!Enum.IsDefined(typeof(TableStatusEnums), status))
            {
                throw new ArgumentException($"Invalid value for {nameof(status)}", nameof(status));
            }

            // Get all tables by status
            var tables = await _dbContext.Tables
                .Where(t => t.Status == status)
                .Select(t => t.ToTableResponse())
                .ToListAsync();

            return tables;
        }

        public async Task<TableResponse> GetTableById(int TableId)
        {

            Table? tableInfo = await _dbContext.Tables.FirstOrDefaultAsync(t => t.TableId == TableId);

            if (tableInfo == null)
            {
                throw new ArgumentException(nameof(TableId));
            }


            return tableInfo.ToTableResponse();
        }



        public async Task<TableResponse> UpdateTable(TableUpdateRequest UpdateRequest)
        {
            Table table = await _dbContext.Tables.FirstOrDefaultAsync(t => t.TableId == UpdateRequest.TableId);

            if (table == null)
            {
                throw new ArgumentException($"Table id - {UpdateRequest.TableId} not found");
            }

            bool tableNameExists = await _dbContext.Tables.AnyAsync(t => t.TableName == UpdateRequest.TableName);

            if (tableNameExists)
            {
                throw new ArgumentException($"Table name '{UpdateRequest.TableName}' already exists");
            }


            //possible that TableResponse convert to Table

            if (UpdateRequest.TableName != null)
            {
                table.TableName = UpdateRequest.TableName;
            }
            if (UpdateRequest.Seats != null)
            {
                table.Seats = (int)UpdateRequest.Seats;
            }


            await _dbContext.SaveChangesAsync();

            return table.ToTableResponse();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RestaurantOrdersManager.Core.Entities;
using RestaurantOrdersManager.Core.Enums;
using RestaurantOrdersManager.Core.ServiceContracts;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.TableDTO;
using RestaurantOrdersManager.Infrastructure;

namespace RestaurantOrdersManager.Core.Services
{
    public class TableService : ITableService
    {
        private readonly ManagerDbContext _dbContext;

        public TableService(ManagerDbContext dbContext)
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

            await _dbContext.AddAsync(createTableRequest);

            await _dbContext.SaveChangesAsync();

            Table table = createTableRequest.ToTable();

            return table.ToTableResponse();

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
                throw new ArgumentException(nameof(findTable));
            }

            _dbContext.Attach(findTable);
            _dbContext.Remove(findTable);
            await _dbContext.SaveChangesAsync();

            return true;

        }

        public Task<IEnumerable<TableResponse>> GetAllTables()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TableResponse>> GetAllTablesFreeOccupied(TableStatus status)
        {
            if (!Enum.IsDefined(typeof(TableStatus), status))
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
            if (TableId == null)
            {
                throw new ArgumentNullException(nameof(TableId));
            }

            Table? tableInfo = await _dbContext.Tables.FirstOrDefaultAsync(t => t.TableId == TableId);

            if (tableInfo == null)
            {
                throw new ArgumentException(nameof(TableId));
            }


            return tableInfo.ToTableResponse();
        }



        public async Task<TableResponse> UpdateTable(TableUpdateRequest UpdateRequest)
        {
            TableResponse tableToUpdate = await GetTableById(UpdateRequest.TableId);

            //possible that TableResponse convert to Table

            if (UpdateRequest.TableName != null)
            {
                tableToUpdate.TableName = tableToUpdate.TableName;
                
            }
            if (UpdateRequest.Seats != null)
            {
                tableToUpdate.Seats = (int)UpdateRequest.Seats;
            }

            await _dbContext.SaveChangesAsync();

            return tableToUpdate;
        }
    }
}

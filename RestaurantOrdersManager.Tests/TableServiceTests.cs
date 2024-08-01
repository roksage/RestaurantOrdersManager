using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.TableDTO;
using RestaurantOrdersManager.Core.Services.RestaurantOrdersServices;
using RestaurantOrdersManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Tests
{
    public class TableServiceTests
    {
        private async Task<RestaurantOrdersDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<RestaurantOrdersDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new RestaurantOrdersDbContext(options);
            await databaseContext.Database.EnsureCreatedAsync();
            await databaseContext.Database.EnsureDeletedAsync();

            var table = new Table { TableId = 1, TableName = "Table 1", Seats = 2, Status = Core.Enums.TableStatusEnums.Free };
            databaseContext.Add(table);
            await databaseContext.SaveChangesAsync();

            return databaseContext;
        }

        [Fact]
        public async Task TableService_CreateTable_TableResponse()
        {
            var dbContext = await GetDbContext();

            TableService tableService = new TableService(dbContext);

            TableCreateRequest table = new TableCreateRequest { Seats = 20, TableName = "B1" };

            TableResponse act = await tableService.CreateTable(table);

            TableResponse findTable = await tableService.GetTableById(act.TableId);

            act.Should().BeEquivalentTo(findTable);

        }


        [Fact]
        public async Task TableService_CreateTable_ArgumentNUllException()
        {
            var dbContext = await GetDbContext();

            TableService tableService = new TableService(dbContext);

            TableCreateRequest table = null;

            Func<Task> act = async () => await tableService.CreateTable(table);


            await act.Should().ThrowAsync<ArgumentNullException>();
        }


        [Fact]
        public async Task TableService_CreateTable_ArgumentException()
        {
            var dbContext = await GetDbContext();

            TableService tableService = new TableService(dbContext);

            TableCreateRequest table = new TableCreateRequest { Seats = 20, TableName = "Table 1" };

            Func<Task> act = async () => await tableService.CreateTable(table);

            await act.Should().ThrowAsync<ArgumentException>();
        }


        [Fact]
        public async Task TableService_DeleteTable_bool()
        {
            var dbContext = await GetDbContext();

            TableService tableService = new TableService(dbContext);

            TableDeleteRequest table = new TableDeleteRequest { TableId = 1 };

            bool act = await tableService.DeleteTable(table);

            act.Should().BeTrue();
        }


        [Fact]
        public async Task TableService_DeleteTable_ArgumentNullException()
        {
            var dbContext = await GetDbContext();

            TableService tableService = new TableService(dbContext);

            TableDeleteRequest table = null;

            Func<Task> act = async () => await tableService.DeleteTable(table);

            await act.Should().ThrowAsync<ArgumentNullException>();
        }


        [Fact]
        public async Task TableService_DeleteTable_ArgumentException()
        {
            var dbContext = await GetDbContext();

            TableService tableService = new TableService(dbContext);

            TableDeleteRequest table = new TableDeleteRequest { TableId = 2 };

            Func<Task> act = async () => await tableService.DeleteTable(table);

            await act.Should().ThrowAsync<ArgumentException>().WithMessage($"Table not found with id {table.TableId}");
        }


        [Fact]
        public async Task TableService_GetAllTablesFreeOccupied_ListTableResponse()
        {
            var dbContext = await GetDbContext();

            TableService tableService = new TableService(dbContext);

            IEnumerable<TableResponse> act_Occupied = await tableService.GetAllTablesFreeOccupied(Core.Enums.TableStatusEnums.Occupied);
            IEnumerable<TableResponse> act_Free = await tableService.GetAllTablesFreeOccupied(Core.Enums.TableStatusEnums.Free);
            IEnumerable<TableResponse> act_Reserved = await tableService.GetAllTablesFreeOccupied(Core.Enums.TableStatusEnums.Reserved);


            act_Occupied.Should().HaveCount(0);
            act_Free.Should().HaveCount(1);
            act_Reserved.Should().HaveCount(0);
        }


        [Fact]
        public async Task TableService_GetTableById_TableResponse()
        {
            var dbContext = await GetDbContext();

            TableService tableService = new TableService(dbContext);

            TableResponse act = await tableService.GetTableById(1);
            act.Should().NotBeNull();

        }

        [Fact]
        public async Task TableService_GetTableById_ArgumentException()
        {
            var dbContext = await GetDbContext();

            TableService tableService = new TableService(dbContext);

            Func<Task> act = async () => await tableService.GetTableById(2);
            await act.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task TableService_UpdateTable_TableResponse()
        {
            var dbContext = await GetDbContext();

            TableService tableService = new TableService(dbContext);

            TableUpdateRequest table = new TableUpdateRequest { TableId = 1, Seats = 20, TableName = "Updated" };

            TableResponse act = await tableService.UpdateTable(table);
            act.Should().BeEquivalentTo(table.ToTable().ToTableResponse());
        }


        [Fact]
        public async Task TableService_UpdateTable_ArgumentExceptionTableDoesntExists()
        {
            var dbContext = await GetDbContext();

            TableService tableService = new TableService(dbContext);

            TableUpdateRequest table = new TableUpdateRequest { TableId = 2 };

            Func<Task> act = async () => await tableService.UpdateTable(table);
            await act.Should().ThrowAsync<ArgumentException>().WithMessage($"Table id - {table.TableId} not found");
        }

        [Fact]
        public async Task TableService_UpdateTable_ArgumentExceptionNameAlreadyExists()
        {
            var dbContext = await GetDbContext();

            TableService tableService = new TableService(dbContext);

            TableUpdateRequest table = new TableUpdateRequest { TableId = 1, TableName = "Table 1" };

            Func<Task> act = async () => await tableService.UpdateTable(table);
            await act.Should().ThrowAsync<ArgumentException>().WithMessage($"Table name '{table.TableName}' already exists");
        }


    }
}

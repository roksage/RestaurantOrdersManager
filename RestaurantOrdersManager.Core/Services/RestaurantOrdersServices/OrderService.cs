﻿using Microsoft.EntityFrameworkCore;
using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;
using RestaurantOrdersManager.Infrastructure;

namespace RestaurantOrdersManager.Core.Services.RestaurantOrdersServices
{
    public class OrderService : IOrderService
    {
        private readonly RestaurantOrdersDbContext _dbContext;
        private readonly IEmployeeService _employeeService;
        private readonly ITableService _tableService;

        public OrderService(RestaurantOrdersDbContext dbContext, IEmployeeService employeeService, ITableService tableService)
        {
            _dbContext = dbContext;
            _employeeService = employeeService;
            _tableService = tableService;
        }

        public async Task<OrderResponse> createOrder(OrderCreateRequest AddRequest)
        {
            if (AddRequest == null)
            {
                throw new ArgumentNullException(nameof(AddRequest));
            }

            //check if employee exists
            if (await _employeeService.GetEmployeeById(AddRequest.CreatedBy) == null)
            {
                throw new InvalidOperationException($"Employee with id {AddRequest.CreatedBy} not found.");
            }

            //check if table is free
            if ((await _tableService.GetTableById(AddRequest.TableId)).Status != Enums.TableStatusEnums.Free)
            {
                throw new InvalidOperationException($"Table with id {AddRequest.CreatedBy} not found.");
            }

            Order order = AddRequest.ToOrder();
            _dbContext.Add(order);
            await _dbContext.SaveChangesAsync();
            return order.ToOrderResponse();
        }

        public async Task<IEnumerable<MenuItemToOrderResponse>> GetAllMenuItemsInOrder(int? OrderId)
        {
            if (OrderId == null)
            {
                throw new ArgumentNullException(nameof(OrderId));
            }

            Order? order = await _dbContext.Orders.Include(o => o.OrderMenuItems)
                                         .ThenInclude(omi => omi.MenuItem)
                                         .FirstOrDefaultAsync(o => o.OrderId == OrderId);

            if (order == null)
            {
                throw new Exception($"Order with id {OrderId} not found.");
            }

            return order.OrderMenuItems.ToOrderedMenuItemResponse();
        }


        public async Task<IEnumerable<OrderResponse>> GetAllOrders()
        {
            return await _dbContext.Orders
                .Include(o => o.OrderMenuItems)
                .ThenInclude(omi => omi.MenuItem)
                .Select(order => order.ToOrderResponse())
                .ToListAsync();
        }



        public async Task<bool> CheckIfOrderIsCompleted(int OrderId)
        {
            IEnumerable<MenuItemToOrderResponse> getAllItemsInOrder = await GetAllMenuItemsInOrder(OrderId);

            foreach (var item in getAllItemsInOrder)
            {
                if (item.ProcessCompleted == null)
                {
                    return false;
                }
            }

            Order order = await _dbContext.Orders.FirstOrDefaultAsync(o => o.OrderId == OrderId);

            if (order == null)
            {
                return false;
            }

            //set finish time UTC.now it means that order is finished

            order.TimeFinished = DateTime.UtcNow;

            order.Table.Status = Enums.TableStatusEnums.Free;
            //

            order.TableId = null;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<OrderResponse>> GetAllActiveOrders()
        {
            return await _dbContext.Orders
                .Include(o => o.OrderMenuItems)
                .ThenInclude(omi => omi.MenuItem)
                .Where(of => of.TimeFinished == null)
                .Select(order => order.ToOrderResponse())
                .ToListAsync();
        }

        public async Task<IEnumerable<OrderProgress>> GetAllActiveOrdersWithCompletionStatus()
        {
            var ordersWithCompletionPercentage = new List<OrderProgress>();

            var allNotFinishedOrders = await _dbContext.Orders
                .Include(o => o.OrderMenuItems)
                .ThenInclude(omi => omi.MenuItem)
                .Where(of => of.TimeFinished == null)
                .Select(order => order.ToOrderResponse())
                .ToListAsync();


            foreach (var order in allNotFinishedOrders)
            {
                int countFinishedItems = order.OrderMenuItems.Where(o => o.ProcessCompleted != null).Count();

                int countNotFinishedItems = order.OrderMenuItems.Where(o => o.ProcessCompleted == null).Count();

                if (countFinishedItems != 0)
                {
                    ordersWithCompletionPercentage.Add(new OrderProgress { OrderId = order.OrderId, ProgressPercentage = Math.Round(((decimal)countFinishedItems / (decimal)countNotFinishedItems) * 100, 0) });
                    await Console.Out.WriteLineAsync($"{countFinishedItems} / {countNotFinishedItems} = {Math.Round(((decimal)countFinishedItems / (decimal)countNotFinishedItems) * 100, 0)} ");
                }
                else
                {
                    ordersWithCompletionPercentage.Add(new OrderProgress { OrderId = order.OrderId, ProgressPercentage = 0 });
                }
            };

            return ordersWithCompletionPercentage;
        }



        public async Task<OrderResponse> GetOrderByOrderId(int OrderId)
        {
            Order? order = await _dbContext.Orders.FindAsync(OrderId);

            return order.ToOrderResponse();
        }
    }
}

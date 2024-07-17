using RestaurantOrdersManager.Core.ServiceContracts.DTO.TableDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts
{
    public interface ITableService
    {
        Task<TableResponse> CreateTable(TableCreateRequest createTableRequest);

        Task<TableResponse> UpdateTable(TableUpdateRequest UpdateRequest);

        Task<bool> DeleteTable(TableDeleteRequest deleteRequest);   

        Task<TableResponse> GetTableById(int TableId);


        //add parameter to check free or occupied
        Task<IEnumerable<TableResponse>> GetAllTablesFreeOccupied(Enums.TableStatus status);

    }
}

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

        Task<TableResponse> UpdateTableName(int TableId, string TableName);

        Task<TableResponse> DeleteTable(int TableId);   

        Task<TableResponse> GetTableById(int TableId);


        //add parameter to check free or occupied
        Task<IEnumerable<TableResponse>> GetAllTables();

    }
}

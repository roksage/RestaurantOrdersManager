using RestaurantOrdersManager.Core.ServiceContracts.DTO.IngredientDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts
{
    public interface IIngredientService
    {
        public Task<IngredientResponse> CreateIngredient(IngredientAddRequest request);

        public Task<IEnumerable<IngredientResponse>> GetAllIngredients();

        public Task<IngredientResponse> UpdateIngredient(IngredientUpdateRequest request);

        public Task<bool> DeleteIngredient(IngredientDeleteRequest request);

        public Task<IngredientResponse> FindIngredientById(int ingredientId);

    }
}

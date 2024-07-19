using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using RestaurantOrdersManager.Core.Entities;
using RestaurantOrdersManager.Core.ServiceContracts;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.IngredientDTO;
using RestaurantOrdersManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly ManagerDbContext _dbContext;
        public IngredientService(ManagerDbContext dbContext) => _dbContext = dbContext;

        public async Task<IngredientResponse> CreateIngredient(IngredientAddRequest request)
        {
            Ingredient newIngredient = request.ToIngredient();

            await _dbContext.AddAsync(newIngredient);

            await _dbContext.SaveChangesAsync();

            return newIngredient.ToIngredientResponse();
        }

        public async Task<bool> DeleteIngredient(IngredientDeleteRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            Ingredient? findIngredient = await _dbContext.Ingredients.FirstOrDefaultAsync(t => t.IngredientId == request.IngredientId);

            if (findIngredient == null)
            {
                throw new ArgumentException($"Ingredient {request.IngredientId} doesn't exist");
            }

            _dbContext.Attach(findIngredient);
            _dbContext.Remove(findIngredient);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public Task<IEnumerable<IngredientResponse>> GetAllIngredients()
        {
            throw new NotImplementedException();
        }

        public Task<IngredientResponse> UpdateIngredient(IngredientUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

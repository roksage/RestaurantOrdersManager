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

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            bool findIngredientByName = await _dbContext.Ingredients.AnyAsync(i => i.IngredientName == request.IngredientName);
            if (findIngredientByName)
            {
                throw new ArgumentException($"Ingredient with this name already exist {request.IngredientName}");
            }


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

        public async Task<IngredientResponse> FindIngredientById(int ingredientId)
        {
            Ingredient? ingredient = await _dbContext.Ingredients.FirstOrDefaultAsync(ing => ing.IngredientId ==  ingredientId);

            return ingredient.ToIngredientResponse();
        }

        public async Task<IEnumerable<IngredientResponse>> GetAllIngredients()
        {
            return await _dbContext.Ingredients.Select(ingredient => ingredient.ToIngredientResponse()).ToListAsync();
        }

        public async Task<IngredientResponse> UpdateIngredient(IngredientUpdateRequest request)
        {


            Ingredient? findIngredientById = await _dbContext.Ingredients.FirstOrDefaultAsync(i => i.IngredientId == request.IngredientId);



            if (findIngredientById == null)
            {
                throw new ArgumentNullException($"Ingredient not found - {request.IngredientId}");
            }

            //check if that name doesn't exist already
            bool findIngredientByName = await _dbContext.Ingredients.AnyAsync(i => i.IngredientName == request.IngredientName);

            if (findIngredientByName)
            {
                throw new ArgumentException($"Ingredient with this name already exist {request.IngredientName}");
            }

            if (request.IngredientName != null)
            {
                findIngredientById.IngredientName = request.IngredientName;
            }
            if (request.IngredientUnit != null)
            {
                findIngredientById.IngredientUnit = request.IngredientUnit;
            }
            if (request.IngredientAmount != null)
            {
                findIngredientById.IngredientAmount = request.IngredientAmount;
            }

            await _dbContext.SaveChangesAsync();

            return findIngredientById.ToIngredientResponse();

        }
    }
}

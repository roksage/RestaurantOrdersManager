using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.Enums;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.IngredientDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.DTO.IngredientDTO
{
    public class IngredientResponse
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }

        public IngredientEnums IngredientUnit { get; set; }
        public double IngredientAmount { get; set; }
    }
    public static class IngredientResponseExtension
    {
        public static IngredientResponse ToIngredientResponse(this Ingredient ingredient)
        {
            return new IngredientResponse { IngredientId = ingredient.IngredientId,
                                            IngredientName = ingredient.IngredientName,
                                            IngredientUnit = ingredient.IngredientUnit,
                                            IngredientAmount = ingredient.IngredientAmount
            };
        }
        //public static IEnumerable<IngredientResponse> ToIngredientResponse(this IEnumerable<Ingredient> ingredients)
        //{
        //    return  ingredients.Select(ingredient => ingredient.ToIngredientResponse()).ToList();
            
        //}
    }
}

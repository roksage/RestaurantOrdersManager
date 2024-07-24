using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.DTO.IngredientDTO
{
    public class IngredientUpdateRequest
    {
        public int IngredientId { get; set; }   
        public string IngredientName { get; set; }
        public IngredientEnums IngredientUnit { get; set; }
        public double IngredientAmount { get; set; }

        public Ingredient ToIngredient()
        {
            return new Ingredient
            {
                IngredientId = IngredientId,
                IngredientName = IngredientName,
                IngredientUnit = IngredientUnit,
                IngredientAmount = IngredientAmount
            };
        }
    }
}

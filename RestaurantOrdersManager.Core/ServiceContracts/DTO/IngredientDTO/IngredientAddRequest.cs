using RestaurantOrdersManager.Core.Entities;
using RestaurantOrdersManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.DTO.IngredientDTO
{
    public class IngredientAddRequest
    {
        [Required(ErrorMessage = "Please provide IngredientName")]
        public string IngredientName { get; set; }
        [Required(ErrorMessage = "Please provide IngredientUnit")]
        public IngredientEnums IngredientUnit { get; set; }
        [Required(ErrorMessage = "Please provide IngredientAmount")]
        public double IngredientAmount { get; set; }

        public Ingredient ToIngredient()
        {
            return new Ingredient
            {
                IngredientName = IngredientName,
                IngredientUnit = IngredientUnit,
                IngredientAmount = IngredientAmount
            };
        }
    }
}

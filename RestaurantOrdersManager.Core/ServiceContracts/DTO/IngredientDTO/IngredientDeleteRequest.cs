using RestaurantOrdersManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.DTO.IngredientDTO
{
    public class IngredientDeleteRequest
    {
        public int IngredientId { get; set; } 

        public Ingredient ToIngredient()
        {
            return new Ingredient { }
        }
    }
}

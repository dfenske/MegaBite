using MegaBite.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaBite.Data.Provider.Mock
{
    public class IngredientMockProvider
    {
        Dictionary<Guid, Ingredient> ingredients = new Dictionary<Guid, Ingredient>();

        private string[] ingredientArray = new string[]
        {
            "Sugar",
            "Flour",
            "Eggs",
            "Milk",
            "Cinnamon",
            "Chocolate Chips",
            "Baking Soda",
            "Baking Powder",
            "Salt",
            "Brown Sugar"
        };

        public IngredientMockProvider()
        {
            for (int i = 0; i < 10; i++)
            {
                Guid id = Guid.NewGuid();
                ingredients.Add(id, new Ingredient { Id = id, Name = ingredientArray[i] } );
            }
        }

        public Dictionary<Guid, Ingredient> GetAllIngredients()
        {
            return ingredients;
        }
    }
}

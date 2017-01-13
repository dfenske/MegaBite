using System;
using System.Collections.Generic;
using MegaBite.Domain.Model;

namespace MegaBite.Domain.Contracts
{
    public interface IRecipeData
    {
        Recipe SaveRecipe(Recipe recipe);
        List<Recipe> GetAll();
        Recipe GetById(Guid id);
        void DeleteRecipe(Recipe recipe);
    }
}
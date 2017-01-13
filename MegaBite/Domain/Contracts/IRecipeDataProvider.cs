using System;
using System.Collections.Generic;
using MegaBite.Domain.Model;

namespace MegaBite.Domain.Contracts
{
    public interface IRecipeDataProvider
    {
        Recipe SaveRecipe(Recipe r);
        List<Recipe> GetAll();
        Recipe GetById(Guid id);
        bool DeleteConfirmed(Guid id);
    }
}
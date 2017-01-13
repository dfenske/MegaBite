using MegaBite.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaBite.Domain.Contracts
{
    public interface IRecipeBusiness
    {
        Recipe SaveRecipe(Recipe recipe);
        List<Recipe> GetAll();
        Recipe GetById(Guid id);
        void DeleteRecipe(Recipe recipe);
    }
}

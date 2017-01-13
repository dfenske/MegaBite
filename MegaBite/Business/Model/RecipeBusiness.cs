using BulletTime.Operational.Dependency;
using MegaBite.Data.Model;
using MegaBite.Domain.Contracts;
using MegaBite.Domain.Model;
using MegaBite.Operational.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaBite.Business.Model
{
    public class RecipeBusiness : IRecipeBusiness
    {
        #region Properties

        /// <summary>
        /// Gets the recipe data.
        /// </summary>
        /// <value>
        /// The recipe data.
        /// </value>
        protected IRecipeData RecipeData
        {
            get
            {
                return DependencyFactory.GetContainer()
                                        .Resolve<IRecipeData>("RecipeData");
            }
        }
        #endregion

        public Recipe SaveRecipe(Recipe recipe)
        {
            try
            {
                return RecipeData.SaveRecipe(recipe);
            }
            catch
            {
                throw new MBException("Could not get the data layer to create the recipe.");
            }

        }

        public List<Recipe> GetAll()
        {
            try
            {
                return RecipeData.GetAll();
            }
            catch
            {
                throw new MBException("Could not get the data layer to get all recipes.");
            }
        }

        public Recipe GetById(Guid id)
        {
            try
            {
                return RecipeData.GetById(id);
            }
            catch
            {
                throw new MBException("Could not get the data layer to get all recipes.");
            }
        }

        public void DeleteRecipe(Recipe recipe)
        {
            try
            {
                RecipeData.DeleteRecipe(recipe);
            }
            catch
            {
                throw new MBException("Could not get the data layer to delete recipe.");
            }
        }
    }
}

using System;
using MegaBite.Domain.Contracts;
using MegaBite.Domain.Model;
using MegaBite.Data.Provider;
using MegaBite.Operational.Error;
using MegaBite.Operational.Resources;
using System.Collections.Generic;

namespace MegaBite.Data.Model
{
    public class RecipeData : DataCommon, IRecipeData
    {
        public RecipeData()
        {
        }

        public void DeleteRecipe(Recipe recipe)
        {
            try
            {
                IRecipeDataProvider tableProvider = ProviderFactory.GetRecipeProvider(ProviderType.Mock);
                if(tableProvider != null)
                {
                    // Call Table provider to delete recipe.
                    bool deleted = tableProvider.DeleteConfirmed(recipe.Id);
                    if(!deleted)
                    {
                        throw new MBException("Could not delete the recipe from the data provider.");
                    }
                }
                else
                {
                    throw new MBException(ErrorMessages.DataProviderNotFound_ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                // Pass error up the stack.
                HandleError(ex);
            }
        }

        public List<Recipe> GetAll()
        {
            List<Recipe> response = new List<Recipe>();
            try
            {
                // Table Provider
                IRecipeDataProvider tableProvider = ProviderFactory.GetRecipeProvider(ProviderType.Mock);

                if (tableProvider != null)
                {
                    // Call Table provider to get all recipes.
                    response = tableProvider.GetAll();
                }
                else
                {
                    throw new MBException(ErrorMessages.DataProviderNotFound_ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                // Pass error up the stack
                HandleError(ex);
            }

            return response;
        }

        public Recipe GetById(Guid id)
        {
            Recipe response = new Recipe();
            try
            {
                // Table Provider
                IRecipeDataProvider tableProvider = ProviderFactory.GetRecipeProvider(ProviderType.Mock);

                if (tableProvider != null)
                {
                    // Call Table provider to get the recipe.
                    response = tableProvider.GetById(id);
                }
                else
                {
                    throw new MBException(ErrorMessages.DataProviderNotFound_ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                // Pass error up the stack
                HandleError(ex);
            }

            return response;
        }

        public Recipe SaveRecipe(Recipe recipe)
        {
            Recipe response = new Recipe();
            try
            {
                if(recipe.Operation==Operation.Create)
                {
                    recipe.Id = Guid.NewGuid();
                    recipe.Comments = new List<Comment>();
                }
                // Table Provider
                IRecipeDataProvider tableProvider = ProviderFactory.GetRecipeProvider(ProviderType.Mock);

                if (tableProvider != null)
                {
                    // Call Table provider to save the recipe.
                    response = tableProvider.SaveRecipe(recipe);
                }
                else
                {
                    throw new MBException(ErrorMessages.DataProviderNotFound_ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                // Pass error up the stack
                HandleError(ex);
            }

            return response;
        }
    }
}
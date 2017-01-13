using BulletTime.Operational.Dependency;
using MegaBite.Clients.Web.Sugar.Binders;
using MegaBite.Data.Provider.AzureBlob;
using MegaBite.Domain.Contracts;
using MegaBite.Domain.Model;
using MegaBite.Operational.Error;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MegaBite.Clients.Web.Sugar.Controllers
{

    public class RecipeController : ControllerCommon
    {
        #region Properties
        /// <summary>
        /// Gets the Recipe business.
        /// </summary>
        /// <remarks>The concrete implementation is resolved using the DependencyFactory which in turn uses Unity to resolve the implementation.</remarks>
        /// <value>
        /// The Recipe business.
        /// </value>
        protected IRecipeBusiness RecipeBusiness
        {
            get
            {
                return DependencyFactory.GetContainer()
                                        .Resolve<IRecipeBusiness>("RecipeBusiness");
            }
        }

        #endregion

        #region Methods
        // GET: Recipe
        public ActionResult Index()
        {
            List<Recipe> recipes = new List<Recipe>();
            try
            {
                recipes = RecipeBusiness.GetAll();
            }
            catch
            {
                throw new MBException("Could not call the business layer to get all.");
            }
            return View(recipes);
        }

        // GET: Recipe/Details/5
        public ActionResult Details(Guid id)
        {
            Recipe recipe;
            try
            {
                recipe = RecipeBusiness.GetById(id);
            }
            catch
            {
                throw new MBException("Could not call business layer to get by Id.");
            }
            return View(recipe);
        }

        // GET: Recipe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipe/Create
        [HttpPost]
        public ActionResult Create([ModelBinder(typeof(RecipeBinder))]Recipe recipe)
        {
            try
            {
                recipe.Operation = Operation.Create;
                
                RecipeBusiness.SaveRecipe(recipe);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Recipe/Edit/5
        public ActionResult Edit(Guid id)
        {
            Recipe recipe;
            try
            {
                recipe = RecipeBusiness.GetById(id);
            }
            catch
            {
                throw new MBException("Could not call business layer to edit.");
            }
            return View(recipe);
        }

        // POST: Recipe/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Recipe recipe)
        {

            try
            {
                recipe.Operation = Operation.Update;
                RecipeBusiness.SaveRecipe(recipe);
            }
            catch (Exception ex)
            {
                //If error in below layers, return that error to the view.
                return HandleError(ex, recipe);
            }

            return RedirectToAction("Index");
        }

        // GET: Recipe/Delete/5
        public ActionResult Delete(Guid id)
        {
            Recipe recipe;
            try
            {
                recipe = RecipeBusiness.GetById(id);
            }
            catch
            {
                throw new MBException("Could not call business layer to get by id.");
            }
            return View(recipe);
        }

        // POST: Recipe/Delete/5
        [HttpPost]
        public ActionResult Delete(Recipe recipe)
        {
            try
            {
                RecipeBusiness.DeleteRecipe(recipe);

                return RedirectToAction("Index");
            }
            catch
            {
                throw new MBException("Could not delete recipe.");
            }
        }
    }
    #endregion

}

using MegaBite.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using MegaBite.Data.Provider.AzureBlob;
using Microsoft.WindowsAzure.Storage;
using System.Configuration;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace MegaBite.Clients.Web.Sugar.Binders
{
    public class RecipeBinder : IModelBinder
    {/// <summary>
     /// Translates the input from the Create view into a Recipe object.
     /// </summary>
     /// <param name="controllerContext"></param>
     /// <param name="bindingContext"></param>
     /// <returns></returns>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {

            Recipe recipe = new Recipe();
            Guid ingredientId;
            recipe.Ingredients = new List<Ingredient>();
            recipe.Steps = new List<Step>();
            var form = controllerContext.HttpContext.Request.Form;
            try
            {
                // NAME
                recipe.Name = form.Get("Name");
               
                // DESCRIPTION
                recipe.Description = form.Get("Description");
                
                // TIME TO MAKE
                recipe.TimeToMakeInMinutes = Int32.Parse(form.Get("TimeToMakeInMinutes"));
                
                // INGREDIENTS
                if (Guid.TryParse(form.Get("Ingredient"), out ingredientId))
                {
                    recipe.Ingredients.Add(new Ingredient { Name = "", Id = ingredientId });
                }

                // STEPS
                recipe.Steps.Add( new Step { Directions = form.Get("Steps")});

                // SERVES
                recipe.Serves = Int32.Parse(form.Get("Serves"));

                // TAGS
                string tagsString = form.Get("Tags");
                if (tagsString != null)
                {
                    List<string> tagsList = tagsString.Split(',').ToList();
                    recipe.Tags = tagsList;
                }
                else
                {
                    recipe.Tags = null;
                }

                // NOTES
                string notesString = form.Get("Notes");
                if (notesString != null)
                {
                    List<string> notesList = notesString.Split(',').ToList();
                    recipe.Notes = notesList;
                }
                else
                {
                    recipe.Notes = null;
                }

                //TODO: author = GetUserById(form.Get("Author"));
                recipe.Author = new User { FirstName = "Dani", LastName="Fenske", Email = "dani.fenske@gmail.com", Id = Guid.NewGuid() };

                // IMAGES
                recipe.Images = new List<Uri>();
                if (controllerContext.HttpContext.Request.Files.Count > 0)
                {
                    // BLOB UPLOAD
                    AzureBlobProvider blobProvider = new AzureBlobProvider();
                    foreach (string file in controllerContext.RequestContext.HttpContext.Request.Files)
                    {
                        HttpPostedFileBase image = controllerContext.RequestContext.HttpContext.Request.Files[file] as HttpPostedFileBase;
                        if (image.ContentLength == 0)
                            continue;
                        int contentLength = image.ContentLength;
                        string contentType = image.ContentType;
                        string fileName = image.FileName;

                        // Upload to blob storage, save url to access it as property of recipe.
                        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
                        Uri imageUri = blobProvider.UploadFile(storageAccount, "images", image, fileName);

                        // Save uri of new blob to the recipe.
                        recipe.Images.Add(imageUri);
                    }
                }
                // DATE
                recipe.DateCreated = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw;
            }
            return recipe;
        }


    }
}
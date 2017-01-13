using MegaBite.Domain.Contracts;
using MegaBite.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaBite.Data.Provider.Mock
{
    public class RecipeMockProvider : IRecipeDataProvider
    {
        #region Fields

        private static Dictionary<Guid, Recipe> RecipeRepository = new Dictionary<Guid, Recipe>();

        #endregion

        #region Properties
        private User user = new User
        {
            Email = "dani.fenske@gmail.com",
            Id = Guid.NewGuid(),
            FirstName = "Dani", 
            LastName = "Fenske"
        };

        private string[] descriptions = new string[]
        {
            "Bran muffins can get a bad rap. They're so often dry and overly-sweet, which always feels like a shame because bran has such a nice flavor in and of itself. Plus, there are so many ways to add a punch of flavor without a lot of extra sugar. How about a mound of blueberries, fresh lemon zest, and coconut oil folded into a delicate whole-grain batter? ",
            "Soupe au pistou, the classic Provençal summer soup made with the freshest summer vegetables, shell beans, and pasta and finished with a dollop of basil pistou, will always carry a special place in my heart—it was the first dinner I ever ate with my French host family, on the balcony, the warm southern French sun on my back. It had never in my life occurred to me to eat soup in August, but I loved it.",
            "Sweet and perfect for sharing with friends."
        };

        private List<Uri>[] images = new List<Uri>[]
        {
            new List<Uri> { new Uri("http://megabite.blob.core.windows.net/images/blueberry_muffins.jpg") },
            new List<Uri> { new Uri("http://megabite.blob.core.windows.net/images/spinach_salad.jpg") },
            new List<Uri> { new Uri("http://megabite.blob.core.windows.net/images/provencal_seafood_stew.jpg") }
        };

        private List<Ingredient>[] ingredientsArray = new List<Ingredient>[]
        {
            new List<Ingredient>
            {
                new Ingredient
                {
                    Name="Blueberries"
                },
                new Ingredient
                {
                    Name = "Flour"
                },
                new Ingredient
                {
                    Name = "Sugar"
                }
            },
            new List<Ingredient>
            {
                new Ingredient
                {
                    Name = "Spinach"
                },
                new Ingredient
                {
                    Name = "Berries"
                }
            },
            new List<Ingredient>
            {
                new Ingredient
                {
                    Name = "Shrimp"
                },
                new Ingredient
                {
                    Name = "Vegetable Broth"
                },
                new Ingredient
                {
                    Name = "Spinach"
                }
            }
        };

        private string[] names = new string[]
        {
            "Blueberry muffins",
            "Spinach salad with berries",
            "Provençal Seafood Stew"
        };

        private int[] times = new int[] { 30, 60, 120 };

        private List<string>[] tagsArray = new List<string>[]
        {
            new List<string>
            {
                "Brunch",
                "Fruit",
                "Breakfast"
            },
            new List<string>
            {
                "Healthy",
                "Dinner",
                "Side"
            },
            new List<string>
            {
                "Soup",
                "French"
            }
        };

        private List<Step>[] stepsArray = new List<Step>[]
        {
            new List<Step>
            {
                new Step
                {
                    Directions = "Preheat the oven to 350°F. Whisk together the eggs, buttermilk, coconut oil, salt, baking soda, vanilla extract, lemon zest and sugar. Stir in the bran cereal and both flours and mix well until thoroughly combined. The batter should be pretty stiff at this point. Carefully fold in the blueberries."
                },
                new Step
                {
                    Directions = "Butter 12 standard-size muffin cups liberally. Fill each to the very top with batter. Scatter the tops of the muffins with the pecan pieces, if desired. Bake for 35 minutes or until the tops are firm and slightly brown. Let cool for 15 minutes before removing muffins from tins. Serve warm or cover and store at room temperature for up to 3 days. "
                }
            },
            new List<Step>
            {
                new Step
                {
                    Directions = "Wash and dry spinach and berries."
                },
                new Step
                {
                    Directions = "Place ingredients in bowl."
                },
                new Step
                {
                    Directions = "Toss with dressing and serve."
                },
            },
            new List<Step>
            {
                new Step
                {
                    Directions = "Prepare the shrimp."
                },
                new Step
                {
                    Directions = "Boil ingredients for 3 hours."
                }
            }
        };

        private List<Comment>[] commentsArray = new List<Comment>[] {
            new List<Comment> {
                new Comment
                {
                    Author = new User
                    {
                        Email = "rachel@gmail.com",
                        Id = Guid.NewGuid(),
                        FirstName = "Rachel",
                        LastName = "Smith"
                    },
                    CommentText = "These muffins are to die for! I will definitely make them again soon.",
                    DateCreated = DateTime.Now.AddDays(-2),
                    Rating = Rating.Best
                },
                new Comment
                {
                    Author = new User
                    {
                        Email = "hannah@gmail.com",
                        Id = Guid.NewGuid(),
                        FirstName = "Hannah",
                        LastName = "Son"
                    },
                    CommentText = "When I tried to make them, they turned out a little too tart.",
                    DateCreated = DateTime.Now.AddDays(-7),
                    Rating = Rating.Bad
                }
            },
            new List<Comment> {
                new Comment
                {
                    Author = new User
                    {
                        Email = "ben@gmail.com",
                        Id = Guid.NewGuid(),
                        FirstName = "Ben",
                        LastName = "Marky"
                    },
                    CommentText = "The salad was very simple to make and impressed my guests.",
                    DateCreated = DateTime.Now.AddDays(-5),
                    Rating = Rating.Delicious
                }
            },
            new List<Comment> {
                new Comment
                {
                    Author = new User
                    {
                        Email = "Angela@gmail.com",
                        Id = Guid.NewGuid(),
                        FirstName = "Angela",
                        LastName = "Patrick"
                    },
                    CommentText = "I'm not usually a fan of seafood, but this soup changed my mind!",
                    DateCreated = DateTime.Now.AddDays(-3),
                    Rating = Rating.Best
                },
                new Comment
                {
                    Author = new User
                    {
                        Email = "Bob@gmail.com",
                        Id = Guid.NewGuid(),
                        FirstName = "Bob",
                        LastName = "Furd"
                    },
                    CommentText = "This soup was comforting on a rainy night. Smells and tastes delicious!",
                    DateCreated = DateTime.Now.AddDays(-8),
                    Rating = Rating.Delicious
                },
                new Comment
                {
                    Author = new User
                    {
                        Email = "Frederick@gmail.com",
                        Id = Guid.NewGuid(),
                        FirstName = "Frederick",
                        LastName = "Thorough"
                    },
                    CommentText = "I would cut down on the salt next time. Otherwise, amazing!",
                    DateCreated = DateTime.Now.AddDays(-1),
                    Rating = Rating.Ok
                }
            }
        };

        private List<string>[] notesArray = new List<string>[] {
            new List<string> {
                "While I love the subtle sweetness of coconut oil for this recipe, if you'd rather use canola or vegetable oil, feel free.",
                "I use frozen blueberries because they're readily available year-round. Do not thaw them before using — fold them in just as they are."
            },
            new List<string> {
                "Strawberry-Arugula Salad: Try arugula in place of the spinach."
            },
            new List<string> { }
        };
        #endregion

        #region Constructors
        public RecipeMockProvider()
        {
            Guid id;
            if(!RecipeRepository.Any()) { 
            for (int i = 0; i < 3; i++)
            {
                id = Guid.NewGuid();
                    RecipeRepository.Add(
                        id, new Recipe
                        {
                            Author = user,
                            DateCreated = DateTime.Now.AddDays(-i),
                            Description = descriptions[i],
                            Id = id,
                            Images = images[i],
                            Ingredients = ingredientsArray[i],
                            Name = names[i],
                            TimeToMakeInMinutes = times[i],
                            Tags = tagsArray[i],
                            Steps = stepsArray[i],
                            Serves = 4,
                            Comments = commentsArray[i],
                            Notes = notesArray[i] 
                    }
                );
            }
            }
        }
        #endregion

        #region Methods

        public Recipe SaveRecipe(Recipe Recipe)
        {
            if (RecipeRepository.ContainsKey(Recipe.Id))
            {
                RecipeRepository[Recipe.Id] = Recipe;
            }
            else
            {
                RecipeRepository.Add(Recipe.Id, Recipe);
            }

            return Recipe;
        }

        /// <summary>
        /// Looks up the Recipe with the given ID in the repository.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Recipe with the given ID.</returns>
        public Recipe GetById(Guid id)
        {
            Recipe Recipe = null;
            if (RecipeRepository.ContainsKey(id))
            {
                Recipe = RecipeRepository[id];
            }
            return Recipe;
        }

        /// <summary>
        /// This method gets called from the Business layer's GetAll method
        /// it calls the "GetAll" method which returns a List<Recipe> of all the 
        /// Food Trucks in the DB "Which is a Dictionary for now "
        /// </summary>
        /// <returns>
        /// Returns a List<Recipe> of all the Food Trucks in the DB "Which is a Dictionary for now"
        /// or null if there are no truck added to the DB
        /// </returns>
        public List<Recipe> GetAll()
        {
            // A list to hold the added trucks in the DB "Dictionary for now"
            List<Recipe> response = new List<Recipe>();

            // Check if the dictionary have values in it
            if (RecipeRepository != null)
            {
                // If yes, save those values in the created list
                response = RecipeRepository.Values.ToList();
            }

            // return a populated list or null
            return response;
        }

        /// <summary>
        /// Gets called from the Data Layer. Takes the Truck's Guid and
        /// deletes it from the DB "a Dictionary for now"
        /// </summary>
        /// <param name="id">
        /// Takes the Truck's Guid
        /// </param>
        /// <returns>
        /// Returns a boolean; True if the Truck existed and deleted
        /// False if it didn't exist 
        /// </returns>
        public bool DeleteConfirmed(Guid id)
        {
            // If the Truck ID exists in the DB "a Dictionary for now"
            if (RecipeRepository.ContainsKey(id))
            {
                // Delete it
                RecipeRepository.Remove(id);

                return true;
            }

            return false;
        }

        #endregion
    }
}

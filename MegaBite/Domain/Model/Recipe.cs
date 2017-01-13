using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaBite.Domain.Model
{
    public class Recipe : BaseObject
    {
        [Required]
        [DisplayName("Recipe Title")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Recipe Description")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Ingredients")]
        [UIHint("Ingredients")]
        public List<Ingredient> Ingredients { get; set; }
        [Required]
        [DisplayName("Author")]
        [UIHint("User")]
        public User Author { get; set; }
        [Required]
        [DisplayName("Tags")]
        [UIHint("StringList")]
        public List<string> Tags { get; set; }
        [Required]
        [DisplayName("Time it takes to make (in minutes)")]
        [UIHint("Minutes")]
        public int TimeToMakeInMinutes { get; set; }
        [Required]
        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; }
        [Required]
        [DisplayName("Instructions")]
        [UIHint("Steps")]
        public List<Step> Steps { get; set; }
        [DisplayName("Comments")]
        public List<Comment> Comments { get; set; }
        public Operation Operation { get; set; }
        public List<Uri> Images { get; set; }
        [Required]
        [DisplayName("Serves")]
        public int Serves { get; set; }
        [DisplayName("Recipe Notes")]
        public List<string> Notes { get; set; }
        [DisplayName("Average Rating")]
        [UIHint("Rating")]
        public double? AverageRating
        {
            get { return GetAverageRating(); }
        }

        public Recipe()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets the average rating for this recipe by looking at all comments.
        /// </summary>
        /// <returns>The average rating rounded to two decimal spaces.</returns>
        public double? GetAverageRating()
        {
            double response = 0;
            int count = 0;
            if (this.Comments.Any())
            {
                foreach (Comment c in this.Comments)
                {
                    response += (int)c.Rating;
                    count++;
                }

                response = response / count;
                return Math.Round(response, 2);
            }
            else
            {
                return null;
            }
        }
    }
}

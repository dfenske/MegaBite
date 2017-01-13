using System;
using System.ComponentModel;

namespace MegaBite.Domain.Model
{
    public class Comment
    {
        [DisplayName("Author")]
        public User Author { get; set; }
        [DisplayName("Text")]
        public string CommentText { get; set; }
        [DisplayName("Date Comment was Created")]
        public DateTime DateCreated { get; set; }
        [DisplayName("Rating")]
        public Rating Rating { get; set; }

    }
}
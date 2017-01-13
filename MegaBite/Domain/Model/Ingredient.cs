using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MegaBite.Domain.Model
{
    public class Ingredient : BaseObject
    {
        [DisplayName("Ingredient Name")]
        public string Name { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace cortanarecipes.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public int Sequence { get; set; }
        public int RecipeId { get; set; }
        public double Quantity { get; set; }
        public string Measure { get; set; }
        public string Name { get; set; }
    }
}

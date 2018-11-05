using System.Collections.Generic;

namespace cortanarecipes.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Instruction> Instructions { get; set; }
    }

    public class RecipeVM
    {
        public int Id { get; set; }
        public int Description { get; set; }
    }
}

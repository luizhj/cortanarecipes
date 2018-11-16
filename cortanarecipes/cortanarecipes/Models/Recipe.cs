using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace cortanarecipes.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        public ObservableCollection<Instruction> Instructions { get; set; }
    }
}

using cortanarecipes.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace cortanarecipes.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<RecipeVM> _recipes;
        public ObservableCollection<RecipeVM> Recipes
        {
            get { return _recipes; }
            set { SetProperty(ref _recipes, value); }
        }
        /*
         * 
        // if using this format to generate de xaml, visual studio crashes.
        // i think it is because the object recipe contains two lists inside him.
        private ObservableCollection<Recipe> _recipes2;
        public ObservableCollection<Recipe> Recipes2
        {
            get { return _recipes2; }
            set { SetProperty(ref _recipes2, value); }
        }
        */
        public Command NewRecipe { get; set; }

    }
    
}

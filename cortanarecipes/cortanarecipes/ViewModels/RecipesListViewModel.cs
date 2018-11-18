using cortanarecipes.DataAccess;
using cortanarecipes.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace cortanarecipes.ViewModels
{
    public class RecipesListViewModel : RecipeViewModel
    {
        #region View Objects
        private ObservableCollection<Recipe> _recipes;
        public ObservableCollection<Recipe> Recipes
        {
            get { return _recipes; }
            set { SetProperty(ref _recipes, value); }
        }
        #endregion

        #region Button Commands
        public Command AddRecipeCommand { get; set; }
        public Command NavigateToRecipeCommand { get; set; }
        public Command RefreshRecipeListCommand { get; set; }
        #endregion

        #region Aux Variables
        private RecipeDAO RecipeDAO;
        #endregion

        #region Constructors
        public RecipesListViewModel()
        {
            InitializeCommands();
            RefreshRecipesList();
        }
        #endregion

        #region Model Functions
        public void RefreshRecipesList()
        {
            if (RecipeDAO.Recipes() is List<Recipe> _recipes)
            {
                Recipes = new ObservableCollection<Recipe>(_recipes);
            }
        }
        private async Task NavigateToRecipe(Recipe e)
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            await PushAsync<RecipeViewModel>(e);

            IsBusy = false;
        }
        private void InitializeCommands()
        {
            RecipeDAO = new RecipeDAO();
            AddRecipeCommand = new Command(async () => await PushAsync<RecipeViewModel>());
            RefreshRecipeListCommand = new Command(RefreshRecipesList);
            NavigateToRecipeCommand = new Command<Recipe>(async (Recipe e) => await NavigateToRecipe(e));
        }
        #endregion
    }

}

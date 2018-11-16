using cortanarecipes.DataAccess;
using cortanarecipes.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using cortanarecipes.Helpers;

namespace cortanarecipes.ViewModels
{
    public class IngredientsListViewModel : BaseViewModel
    {
        #region View properties
        private int _recipeId;
        public int RecipeId
        {
            get { return _recipeId; }
            set { SetProperty(ref _recipeId, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private string _note;
        public string Note
        {
            get { return _note; }
            set { SetProperty(ref _note, value); }
        }

        private ObservableCollection<Ingredient> _ingredients;
        public ObservableCollection<Ingredient> Ingredients
        {
            get { return _ingredients; }
            set { SetProperty(ref _ingredients, value); }
        }
        #endregion

        #region Aux Variables
        private Recipe _recipe;
        private IngredientDAO IngredientDAO { get; set; }
        #endregion

        #region View Aux Functions
        private void FillProperties(Recipe recipe)
        {
            RecipeId = recipe.Id;
            Description = recipe.Description;
            Note = recipe.Note;
        }
        #endregion

        #region Button Commands
        public Command AddIngredientCommand { get; set; }
        public Command NavigateToIngredientCommand { get; set; }
        #endregion

        #region Constructors
        public IngredientsListViewModel(Recipe recipe)
        {
            _recipe = recipe;
            FillProperties(recipe);
            InitializeCommands();


            if (IngredientDAO.Ingredients(_recipe.Id) is List<Ingredient> _ingredients)
            {
                Ingredients = new ObservableCollection<Ingredient>(_ingredients);
            }

        }
        #endregion

        #region Model Functions
        private void InitializeCommands()
        {
            IngredientDAO = new IngredientDAO();
            AddIngredientCommand = new Command(async () => await AddIngredient());
            NavigateToIngredientCommand = new Command<Ingredient>(async (e) => await NavigateToIngredient(e));
        }

        private async Task AddIngredient()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            await PushAsync<IngredientViewModel>(RecipeId);

            IsBusy = false;
        }

        private async Task NavigateToIngredient(Ingredient e)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            await PushAsync<IngredientViewModel>(e);

            IsBusy = false;
        }

        #endregion
    }
}

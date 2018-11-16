using cortanarecipes.DataAccess;
using cortanarecipes.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace cortanarecipes.ViewModels
{
    public class RecipeViewModel : BaseViewModel
    {
        #region View properties
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
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
        #endregion

        #region View Aux Functions
        private void FillProperties(Recipe recipe)
        {
            Id = recipe.Id;
            Description = recipe.Description;
            Note = recipe.Note;
        }
        private void FillProperties()
        {
            Id = 0;
            Description = string.Empty;
            Note = string.Empty;
        }
        private Recipe GetProperties(Recipe recipe = null)
        {
            if (recipe == null)
            {
                recipe = new Recipe();
            }

            recipe.Id = Id;
            recipe.Note = Note;
            recipe.Description = Description;

            return recipe;

        }
        #endregion

        #region Aux Variables
        private RecipeDAO RecipeDAO { get; set; }
        private Recipe _recipe { get; set; }
        #endregion

        #region Button Commands
        public Command SaveCommand { get; set; }
        public Command RemoveCommand { get; set; }
        
        public Command NavigateToIngredientsListCommand { get; set; }
        public Command NavigateToInstructionsListCommand { get; set; }
        #endregion

        #region Constructors
        // for new recipe
        public RecipeViewModel()
        {
            _recipe = new Recipe();

            InitializeCommands();
            FillProperties();
        }

        // for edit / remove recipe
        public RecipeViewModel(Recipe recipe)
        {
            _recipe = recipe;

            InitializeCommands();
            FillProperties(_recipe);
        }
        #endregion

        #region Model Functions
        private void InitializeCommands()
        {
            RecipeDAO = new RecipeDAO();
            SaveCommand = new Command(async () => await SaveRecipe());
            RemoveCommand = new Command(async () => await RemoveRecipe());
            NavigateToIngredientsListCommand = new Command(async () => await NavigateToIngredientsList());
            NavigateToInstructionsListCommand = new Command(async () => await NavigateToInstructionsList());
            
        }
        private async Task SaveRecipe()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            _recipe = GetProperties(_recipe);

            if (_recipe.Id == 0)
            {
                RecipeDAO.Add(_recipe);
            }
            else
            {
                RecipeDAO.Update(_recipe);
            }

            await Application.Current.MainPage.Navigation.PopAsync();

            IsBusy = false;
        }
        private async Task RemoveRecipe()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            _recipe = GetProperties(_recipe);

            RecipeDAO.Remove(_recipe);

            await Application.Current.MainPage.Navigation.PopAsync();

            IsBusy = false;
        }
        private async Task NavigateToIngredientsList()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            await PushAsync<IngredientsListViewModel>(_recipe);

            IsBusy = false;

        }
        private async Task NavigateToInstructionsList()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            await PushAsync<InstructionsListViewModel>(_recipe);

            IsBusy = false;
        }

        #endregion
    }
}

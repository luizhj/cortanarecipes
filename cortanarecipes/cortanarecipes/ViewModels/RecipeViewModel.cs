using cortanarecipes.DataAccess;
using cortanarecipes.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using cortanarecipes.Resources;

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

        private ObservableCollection<Ingredient> _ingredients;
        public ObservableCollection<Ingredient> Ingredients
        {
            get { return _ingredients; }
            set { SetProperty(ref _ingredients, value); }
        }

        private ObservableCollection<Instruction> _instructions;
        public ObservableCollection<Instruction> Instructions
        {
            get { return _instructions; }
            set { SetProperty(ref _instructions, value); }
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
        private IngredientDAO IngredientDAO { get; set; }
        private InstructionDAO InstructionDAO { get; set; }
        private Recipe _recipe { get; set; }
        #endregion

        #region Button Commands
        public Command SaveCommand { get; set; }
        public Command RemoveCommand { get; set; }
        public Command NewIngredientCommand { get; set; }
        public Command NewInstructionCommand { get; set; }
        public Command IngredientDetailCommand { get; set; }
        public Command InstructionDetailCommand { get; set; }
        public Command StartReadCommand { get; set; }
        #endregion

        #region Constructors
        // for new recipe
        public RecipeViewModel()
        {
            _recipe = new Recipe();
            Title = AppResources.RsNewRecipe;
            InitializeCommands();
            FillProperties();
        }

        // for edit / remove recipe
        public RecipeViewModel(Recipe recipe)
        {
            _recipe = recipe;
            Title = AppResources.RsRecipeDetail;
            InitializeCommands();
            FillProperties(_recipe);
        }
        #endregion

        #region Model Functions
        private void InitializeCommands()
        {
            RecipeDAO = new RecipeDAO();
            IngredientDAO = new IngredientDAO();
            InstructionDAO = new InstructionDAO();
            SaveCommand = new Command(async () => await SaveRecipe());
            RemoveCommand = new Command(async () => await RemoveRecipe());
            NewIngredientCommand = new Command(async () => await NewIngredient());
            NewInstructionCommand = new Command(async () => await NewInstruction());
            IngredientDetailCommand = new Command<Ingredient>(async (e) => await IngredientDetail(e));
            InstructionDetailCommand = new Command<Instruction>(async (e) => await InstructionDetail(e));
            StartReadCommand = new Command(async () => await StartRead());
        }
        private async Task NewInstruction()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;
            await PushAsync<InstructionViewModel>(_recipe.Id);
            IsBusy = false;
        }
        private async Task NewIngredient()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;
            await PushAsync<IngredientViewModel>(_recipe.Id);
            IsBusy = false;
        }
        private async Task SaveRecipe()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            _recipe = GetProperties(_recipe);

            if (!(await ValidRecipe(_recipe)))
            {
                IsBusy = false;
                return;
            }

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

            await RecipeDAO.Remove(_recipe);

            await Application.Current.MainPage.Navigation.PopAsync();

            IsBusy = false;
        }
        private async Task IngredientDetail(Ingredient e)
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            await PushAsync<IngredientViewModel>(e);

            IsBusy = false;
        }
        private async Task InstructionDetail(Instruction e)
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            await PushAsync<InstructionViewModel>(e);

            IsBusy = false;
        }
        private async Task<bool> ValidRecipe(Recipe recipe)
        {
            var retorno = true;

            if (recipe.Id == 0 && string.IsNullOrEmpty(recipe.Description))
            {
                retorno = false;
                await DisplayAlert("Error", "Please fill the field Description", "Ok");
            }

            return retorno;
        }
        private async Task StartRead()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            _recipe.Ingredients = Ingredients;
            _recipe.Instructions = Instructions;

            await PushAsync<ReadViewModel>(_recipe);

            IsBusy = false;
        }

        public void RefreshIngredientList()
        {
            if (IngredientDAO.Ingredients(_recipe.Id) is List<Ingredient> ingredients)
            {
                Ingredients = new ObservableCollection<Ingredient>(ingredients);
            }
        }
        public void RefreshInstructionsList()
        {
            if (InstructionDAO.Instructions(_recipe.Id) is List<Instruction> instructions)
            {
                Instructions = new ObservableCollection<Instruction>(instructions);
            }
        }



        #endregion
    }
}

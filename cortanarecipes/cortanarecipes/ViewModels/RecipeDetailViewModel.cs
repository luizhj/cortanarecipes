using cortanarecipes.DataAccess;
using cortanarecipes.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace cortanarecipes.ViewModels
{
    public class RecipeDetailViewModel : RecipeViewModel
    {
        /*
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

        public Command AddIngredientCommand { get; set; }
        public Command AddInstructionCommand { get; set; }
        public Command ViewInstructionsCommand { get; set; }
        public Command EditRecipeCommand { get; set; }
        public Command DeleteRecipeCommand { get; set; }
        public Command ReadRecipeCommand { get; set; }

        private Recipe _recipe { get; set; }
        private ApplicationContext _context { get; set; }

        public RecipeDetailViewModel(int recipeId)
        {
            _recipe = RecipeDAO.Recipe(recipeId);

            FillProperties(_recipe);

            if( new IngredientDAO().Ingredients(_recipe.Id) is List<Ingredient> _ingredients)
            {
                Ingredients = new ObservableCollection<Ingredient>(_ingredients);
            }
            
            if ( new InstructionDAO().Instructions(_recipe.Id) is List<Instruction> _instructions)
            {
                Instructions = new ObservableCollection<Instruction>(_instructions);
            }

            AddIngredientCommand = new Command(async () => await PushAsync<IngredientAddViewModel>(_recipe.Id));
            AddInstructionCommand = new Command(async () => await PushAsync<InstructionAddViewMode>(_recipe.Id));
            ViewInstructionsCommand = new Command(async () => await PushAsync<InstructionsListViewModel>(_recipe.Id));
            EditRecipeCommand = new Command(async () => await PushAsync<RecipeEditViewModel>(_recipe.Id));
            DeleteRecipeCommand = new Command(async () => await DeleteRecipe());
        }

        public async Task DeleteRecipe()
        {
            IsBusy = true;

            RecipeDAO.Remove(_recipe);

            await Application.Current.MainPage.Navigation.PopAsync();
            IsBusy = false;
        }
        */
    }
}

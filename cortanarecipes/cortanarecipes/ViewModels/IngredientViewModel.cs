using cortanarecipes.DataAccess;
using cortanarecipes.Models;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace cortanarecipes.ViewModels
{
    public class IngredientViewModel : BaseViewModel
    {
        #region View properties
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private int _recipeId;
        public int RecipeId
        {
            get { return _recipeId; }
            set { SetProperty(ref _recipeId, value); }
        }

        private int _sequence;
        public int Sequence
        {
            get { return _sequence; }
            set { SetProperty(ref _sequence, value); }
        }

        private string _measure;
        public string Measure
        {
            get { return _measure; }
            set { SetProperty(ref _measure, value); }
        }

        private double _quantity;
        public double Quantity
        {
            get { return _quantity; }
            set { SetProperty(ref _quantity, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        #endregion

        #region View Aux Functions
        private void FillProperties(Ingredient ingredient)
        {
            Id = ingredient.Id;
            RecipeId = ingredient.RecipeId;
            Sequence = ingredient.Sequence;
            Measure = ingredient.Measure;
            Quantity = ingredient.Quantity;
            Name = ingredient.Name;
        }
        private void FillProperties()
        {
            Id = 0;
            Sequence = 0;
            Measure = string.Empty;
            Quantity = 0;
            Name = string.Empty;
        }
        private Ingredient GetProperties(Ingredient ingredient = null)
        {

            if (ingredient == null)
            {
                ingredient = new Ingredient();
            }

            ingredient.Id = Id;
            ingredient.RecipeId = RecipeId;
            ingredient.Sequence = Sequence;
            ingredient.Measure = Measure;
            ingredient.Quantity = Quantity;
            ingredient.Name = Name;

            return ingredient;
        }
        #endregion

        #region Aux Variables
        private IngredientDAO IngredientDAO;
        private Ingredient _ingredient { get; set; }
        #endregion

        #region Buttons Commands
        public Command SaveCommand { get; set; }
        public Command RemoveCommand { get; set; }
        #endregion

        #region Constructors

        // for new ingredient
        public IngredientViewModel(int recipeId)
        {
            RecipeId = recipeId;
            _ingredient = new Ingredient()
            {
                RecipeId = recipeId
            };

            FillProperties();
            InitializeCommands();
        }

        // for edit / remove a ingredient
        public IngredientViewModel(Ingredient ingredient)
        {
            _ingredient = ingredient;

            FillProperties(_ingredient);
            InitializeCommands();
        }
        #endregion

        #region Model Functions
        private void InitializeCommands()
        {
            IngredientDAO = new IngredientDAO();
            SaveCommand = new Command(async () => await SaveIngredient());
            RemoveCommand = new Command(async () => await RemoveIngredient());
        }
        private async Task SaveIngredient()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            _ingredient = GetProperties(_ingredient);

            if (_ingredient.Id == 0)
            {
                IngredientDAO.Add(_ingredient);
            }
            else
            {
                IngredientDAO.Update(_ingredient);
            }

            await Application.Current.MainPage.Navigation.PopAsync();

            IsBusy = false;
        }
        private async Task RemoveIngredient()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            _ingredient = GetProperties(_ingredient);

            IngredientDAO.Remove(_ingredient);

            await Application.Current.MainPage.Navigation.PopAsync();

            IsBusy = false;
        }
        #endregion
    }
}

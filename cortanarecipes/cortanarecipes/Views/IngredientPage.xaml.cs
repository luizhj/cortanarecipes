using cortanarecipes.Models;
using cortanarecipes.ViewModels;
using Xamarin.Forms.Xaml;

namespace cortanarecipes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngredientPage : BasePage
    {

        IngredientViewModel viewModel;

        //  for new ingredient
        public IngredientPage(int recipeId)
        {
            InitializeComponent();
            ToolbarItems.Remove(TollbarItemRemove);
            viewModel = new IngredientViewModel(recipeId);
            BindingContext = viewModel;

        }

        // for edit / remove a ingredient
        public IngredientPage(Ingredient ingredient)
        {
            InitializeComponent();
            viewModel = new IngredientViewModel(ingredient);
            BindingContext = viewModel;
        }
    }
}

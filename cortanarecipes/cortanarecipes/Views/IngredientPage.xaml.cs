using cortanarecipes.Models;
using Xamarin.Forms.Xaml;

namespace cortanarecipes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngredientPage : BasePage
    {
        //  for new ingredient
        public IngredientPage(int recipeId)
        {
            InitializeComponent();
            ToolbarItems.Remove(TollbarItemRemove);
        }

        // for edit / remove a ingredient
        public IngredientPage(Ingredient ingredient)
        {
            InitializeComponent();
        }
    }
}

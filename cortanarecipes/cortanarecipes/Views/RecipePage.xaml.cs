using cortanarecipes.Models;
using Xamarin.Forms.Xaml;

namespace cortanarecipes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipePage : BasePage
    {
        public RecipePage()
        {
            InitializeComponent();

            ToolbarItems.Remove(TollbarItemIngredientsList);
            ToolbarItems.Remove(TollbarItemInstructionsList);
        }
        public RecipePage(Recipe _recipe)
        {
            InitializeComponent();
        }

    }
}

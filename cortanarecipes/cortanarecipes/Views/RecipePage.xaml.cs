using cortanarecipes.ViewModels;
using Xamarin.Forms.Xaml;

namespace cortanarecipes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipePage : BasePage
    {
        RecipeViewModel ViewModel = new RecipeViewModel();

        public RecipePage()
        {
            InitializeComponent();

            BindingContext = ViewModel;
        }
    }
}

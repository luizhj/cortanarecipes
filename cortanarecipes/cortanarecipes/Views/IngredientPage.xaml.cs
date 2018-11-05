using cortanarecipes.ViewModels;
using Xamarin.Forms.Xaml;

namespace cortanarecipes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngredientPage : BasePage
    {
        IngredientViewModel ViewModel = new IngredientViewModel();

        public IngredientPage()
        {
            InitializeComponent();

            BindingContext = ViewModel;
        }
    }
}

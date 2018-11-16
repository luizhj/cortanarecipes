using cortanarecipes.ViewModels;
using Xamarin.Forms.Xaml;

namespace cortanarecipes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipesListPage : BasePage
    {
        // only need to initialize a view model on the view for the that was called from app.xaml.cs on 
        // new NavigationPage(new Page());
        RecipesListViewModel viewModel;

        public RecipesListPage()
        {
            InitializeComponent();

            viewModel = new RecipesListViewModel();
            BindingContext = viewModel;
        }

    }
}

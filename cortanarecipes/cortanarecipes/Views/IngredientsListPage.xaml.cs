using cortanarecipes.Models;
using cortanarecipes.ViewModels;
using Xamarin.Forms.Xaml;

namespace cortanarecipes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngredientsListPage : BasePage
    {
        IngredientsListViewModel viewModel;

        private Recipe _recipe;
        public IngredientsListPage(Recipe recipe)
        {
            InitializeComponent();

            _recipe = recipe;
            viewModel = new IngredientsListViewModel(_recipe);
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.RefreshList();
        }
    }
}

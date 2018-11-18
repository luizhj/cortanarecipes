using cortanarecipes.Models;
using cortanarecipes.ViewModels;
using Xamarin.Forms.Xaml;

namespace cortanarecipes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InstructionsListPage : BasePage
    {
        private Recipe _recipe;

        InstructionsListViewModel viewModel;

        public InstructionsListPage(Recipe recipe)
        {
            InitializeComponent();

            _recipe = recipe;
            viewModel = new InstructionsListViewModel(_recipe);
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.Refreshlist();
        }
    }
}

using cortanarecipes.Models;
using Xamarin.Forms.Xaml;

namespace cortanarecipes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngredientsListPage : BasePage
    {
        public IngredientsListPage(Recipe _recipe)
        {
            InitializeComponent();
        }
    }
}

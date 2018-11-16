using cortanarecipes.Models;
using Xamarin.Forms.Xaml;

namespace cortanarecipes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InstructionsListPage : BasePage
    {
        public InstructionsListPage(Recipe recipe)
        {
            InitializeComponent();
        }
    }
}

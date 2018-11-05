using cortanarecipes.ViewModels;
using Xamarin.Forms.Xaml;

namespace cortanarecipes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InstructionPage : BasePage
    {
        InstructionViewModel ViewModel = new InstructionViewModel();

        public InstructionPage()
        {
            InitializeComponent();

            BindingContext = ViewModel;
        }
    }
}

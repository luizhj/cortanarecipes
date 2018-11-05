using cortanarecipes.ViewModels;
using Xamarin.Forms.Xaml;

namespace cortanarecipes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : BasePage
    {
        MainViewModel ViewModel = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();

            BindingContext = ViewModel;
        }
    }
}

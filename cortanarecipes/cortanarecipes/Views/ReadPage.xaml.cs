using cortanarecipes.Models;
using cortanarecipes.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cortanarecipes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReadPage : BasePage
    {

        ReadViewModel viewModel;

        private Recipe _recipe { get; set; }

        public ReadPage(Recipe recipe)
        {
            InitializeComponent();
            _recipe = recipe;

            viewModel = new ReadViewModel(_recipe)
            {
                Title = "Cooking"
            };
            BindingContext = viewModel;


            if (Device.RuntimePlatform == Device.UWP)
            {
                BtnPrev.FontFamily = "Segoe MDL2 Assets";
                BtnPrev.Text = "\xE76B";
                BtnPrev.Image = null;
                BtnPrev.HeightRequest = 50;
                BtnPrev.WidthRequest= 50;

                BtnStart.FontFamily = "Segoe MDL2 Assets";
                BtnStart.Text = "\xE768";
                BtnStart.Image = null;
                BtnStart.HeightRequest = 50;
                BtnStart.WidthRequest = 50;

                BtnPause.FontFamily = "Segoe MDL2 Assets";
                BtnPause.Text = "\xE769";
                BtnPause.Image = null;
                BtnPause.HeightRequest = 50;
                BtnPause.WidthRequest = 50;

                BtnNext.FontFamily = "Segoe MDL2 Assets";
                BtnNext.Text = "\xE76C";
                BtnNext.Image = null;
                BtnNext.HeightRequest = 50;
                BtnNext.WidthRequest = 50;

                BtnRepeat.FontFamily = "Segoe MDL2 Assets";
                BtnRepeat.Text = "\xE8EE";
                BtnRepeat.Image = null;
                BtnRepeat.HeightRequest = 50;
                BtnRepeat.WidthRequest = 50;
            }

        }
    }
}

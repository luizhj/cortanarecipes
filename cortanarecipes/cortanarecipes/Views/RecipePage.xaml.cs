using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using cortanarecipes.ViewModels;

namespace cortanarecipes.Views : BasePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipePage : ContentPage
    {
        RecipeViewModel ViewModel = new RecipeViewModel();

        public RecipePage()
        {
            InitializeComponent();

            BindingContext = ViewModel;
        }
    }
}

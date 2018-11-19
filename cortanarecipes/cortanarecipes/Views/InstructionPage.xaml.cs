using cortanarecipes.Models;
using cortanarecipes.ViewModels;
using Xamarin.Forms.Xaml;

namespace cortanarecipes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InstructionPage : BasePage
    {
        InstructionViewModel viewModel;

        public InstructionPage(Instruction instruction)
        {
            InitializeComponent();

            viewModel = new InstructionViewModel(instruction);
            BindingContext = viewModel;
        }
        public InstructionPage(int recipeId)
        {
            InitializeComponent();
            ToolbarItems.Remove(ToolbarItemRemove);

            viewModel = new InstructionViewModel(recipeId);
            BindingContext = viewModel;
        }
    }
}

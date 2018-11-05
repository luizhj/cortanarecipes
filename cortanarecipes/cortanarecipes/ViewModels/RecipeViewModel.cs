using cortanarecipes.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace cortanarecipes.ViewModels
{
    public class RecipeViewModel : BaseViewModel
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private string _note;
        public string Note
        {
            get { return _note; }
            set { SetProperty(ref _note, value); }
        }

        private ObservableCollection<Ingredient> _ingredients;
        public ObservableCollection<Ingredient> Ingredients
        {
            get { return _ingredients; }
            set { SetProperty(ref _ingredients, value); }
        }

        private ObservableCollection<Instruction> _instructions;
        public ObservableCollection<Instruction> Instructions
        {
            get { return _instructions; }
            set { SetProperty(ref _instructions, value); }
        }

        public Command NewIngredient { get; set; }
        public Command NewInstruction { get; set; }
        public Command GravarCommand { get; set; }
        public Command LerCommand { get; set; }

    }
}

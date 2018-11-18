using cortanarecipes.DataAccess;
using cortanarecipes.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace cortanarecipes.ViewModels
{
    public class InstructionsListViewModel : BaseViewModel
    {
        #region View properties
        private int _recipeId;
        public int RecipeId
        {
            get { return _recipeId; }
            set { SetProperty(ref _recipeId, value); }
        }

        private string _recipedescription;
        public string RecipeDescription
        {
            get { return _recipedescription; }
            set { SetProperty(ref _recipedescription, value); }
        }

        private string _recipenote;
        public string RecipeNote
        {
            get { return _recipenote; }
            set { SetProperty(ref _recipenote, value); }
        }


        private ObservableCollection<Instruction> _instructions;
        public ObservableCollection<Instruction> Instructions
        {
            get { return _instructions; }
            set { SetProperty(ref _instructions, value); }
        }
        #endregion

        #region Aux variables
        private Recipe _recipe { get; set; }
        private InstructionDAO InstructionDAO { get; set; }
        #endregion

        #region Button Commands
        public Command NewCommand { get; set; }
        public Command EditCommand { get; set; }
        #endregion

        #region Constructors
        public InstructionsListViewModel(Recipe recipe)
        {
            _recipe = recipe;

            InitializeCommands();
            FillProperties(_recipe);
            Refreshlist();
        }
        #endregion

        #region Model functions
        public void Refreshlist()
        {
            if (InstructionDAO.Instructions(RecipeId) is List<Instruction> _instructions)
            {
                Instructions = new ObservableCollection<Instruction>(_instructions);
            }
        }
        private void FillProperties(Recipe recipe)
        {
            RecipeId = recipe.Id;
            RecipeDescription = recipe.Description;
            RecipeNote = recipe.Note;
        }
        private void InitializeCommands()
        {
            InstructionDAO = new InstructionDAO();
            NewCommand = new Command(async () => await NewInstruction());
            EditCommand = new Command<Instruction>(async (e) => await EditInstruction(e));
        }
        private async Task EditInstruction(Instruction e)
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            await PushAsync<InstructionViewModel>(e);

            IsBusy = false;
        }
        private async Task NewInstruction()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            await PushAsync<InstructionViewModel>(RecipeId);

            IsBusy = false;
        }
        #endregion
    }
}

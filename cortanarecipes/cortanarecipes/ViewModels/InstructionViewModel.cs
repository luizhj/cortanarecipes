using cortanarecipes.DataAccess;
using cortanarecipes.Models;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace cortanarecipes.ViewModels
{
    public class InstructionViewModel : BaseViewModel
    {
        #region View Properties
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private int _sequence;
        public int Sequence
        {
            get { return _sequence; }
            set { SetProperty(ref _sequence, value); }
        }

        private int _recipeId;
        public int RecipeId
        {
            get { return _recipeId; }
            set { SetProperty(ref _recipeId, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }
        #endregion

        #region View Aux Functions
        private void FillProperties(Instruction instruction)
        {
            Id = instruction.Id;
            Sequence = instruction.Sequence;
            RecipeId = instruction.RecipeId;
            Description = instruction.Description;
        }
        private Instruction GetProperties(Instruction instruction)
        {
            if (instruction == null)
            {
                instruction = new Instruction();
            }

            instruction.RecipeId = RecipeId;
            instruction.Sequence = Sequence;
            instruction.Description = Description;
            return instruction;
        }
        #endregion

        #region Aux Variables
        private InstructionDAO InstructionDAO;
        private Instruction _instruction;
        #endregion

        #region Button Commands
        public Command SaveCommand { get; set; }
        public Command RemoveCommand { get; set; }
        #endregion

        #region Constructors
        public InstructionViewModel(Instruction instruction)
        {
            _instruction = instruction;
            FillProperties(_instruction);
            InitializeCommands();
        }

        public InstructionViewModel(int recipeId)
        {
            RecipeId = recipeId;
            InitializeCommands();
        }
        #endregion

        #region Model Functions
        private void InitializeCommands()
        {
            InstructionDAO = new InstructionDAO();
            SaveCommand = new Command(async () => await Save());
            RemoveCommand = new Command(async () => await Remove());
        }
        private async Task Save()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            _instruction = GetProperties(_instruction);

            if (_instruction.Id == 0)
            {
                InstructionDAO.Add(_instruction);
            }
            else
            {
                InstructionDAO.Update(_instruction);
            }

            await Application.Current.MainPage.Navigation.PopAsync();
            IsBusy = false;

        }
        private async Task Remove()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            InstructionDAO.Remove(_instruction);

            await Application.Current.MainPage.Navigation.PopAsync();

            IsBusy = false;
        }
        #endregion

    }
}

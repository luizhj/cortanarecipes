using cortanarecipes.DataAccess;
using cortanarecipes.Models;
using System.Collections.ObjectModel;

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

        public void FillProperties(Instruction instruction)
        {
            Id = instruction.Id;
            Sequence = instruction.Sequence;
            RecipeId = instruction.RecipeId;
            Description = instruction.Description;
        }

        public InstructionDAO InstructionDAO;

        public InstructionViewModel()
        {
            InstructionDAO = new InstructionDAO();
        }

    }
}

using Xamarin.Forms;

namespace cortanarecipes.ViewModels
{
    public class InstructionViewModel : BaseViewModel
    {

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

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public Command GravarCommand { get; set; }
    }
}

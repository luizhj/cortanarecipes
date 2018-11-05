using Xamarin.Forms;

namespace cortanarecipes.ViewModels
{
    public class IngredientViewModel : BaseViewModel
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

        private double _quantity;
        public double Quantity
        {
            get { return _quantity; }
            set { SetProperty(ref _quantity, value); }
        }

        private string _measure;
        public string Measure
        {
            get { return _measure; }
            set { SetProperty(ref _measure, value); }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public Command GravarCommand { get; set; }
    }
}

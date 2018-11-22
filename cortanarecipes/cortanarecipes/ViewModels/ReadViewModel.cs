using cortanarecipes.Helpers;
using cortanarecipes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace cortanarecipes.ViewModels
{
    public class ReadViewModel : BaseViewModel
    {
        private Recipe _recipe { get; set; }

        private string _speakText;
        public string SpeakText
        {
            get { return _speakText; }
            set { SetProperty(ref _speakText, value); }
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

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private bool _isPaused;
        public bool IsPaused
        {
            get { return _isPaused; }
            set { SetProperty(ref _isPaused, value); }
        }

        private bool _isPlaying;
        public bool IsPlaying
        {
            get { return _isPlaying; }
            set { SetProperty(ref _isPlaying, value); }
        }

        public Command StartCommand { get; set; }
        public Command PauseCommand { get; set; }
        public Command RepeatCommand { get; set; }
        public Command NextCommand { get; set; }
        public Command PreviousCommand { get; set; }

        private ReadVM _item { get; set; }
        private List<ReadVM> _readitens { get; set; }
        private List<Ingredient> _ingredients { get; set; }
        private List<Instruction> _instructions { get; set; }
        private int _sequence { get; set; }

        public ReadViewModel(Recipe recipe)
        {
            _recipe = recipe;
            _ingredients = _recipe.Ingredients.OrderBy(p => p.Sequence).ToList();
            _instructions = _recipe.Instructions.OrderBy(p => p.Sequence).ToList();

            IsPlaying = false;
            IsPaused = true;
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            StartCommand = new Command(Start);

            _readitens = TranslateIngredients(_readitens);
            _readitens = TranslateInstructions(_readitens);

        }

        private List<ReadVM> TranslateIngredients(List<ReadVM> readItens)
        {
            if (readItens == null)
            {
                readItens = new List<ReadVM>();
            }

            var sequence = 0;

            foreach (var item in _ingredients)
            {
                sequence++;
                readItens.Add(new ReadVM()
                {
                    Sequence = sequence,
                    Type = Type.Ingredient,
                    Measure = item.Measure,
                    Description = item.Name,
                    Quantity = item.Quantity
                });
            }

            return readItens;

        }

        private List<ReadVM> TranslateInstructions(List<ReadVM> readItens)
        {
            if (readItens == null)
            {
                readItens = new List<ReadVM>();
            }

            var sequence = readItens.Last().Sequence;

            foreach (var item in _instructions)
            {
                sequence++;
                readItens.Add(new ReadVM()
                {
                    Sequence = sequence,
                    Description = item.Description
                });
            }

            return readItens;

        }

        private void Start()
        {
            if (_sequence == 0)
            {
                _sequence = 1;
            }

            play();

            _item = _readitens.Skip(_sequence - 1).Take(1).FirstOrDefault();

            Speak(_item);
            
        }

        private void Speak(ReadVM _item)
        {
            SpeakText = _item.ToString();
            Quantity = _item.Quantity;
            Measure = _item.Measure;
            Description = _item.Description;

            DependencyService.Get<ITextToSpeech>().Speak(SpeakText);
            
        }

        private void play()
        {
            IsPlaying = true;
            IsPaused = false;
        }

        private void stop()
        {
            IsPlaying = false;
            IsPaused = true;
        }
    }
}

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DivineTool64.Models;
using DivineTool64.Services;

namespace DivineTool64.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly YaoService _yaoService = new();
        private readonly HexagramService _hexagramService = new();

        public ObservableCollection<Yao> Yaos { get; } = new();

        private string _resultText;
        public string ResultText
        {
            get => _resultText;
            set { _resultText = value; OnPropertyChanged(); }
        }

        public ICommand DrawYaoCommand => new RelayCommand(DrawYao);
        public ICommand ResetCommand => new RelayCommand(Reset);

        private void DrawYao()
        {
            if (Yaos.Count >= 6) return;

            Yaos.Add(_yaoService.GenerateYao());

            if (Yaos.Count == 6)
            {
                var hex = _hexagramService.GetHexagram(Yaos.ToList());
                ResultText = $"{hex.Name}\n\n{hex.Judgment}";
            }
        }

        private void Reset()
        {
            Yaos.Clear();
            ResultText = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
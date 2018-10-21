using Micromania.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Presentation.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        private Purchase _selectedGame;

        public GameViewModel()
        {
            Games = new ObservableCollection<Purchase>();
        }
        public ObservableCollection<Purchase> Games { get; set; }

        public Purchase SelectedGame
        {
            get { return _selectedGame; }
            set
            {
                _selectedGame = value;
                OnPropertyChanged();
            }
        }
    }
}

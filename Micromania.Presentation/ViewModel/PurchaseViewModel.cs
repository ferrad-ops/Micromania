using Micromania.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Presentation.ViewModel
{
    public class PurchaseViewModel : ViewModelBase
    {
        private Purchase _selectedPurchase;

        public PurchaseViewModel()
        {
            Games = new ObservableCollection<Purchase>();
        }
        public ObservableCollection<Purchase> Games { get; set; }

        public Purchase SelectedGame
        {
            get { return _selectedPurchase; }
            set
            {
                _selectedPurchase = value;
                OnPropertyChanged();
            }
        }
    }
}

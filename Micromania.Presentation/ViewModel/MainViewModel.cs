using Micromania.Console;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Presentation.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Client _selectedClient;

        public ObservableCollection<Client> Clients { get; set; }

        public MainViewModel()
        {
            Clients = new ObservableCollection<Client>();
        }

        public Client SelectedFriend
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged();
            }
        }
    }
}

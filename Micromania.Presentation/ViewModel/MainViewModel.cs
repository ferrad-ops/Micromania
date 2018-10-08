using Micromania.Console;
using Micromania.Presentation.Data;
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
        private IClientDataService _clientDataService;
        private Client _selectedClient;

        public ObservableCollection<Client> Clients { get; set; }

        public MainViewModel(IClientDataService clientDataService)
        {
            Clients = new ObservableCollection<Client>();
            _clientDataService = clientDataService;
        }

        public void Load(IClientDataService clientDataService)
        {
            var clients = clientDataService.GetAll();

            Clients.Clear();

            foreach (var item in clients)
            {
                Clients.Add(item);
            }
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

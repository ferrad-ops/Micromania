using Micromania.Domain;
using Micromania.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Presentation.ViewModel
{
    public class OfficeViewModel : ViewModelBase
    {
        private readonly ClientRepository _clientRepository;

        private ObservableCollection<Client> clients;

        public ObservableCollection<Client> Clients
        {
            get { return clients; }
            private set
            {
                clients = value;
                OnPropertyChanged();
            }
        }

        public Client SelectedClient { get; set; }

        private string _message = "";
        public string Message
        {
            get { return _message; }
            private set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public OfficeViewModel()
        {
            _clientRepository = new ClientRepository();
            Clients = new ObservableCollection<Client>(_clientRepository.GetAll());
        }

        private void Create()
        {
            //Client client = Client.Create(firstName, lastName);

            //_clientRepository.Save(client);
        }

        private void Delete()
        {
            if (SelectedClient == null)
            {
                NotifyClient("Veuillez choisir un client.");
                return;
            }

            _clientRepository.Delete(SelectedClient.Id);
            NotifyClient($"Vous avez supprimé le client ");
        }

        private void NotifyClient(string message)
        {
            Message = message;
            OnPropertyChanged(nameof(Clients));

        }
    }
}



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
    public class CrudViewModel : ViewModelBase
    {
        private IMsgBoxService messageService;
        private Client _selectedClient;
        private readonly ClientRepository _clientRepository;        

        public CrudViewModel(IMsgBoxService msgboxService)
        {
            messageService = msgboxService;

            _clientRepository = new ClientRepository();

            CreateCommand = new Command(() => Create());
            LoadCommand = new Command(() => Read());
            UpDateCommand = new Command(() => Update());
            DeleteCommand = new Command(() => Delete());

            Clients = new ObservableCollection<Client>();
        }

        private void Create()
        {
            SelectedClient = null;

            var client = Client.Create(FirstName, LastName);

            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
            {
                messageService.ShowNotification($"Veuillez entrer un nom et/ou un prénom.");
                return;
            }
            else
                messageService.ShowNotification($"Le Client '{FirstName} {LastName}' a été enregistré avec succès");

            Clients.Add(client);

            _clientRepository.Add(client);

            Read();
        }

        private void Read()
        {
            var list = _clientRepository.GetAll();

            Clients.Clear();

            foreach (var item in list)
            {
                Clients.Add(item);
            }
        }

        private void Update()
        {
            if (SelectedClient == null)
            {
                messageService.ShowNotification($"Veuillez choisir un client.");
                return;
            }

            _clientRepository.Save(SelectedClient);
            messageService.ShowNotification($"Informations mises à jour.");
            Read();
        }

        private void Delete()
        {
            if (SelectedClient == null)
            {
                messageService.ShowNotification($"Veuillez choisir un client.");
                return;
            }

            messageService.AskForConfirmation($"Voulez vous supprimer '{SelectedClient.FirstName} {SelectedClient.LastName}' ?");
            messageService.ShowNotification($"Le client '{SelectedClient.FirstName} {SelectedClient.LastName}' a bien été supprimé.");
            _clientRepository.Delete(SelectedClient.Id);
            Read();
        }

        public Client SelectedClient
        {
            get { return _selectedClient; }
            set { _selectedClient = value;
                OnPropertyChanged();
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
        public Command CreateCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public Command LoadCommand { get; set; }
        public Command UpDateCommand { get; set; }
    }
}

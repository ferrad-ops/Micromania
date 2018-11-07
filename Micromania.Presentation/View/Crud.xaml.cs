using Micromania.Domain;
using Micromania.Infrastructure;
using Micromania.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Micromania.Presentation.View
{
    /// <summary>
    /// Interaction logic for Crud.xaml
    /// </summary>
    public partial class Crud : Window
    {
        private readonly ClientRepository _clientRepository;

        public ObservableCollection<Client> Clients { get;}
        public Client SelectedClient { get; set; }

        public Crud()
        {
            InitializeComponent();
            _clientRepository = new ClientRepository();
            Clients = new ObservableCollection<Client>();
            //_items = new ObservableCollection<Client>(_clientRepository.GetClientList());
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var firstName = firstname.Text;
            var lastName = lastname.Text;

            if (string.IsNullOrWhiteSpace(firstname.Text) || string.IsNullOrWhiteSpace(lastname.Text))
            {
                MessageBox.Show($"Veuillez entrer un nom et/ou un prénom.");
                return;
            }
            else
                MessageBox.Show($"Le Client '{firstname.Text} {lastname.Text}' a été enregistré avec succès");

            Client client = Client.Create(firstName, lastName);

            Clients.Add(client);
            _clientRepository.Save(client);           
        }

        private void RefreshItems()
        {
            var list = _clientRepository.GetAll();

            Clients.Clear();

            // Display all the elements of the list at the given time
            foreach (var item in list)
            {
                Clients.Add(item);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RefreshItems();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if(SelectedClient == null)
            {
                MessageBox.Show($"Veuillez choisir un client.");
                return;
            }

            MessageBox.Show($"Le client '{SelectedClient.FirstName} {SelectedClient.LastName}' a bien été supprimé.");

            _clientRepository.Delete(SelectedClient.Id);
            RefreshItems();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SelectedClient.FirstName = firstname.Text;
            
            SelectedClient.LastName = lastname.Text;

            _clientRepository.Save(SelectedClient);
        }
    }
}

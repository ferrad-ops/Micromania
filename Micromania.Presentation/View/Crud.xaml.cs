using Micromania.Domain;
using Micromania.Infrastructure;
using Micromania.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private readonly ObservableCollection<Client> Clients;

        public Crud()
        {
            InitializeComponent();
            _clientRepository = new ClientRepository();
            Clients = new ObservableCollection<Client>();
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
            
            _clientRepository.Save(client);

            Clients.Add(client);
        }
    }
}

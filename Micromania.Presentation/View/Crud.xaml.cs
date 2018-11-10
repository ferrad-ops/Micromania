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
    public partial class Crud : Window
    {
        private readonly CrudViewModel _crudViewModel;

        public Crud()
        {
            InitializeComponent();
            _crudViewModel = new CrudViewModel(new MsgBoxService());
            DataContext = _crudViewModel;            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }        
    }
}

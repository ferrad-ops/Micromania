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
        public MainViewModel()
        {
            var viewmodel = new ClientViewModel(new Client());            
        }
    }
}

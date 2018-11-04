using Micromania.Domain;
using Micromania.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Presentation.ViewModel
{
    public class CrudViewModel : ViewModelBase
    {
        private readonly ClientRepository _clientRepository;
        
        public CrudViewModel()
        {
            _clientRepository = new ClientRepository();
        }
    }
}

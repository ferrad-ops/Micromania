using Micromania.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Presentation.ViewModel
{
    public class ClientViewModel : ViewModelBase
    {
        private readonly Client _client;
        private readonly ClientRepository _repository;

        public ClientViewModel(Client client)
        {
            _client = client;
            _repository = new ClientRepository();
        }

        private void BuyGame(Purchase game)
        {
            _client.BuyGame(game);
            _repository.Save(_client);
            //NotifyClient("You have bought a snack");
        }
    }
}

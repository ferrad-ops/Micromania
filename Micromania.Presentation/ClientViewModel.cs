using Micromania.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Presentation
{
    public class ClientViewModel
    {
        private readonly Client _client;

        public ClientViewModel(Client client)
        {
            client = _client;
        }

        public void BuyGame(Game game)
        {
            _client.BuyGame(game);
        }
    }
}

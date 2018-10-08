
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Boostrapper.Initialize();

            SessionFactory.Init("Server=DESKTOP-H9JQ47G;Database=Micromania;Trusted_Connection=True;");

            var repository = new ClientRepository();

            //Client client = repository.GetById(1);

            var client = Client.Create("Ferrad", "Rosé");
            var client1 = Client.Create("Mael", "LaRochelle");
            var client2 = Client.Create("Précieux", "Rajiv");
            var client3 = Client.Create("Carmel", "Taty");

            client.AddMoney(Money.Ten);
            client.AddMoney(Money.Hundred);
            client.AddMoney(Money.Hundred);
            client.AddMoney(Money.Hundred);
            client.AddMoney(Money.Hundred);
            client.AddMoney(Money.Hundred);
            client1.AddMoney(Money.Hundred);
            client2.AddMoney(Money.Hundred);
            client3.AddMoney(Money.Hundred);

            client.BuyGame(Game.Uncharted);
            client.BuyGame(Game.Uncharted);
            client.BuyGame(Game.Uncharted);
            client.BuyGame(Game.Uncharted);
            client.BuyGame(Game.Uncharted);
            client.BuyGame(Game.Uncharted);
            client.BuyGame(Game.Uncharted);
            client.BuyGame(Game.Uncharted);
            
            client1.BuyGame(Game.Uncharted2);
            client2.BuyGame(Game.Uncharted4);
            client3.BuyGame(Game.Uncharted);

            repository.Save(client);
            repository.Save(client1);
            repository.Save(client2);
            repository.Save(client3);

        }      
    }
}

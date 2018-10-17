
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
            var repository1 = new GameRepository();

            //Client client = repository.GetById(1);

            Client client = Client.Ferrad;
            Client client1 = Client.Mael;
            Client client2 = Client.Precieux;
            Client client3 = Client.Carmel;

            Game game = Game.Uncharted;
            Game game1 = Game.Uncharted2;
            Game game2 = Game.Uncharted4;

            client.AddMoney(Money.Ten);
            client.AddMoney(Money.Hundred);
            client.AddMoney(Money.Hundred);
            client.AddMoney(Money.Hundred);
            client.AddMoney(Money.Hundred);
            client.AddMoney(Money.Hundred);
            client1.AddMoney(Money.Hundred);
            client2.AddMoney(Money.Hundred);
            client3.AddMoney(Money.Hundred);

            client.BuyGame(game2);
            client.BuyGame(game2);
            client.BuyGame(game2);
            client.BuyGame(game2);
            client.BuyGame(game2);
            client.BuyGame(game2);
            client.BuyGame(game2);
            client.BuyGame(game2);            

            client1.BuyGame(game1);
            client2.BuyGame(game2);
            client3.BuyGame(game);

            repository.Save(client);
            repository.Save(client1);
            repository.Save(client2);
            repository.Save(client3);

            repository1.Save(game);
            repository1.Save(game1);
            repository1.Save(game2);
        }      
    }
}

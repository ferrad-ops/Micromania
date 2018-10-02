
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

            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var client = Client.Create("Ferrad", "Rosé");
                    var client1 = Client.Create("Mael", "LaRochelle");
                    var client2 = Client.Create("Précieux", "Rajiv");
                    var client3 = Client.Create("Carmel", "Taty");

                    var game = new Game("Uncharted", 15M);
                    var game1 = new Game("Uncharted 2", 20M);
                    var game2 = new Game("Uncharted 4", 59M);

                    client.AddMoney(Money.Ten);
                    client.AddMoney(Money.Hundred);
                    client.AddMoney(Money.Hundred);
                    client.AddMoney(Money.Hundred);
                    client.AddMoney(Money.Hundred);
                    client.AddMoney(Money.Hundred);
                    client1.AddMoney(Money.Hundred);
                    client2.AddMoney(Money.Hundred);
                    client3.AddMoney(Money.Hundred);


                    client.BuyGame(game);                    
                    client.BuyGame(game);
                    client.BuyGame(game);
                    client.BuyGame(game);
                    client.BuyGame(game);
                    client.BuyGame(game);
                    client.BuyGame(game);
                    client.BuyGame(game);
                    client.BuyGame(game);
                    client1.BuyGame(game1);
                    client2.BuyGame(game2);
                    client3.BuyGame(game1);

                    session.SaveOrUpdate(client);
                    session.SaveOrUpdate(client1);
                    session.SaveOrUpdate(client2);
                    session.SaveOrUpdate(client3);

                    session.SaveOrUpdate(game);
                    session.SaveOrUpdate(game1);
                    session.SaveOrUpdate(game2);
                    
                    transaction.Commit();
                }
            }
        }      
    }
}

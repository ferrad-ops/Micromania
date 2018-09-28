
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
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var client = Client.Create("Ferrad", "Rosé");
                    var client1 = Client.Create("Mael", "LaRochelle");
                    var client2 = Client.Create("Armel", "Taty");
                    var client3 = Client.Create("Carmel", "Taty");

                    var game = new Game("Uncharted", 15);
                    var game1 = new Game("Uncharted 2", 20);
                    var game2 = new Game("Uncharted 4", 59.99);                    

                    client.BuyGame(game);                    
                    client.BuyGame(game);
                    client.BuyGame(game);
                    client.BuyGame(game);
                    client1.BuyGame(game1);
                    client2.BuyGame(game2);
                    client3.BuyGame(game1);

                    //client.BuyGameWithPoints(game);

                    System.Console.WriteLine($"{client.FirstName} has {client.Points} points");
                    System.Console.WriteLine($"{game2.Title} has {game2.Points} points");

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

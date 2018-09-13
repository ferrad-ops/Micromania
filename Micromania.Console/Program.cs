
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
                    var client = Client.Create("Ferrad", "Rosé", Card.Create(CardType.Classic));
                    var client1 = Client.Create("Mael", "LaRochelle", Card.Create(CardType.Classic));
                    var client2 = Client.Create("Armel", "Taty", Card.Create(CardType.Classic));
                    var client3 = Client.Create("Carmel", "Taty", Card.Create(CardType.Classic));

                    var game = new Game("Uncharted", 15);
                    var game1 = new Game("Uncharted 2", 2000);
                    var game2 = new Game("Uncharted 4", 59.99);

                    client.NewLevelReached += Client_NewLevelReached;

                    client.BuyGame(game);
                    client.BuyGame(game1);
                    client.BuyGame(game2);

                    //client.BuyGameWithPoints(game);

                    System.Console.WriteLine($"{client.FirstName} has {client.Card.Points} points");
                    System.Console.WriteLine($"{game2.Title} has {game2.Points} points");

                    session.SaveOrUpdate(client);
                    session.SaveOrUpdate(client1);
                    session.SaveOrUpdate(client2);

                    session.SaveOrUpdate(game);
                    session.SaveOrUpdate(game1);
                    session.SaveOrUpdate(game2);
                   
                    transaction.Commit();
                }
            }
        }

        protected static void Client_NewLevelReached(object sender, EventArgs e)
        {
            System.Console.WriteLine($"You reached level {CardType.Premium}");
        }        
    }
}

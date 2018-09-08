
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
            var client = Client.Create("Ferrad", "Rosé", Card.Create(CardType.Classic, new Points()));

            var game = new Game(new Points(10));
            var game1 = new Game(new Points(15));
            var game2 = new Game(new Points(25));

            client.NewLevelReached += Client_NewLevelReached;

            client.BuyGame(game);
            client.BuyGame(game1);
            client.BuyGame(game2);

            System.Console.WriteLine($"{client.FirstName} has {client.Card.Points.TotalPoints} points");
        }

        private static void Client_NewLevelReached(object sender, EventArgs e)
        {
            System.Console.WriteLine($"You reached level {CardType.Premium}");
        }        
    }
}


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
            var client = Client.Create("Ferrad", "Rosé", Card.Create(CardType.Classic));

            var game = new Game("Uncharted",15);
            var game1 = new Game("Uncharted 2",20);
            var game2 = new Game("Uncharted 4",59.99M);

            client.NewLevelReached += Client_NewLevelReached;

            client.BuyGame(game);
            client.BuyGame(game1);
            client.BuyGame(game2);

            System.Console.WriteLine($"{client.FirstName} has {client.Card.Points} points");
            System.Console.WriteLine($"{game2.Title} has {game2.Points} points");
        }

        private static void Client_NewLevelReached(object sender, EventArgs e)
        {
            System.Console.WriteLine($"You reached level {CardType.Premium}");
        }        
    }
}

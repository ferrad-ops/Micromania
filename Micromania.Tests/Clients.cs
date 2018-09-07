using Micromania.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Micromania.Tests
{
    public class Clients
    {
        [Fact]
        public void Points_Increase_After_Buying__A_Game()
        {
            var client = Client.Create("ferrad", "Rosé", new Card());

            var game = new Game();

            game.Points = 10;

            client.BuyGame(game);

            Assert.Equal(client.Card.Points, game.Points);           
        }
    }
}

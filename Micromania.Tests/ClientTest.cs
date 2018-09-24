using Micromania.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Micromania.Tests
{
    public class ClientTest
    {
        [Fact]
        public void RaiseNewLevelReachedEvent()
        {
            var client = Client.Create("Keith", "Derid", Card.Create(CardType.Classic));
            var game = new Game("Uncharted", 1500);

            Assert.Raises<EventArgs>(
                handler => client.NewLevelReached += handler, 
                handler => client.NewLevelReached += handler, 
                () => client.BuyGame(game));
        }
    }
}

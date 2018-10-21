
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Micromania.Domain;
using NHibernate;
using Xunit;

namespace Micromania.Tests
{
    public class ClientTest
    {
        [Fact]
        public void ClientAddsMoney()
        {
            //Boostrapper.Initialize();

            SessionFactory.Init("Server=DESKTOP-H9JQ47G;Database=Micromania;Trusted_Connection=True;");

            using (ISession session = SessionFactory.OpenSession())
            {                
                long id = 1;
                var client = session.Get<Client>(id);                
            }



            //var repository = new ClientRepository();
            //var repository1 = new GameRepository();

            //Client client = Client.Ferrad;

            //Client client = repository.GetById(1);

            //client.AddMoney(Money.Ten);
            //client.AddMoney(Money.Hundred);

            //repository.Save(client);

            //Assert.Equal(110, client.MoneyInWallet);

            //Game game = Game.Uncharted;
            //Game game1 = Game.Uncharted2;
            //Game game2 = Game.Uncharted4;

            //client.BuyGame(game2);
            //client.BuyGame(game2);           

            //repository.Save(client);            

            //repository1.Save(game);
            //repository1.Save(game1);
            //repository1.Save(game2);
        }
    }
}

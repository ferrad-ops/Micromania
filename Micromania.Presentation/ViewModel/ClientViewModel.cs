using Micromania.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Presentation.ViewModel
{
    public class ClientViewModel : ViewModelBase
    {
        private readonly Client _client;

        private readonly ClientRepository _repository;

        public string MoneyInWallet => _client.MoneyInWallet.ToString();

        public Command BuyGameCommand { get; private set; }
        public Command AddMoneyCommand { get; private set; }

        public ObservableCollection<Game> Games { get; }
        public ObservableCollection<MoneyModel> MoneyAmounts { get; }
        public MoneyModel SelectedMoneyAmount { get; set; }
        public Game SelectedGame { get; set; }

        public ClientViewModel()
        {
            _client = Client.Ferrad;

            _repository = new ClientRepository();

            BuyGameCommand = new Command(() => BuyGame(SelectedGame));
            AddMoneyCommand = new Command(() => AddMoney());

            Games = new ObservableCollection<Game>(new[] { Game.Uncharted, Game.Uncharted2, Game.Uncharted4 });

            MoneyAmounts = new ObservableCollection<MoneyModel>(new[] { new MoneyModel("10 €", Money.Ten), new MoneyModel("25 €", Money.TwentyFive),
                new MoneyModel("50 €", Money.Fifty), new MoneyModel("100 €", Money.Hundred)});
        }

        private void BuyGame(Game game)
        {
            _client.BuyGame(game);
            _repository.Save(_client);
            OnPropertyChanged("MoneyInWallet");
        }

        private void AddMoney()
        {
            _client.AddMoney(SelectedMoneyAmount.Value);
            _repository.Save(_client);
            OnPropertyChanged("MoneyInWallet");
        }

        public class MoneyModel
        {
            public MoneyModel(string name, Money value)
            {
                Name = name;
                Value = value;
            }

            public string Name { get; }
            public Money Value { get; }
        }
    }
}

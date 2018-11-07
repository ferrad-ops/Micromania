using Micromania.Domain;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Catel;
using Catel.MVVM;
using Catel.Collections;
using Micromania.Infrastructure;

namespace Micromania.Presentation.ViewModel
{
    public class ClientViewModel : ViewModelBase
    {
        public ClientViewModel()
        {
            _repository = new ClientRepository();

            BuyGameCommand = new Command(() => BuyGame(SelectedGame));
            AddMoneyCommand = new Command(() => AddMoney());
            BuyGameWithBonusCommand = new Command(() => UseBonus(SelectedGame));
            AddBonusToWalletCommand = new Command(() => AddBonusToWallet());
            ChooseClientCommand = new Command(() => ChooseClient());

            Games = new ObservableCollection<Game>(new[] { Game.CBC, Game.Uncharted, Game.Uncharted2, Game.Uncharted4, Game.GOW, Game.MGS });

            Clients = new List<Client>(_repository.GetAll());

            MoneyAmounts = new FastObservableCollection<MoneyModel>(new[] { new MoneyModel("$ 10", Money.Ten), new MoneyModel("$ 25", Money.TwentyFive),
                new MoneyModel("$ 50", Money.Fifty), new MoneyModel("$ 100", Money.Hundred)});

        }

        private void BuyGame(Game game)
        {
            string error = SelectedClient.CanBuyGame(game);

            if (error != string.Empty)
            {
                NotifyClient(error);
                return;
            }

            SelectedClient.BuyGame(game);
            _repository.Save(SelectedClient);
            NotifyClient("Vous avez acheté un jeu.");
        }

        private string CanAddMoney()
        {
            if (SelectedMoneyAmount == null)
                return "Veuillez choisir un montant.";
            return string.Empty;
        }

        private void AddMoney()
        {
            string error = CanAddMoney();

            if (error != string.Empty)
            {
                NotifyClient(error);
                return;
            }

            SelectedClient.AddMoney(SelectedMoneyAmount.Value);
            _repository.Save(SelectedClient);
            NotifyClient($"Vous avez ajouté {SelectedMoneyAmount.Name.ToString()}");
        }

        private void UseBonus(Game game)
        {
            string error = SelectedClient.CanUseBonus(game);

            if (error != string.Empty)
            {
                NotifyClient(error);
                return;
            }

            SelectedClient.UseBonus(game);
            _repository.Save(SelectedClient);
            NotifyClient("Vous avez utilisé un bon d'achat.");
        }

        private void AddBonusToWallet()
        {
            //string error = _client.CanAddBonusToWallet();
            string error = SelectedClient.CanAddBonusToWallet();

            if (error != string.Empty)
            {
                NotifyClient(error);
                return;
            }

            var amount = Bonus;
            SelectedClient.AddBonusToWallet();
            _repository.Save(SelectedClient);
            NotifyClient($"Porte-monnaie approvisionné de ${amount}");
        }

        private void ChooseClient()
        {
            SelectedClient = _repository.GetById(SelectedClient.Id);
            NotifyClient($"Bienvenue {SelectedClient.FirstName} ! ");
        }

        private void NotifyClient(string message)
        {
            Message = message;
            OnPropertyChanged(nameof(MoneyInWallet));
            OnPropertyChanged(nameof(Points));
            OnPropertyChanged(nameof(QualifyingPurchases));
            OnPropertyChanged(nameof(Status));
            OnPropertyChanged(nameof(Bonus));
        }

        private readonly ClientRepository _repository;

        private string _message = "";
        public string Message
        {
            get { return _message; }
            private set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public decimal MoneyInWallet => SelectedClient.MoneyInWallet;
        public string Points => SelectedClient.Points.ToString();
        public int QualifyingPurchases => SelectedClient.QualifyingPurchases;
        public string Status => SelectedClient.Status.ToString();
        public decimal Bonus => SelectedClient.Bonus;

        public Command BuyGameCommand { get; private set; }
        public Command AddMoneyCommand { get; private set; }
        public Command BuyGameWithBonusCommand { get; private set; }
        public Command AddBonusToWalletCommand { get; private set; }
        public Command ChooseClientCommand { get; private set; }
        public ObservableCollection<Game> Games { get; }
        public FastObservableCollection<MoneyModel> MoneyAmounts { get; }
        public MoneyModel SelectedMoneyAmount { get; set; }
        public Game SelectedGame { get; set; }
        public List<Client> Clients { get; set; }
        public Client SelectedClient { get; set; }

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

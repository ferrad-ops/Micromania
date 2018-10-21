using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Collections;
using Catel.MVVM;
using Micromania.Domain;
using ReactiveUI;
using ReactiveUI.Legacy;

namespace Micromania.WPF.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        public ShellViewModel()
        {
            var canBuyExecute = this.WhenAny(vm => vm.SelectedGame, model => model.Value != null);
            var canAddMoneyExecute = this.WhenAny(vm => vm.SelectedMoneyAmount, model => model.Value != null);

            Buy = ReactiveCommand.CreateFromTask(OnBuyExecuteAsync, canBuyExecute);
            AddMoney = ReactiveCommand.CreateFromTask(OnAddMoneyExecuteAsync, canAddMoneyExecute);

            Games = new FastObservableCollection<Purchase>(new[] { Purchase.Uncharted, Purchase.Uncharted2, Purchase.Uncharted4 });

            MoneyAmounts = new FastObservableCollection<MoneyModel>(new[] { new MoneyModel("10 €", Money.Ten), new MoneyModel("25 €", Money.TwentyFive),
                new MoneyModel("50 €", Money.Fifty), new MoneyModel("100 €", Money.Hundred)});

            _client = Client.Precieux;
        }

        private Task OnAddMoneyExecuteAsync()
        {

            _client.AddMoney(SelectedMoneyAmount.Value);

            return Task.CompletedTask;
        }

        private Task OnBuyExecuteAsync()
        {
            return Task.CompletedTask;
        }

        public override string Title => "Micromania";
        public ReactiveCommand Buy { get; }
        public ReactiveCommand AddMoney { get; }

        public FastObservableCollection<Purchase> Games { get; }
        public Purchase SelectedGame { get; set; }

        public FastObservableCollection<MoneyModel> MoneyAmounts { get; }

        private readonly Client _client;

        public MoneyModel SelectedMoneyAmount { get; set; }
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

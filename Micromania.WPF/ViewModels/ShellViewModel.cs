using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Collections;
using Catel.MVVM;
using Micromania.Console;
using ReactiveUI;
using ReactiveUI.Legacy;

namespace Micromania.WPF.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        public ShellViewModel()
        {
            var canBuyExecute = this.WhenAny(vm => vm.SelectedGame, model => model.Value != null);

            Buy = ReactiveCommand.CreateFromTask(OnBuyExecuteAsync, canBuyExecute);

            Games = new FastObservableCollection<Game>(new[] { Game.Uncharted, Game.Uncharted2, Game.Uncharted4 });
        }

        private Task OnBuyExecuteAsync()
        {
            return Task.CompletedTask;
        }

        public override string Title => "Micromania";
        public ReactiveCommand Buy { get; }

        public FastObservableCollection<Game> Games { get; }
        public Game SelectedGame { get; set; }
    }
}

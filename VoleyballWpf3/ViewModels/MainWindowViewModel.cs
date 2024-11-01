using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VoleyballWpf3.Infrastructure.Commands;
using VoleyballWpf3.ViewModels.Base;

namespace VoleyballWpf3.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region ЗАГОЛОВОК ОКНА

        private string _Title = "Организация Турниров По Волейболу";
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion

        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowLoginViewCommand { get; }
        public ICommand ShowTeamsViewCommand { get; }
        public ICommand ShowMatchesViewCommand { get; }
        public ICommand ShowEditMatchViewCommand { get; }

        #region КОМАНДЫ

        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        #endregion

        public MainWindowViewModel()
        {
            ShowLoginViewCommand = new LambdaCommand(o => CurrentView = new LoginViewModel());
            ShowTeamsViewCommand = new LambdaCommand(o => CurrentView = new TeamsViewModel());
            ShowMatchesViewCommand = new LambdaCommand(o => CurrentView = new GamesViewModel());
            //ShowEditMatchViewCommand = new LambdaCommand(o => CurrentView = new EditMatchViewModel());
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            CurrentView = new LoginViewModel(); // Default view
        }
    }
}

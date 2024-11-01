using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VoleyballWpf3.Infrastructure.Commands;
using VoleyballWpf3.Infrastructure;
using VoleyballWpf3.Models;
using VoleyballWpf3.ViewModels.Base;

namespace VoleyballWpf3.ViewModels
{
    public class AddTeamViewModel : ViewModel
    {
        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private int _wins;
        public int Wins
        {
            get => _wins;
            set
            {
                _wins = value;
                OnPropertyChanged();
            }
        }

        private int _loses;
        public int Loses
        {
            get => _loses;
            set
            {
                _loses = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddTeamCommand { get; }

        public TeamsViewModel TeamsViewModel { get; }

        public AddTeamViewModel(TeamsViewModel teamsViewModel)
        {
            TeamsViewModel = teamsViewModel;
            AddTeamCommand = new LambdaCommand(OnAddTeamCommandExecuted);
        }

        private void OnAddTeamCommandExecuted(object p)
        {
            using (var context = new VoleyballContext())
            {
                var team = new Team
                {
                    Title = Title,
                    Wins = Wins,
                    Loses = Loses
                };
                context.Teams.Add(team);
                context.SaveChanges();

                TeamsViewModel.Teams.Add(team);
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VoleyballWpf3.Infrastructure;
using VoleyballWpf3.Infrastructure.Commands;
using VoleyballWpf3.Models;
using VoleyballWpf3.ViewModels.Base;

namespace VoleyballWpf3.ViewModels
{
    public class TeamsViewModel : ViewModel
    {
        private ObservableCollection<Team> _teams;
        public ObservableCollection<Team> Teams
        {
            get => _teams;
            set
            {
                _teams = value;
                OnPropertyChanged();
            }
        }

        private Team _selectedTeam;
        public Team SelectedTeam
        {
            get => _selectedTeam;
            set
            {
                _selectedTeam = value;
                OnPropertyChanged();
                LoadTeamComposition();
            }
        }

        private ObservableCollection<Team_Composition> _selectedTeamComposition;
        public ObservableCollection<Team_Composition> SelectedTeamComposition
        {
            get => _selectedTeamComposition;
            set
            {
                _selectedTeamComposition = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowTeamCompositionCommand { get; }

        public TeamsViewModel()
        {
            ShowTeamCompositionCommand = new LambdaCommand(ShowTeamComposition);
            LoadTeams();
        }

        private void LoadTeams()
        {
            using (var context = new VoleyballContext())
            {
                Teams = new ObservableCollection<Team>(
                    context.Teams
                           .Include(t => t.Team_Compositions)
                           .ThenInclude(tc => tc.People)
                           .Include(t => t.Team_Compositions)
                           .ThenInclude(tc => tc.Position_On_Field)
                );
            }
        }

        private void LoadTeamComposition()
        {
            if (SelectedTeam != null)
            {
                using (var context = new VoleyballContext())
                {
                    var compositions = context.TeamCompositions
                                              .Where(tc => tc.TeamId == SelectedTeam.Id_Team)
                                              .Include(tc => tc.People)
                                              .Include(tc => tc.Position_On_Field)
                                              .ToList();

                    SelectedTeamComposition = new ObservableCollection<Team_Composition>(compositions);
                }
            }
            else
            {
                SelectedTeamComposition = new ObservableCollection<Team_Composition>();
            }
        }

        private void ShowTeamComposition(object parameter)
        {
            SelectedTeam = parameter as Team;
        }
    }
}

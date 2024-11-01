using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VoleyballWpf3.Infrastructure;
using VoleyballWpf3.Models;
using VoleyballWpf3.ViewModels.Base;

namespace VoleyballWpf3.ViewModels
{
    public class GamesViewModel : ViewModel
    {
        private ObservableCollection<Game> _games;
        public ObservableCollection<Game> Games
        {
            get => _games;
            set
            {
                _games = value;
                OnPropertyChanged();
            }
        }

        private Match _selectedGame;
        public Match SelectedGame
        {
            get => _selectedGame;
            set
            {
                _selectedGame = value;
                OnPropertyChanged();
            }
        }

        public GamesViewModel()
        {
            LoadGames();
        }

        private void LoadGames()
        {
            using (var context = new VoleyballContext())
            {
                Games = new ObservableCollection<Game>(context.Games
                    .Include(m => m.Team_1)
                    .Include(m => m.Team_2));
            }
        }
    }
}

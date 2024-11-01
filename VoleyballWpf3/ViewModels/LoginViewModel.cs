using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VoleyballWpf3.Infrastructure;
using VoleyballWpf3.Infrastructure.Commands;
using VoleyballWpf3.ViewModels.Base;
using VoleyballWpf3.Views.Windows;

namespace VoleyballWpf3.ViewModels
{
    public class LoginViewModel : ViewModel
    {
        private string _login;
        private string _password;
        private bool _isLoggedIn;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public bool IsLoggedIn
        {
            get => _isLoggedIn;
            set
            {
                _isLoggedIn = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginButtonCommand { get; }

        public LoginViewModel()
        {
            LoginButtonCommand = new LambdaCommand(LoginFunc);
        }

        private void LoginFunc(object parameter)
        {
            using (var context = new VoleyballContext())
            {
                var user = context.People.Include(u => u.Role).FirstOrDefault(u => u.Login == Login && u.Password == Password);
                if (user != null)
                {
                    // Redirect to main application window based on role
                    if (user.Role.Title == "Admin")
                    {
                        IsLoggedIn = true;
                        CloseAction?.Invoke();
                        MessageBox.Show("admin!");
                    }
                    else
                    {
                        IsLoggedIn = true;
                        MessageBox.Show("empl!");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid credentials");
                }
            }
        }
        public Action CloseAction { get; set; }
    }

}

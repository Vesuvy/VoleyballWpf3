using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VoleyballWpf3.ViewModels;

namespace VoleyballWpf3.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            var loginViewModel = new LoginViewModel();
            loginViewModel.CloseAction = () =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    var mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                });
            };
            this.DataContext = loginViewModel;
        }
    }
}

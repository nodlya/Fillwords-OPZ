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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FILLWORDS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void OpenGame(object sender, MouseButtonEventArgs e)
        {
            ScreenGetName start = new ScreenGetName();
            start.Show();
        }

        private void Plug(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Пока нетути");
        }
        private void ShowLeaderboard(object sender, MouseButtonEventArgs e)
        {
            ScreenLeaderboard leaderboard = new ScreenLeaderboard();
            Hide();
            leaderboard.Owner = this;
            leaderboard.Show();
        }

    }
}

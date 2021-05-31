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

        private void OpenGame(object sender, MouseButtonEventArgs e)
        {
            ScreenGetName start = new ScreenGetName();
            start.Show();
        }

        private void OpenPreviousGame(object sender, MouseButtonEventArgs e)
        {
            if (ThingsNeededToStart.Player != null)
            {
                GameScreen Game = new GameScreen();
                Hide();
                Game.Owner = this;
                Game.Show();
            }
            else
                MessageBox.Show("Начните игру, прежде чем открывать старую");
        }
        private void ShowLeaderboard(object sender, MouseButtonEventArgs e)
        {
            ScreenLeaderboard leaderboard = new ScreenLeaderboard();
            leaderboard.Owner = this;
            leaderboard.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Exit(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

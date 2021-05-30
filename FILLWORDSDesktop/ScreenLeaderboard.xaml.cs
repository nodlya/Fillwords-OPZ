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
using System.IO;

namespace FILLWORDS
{
    /// <summary>
    /// Логика взаимодействия для ScreenLeaderboard.xaml
    /// </summary>
    public partial class ScreenLeaderboard : Window
    {
        private string[] mas = File.ReadAllLines(ThingsNeededToStart.CsvPath);
        public ScreenLeaderboard()
        {
            InitializeComponent();
            DrawLeaderboard();
        }

        private void DrawLeaderboard()
        {
            for(int i=0;i<mas.Length;i++)
            {
                PlayersList.Items.Add(mas[i]);
            }
        }

        private void BackToMenu(object sender, MouseButtonEventArgs e)
        {
            MainWindow menu = new MainWindow();
            Hide();
            menu.Owner = this;
            menu.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ThingsNeededToStart.Exit();
        }
    }
}

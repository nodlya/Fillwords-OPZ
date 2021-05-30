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

namespace FILLWORDS
{
    /// <summary>
    /// Логика взаимодействия для ScreenGetName.xaml
    /// </summary>
    public partial class ScreenGetName : Window
    {
        public ScreenGetName()
        {
            InitializeComponent();
        }

        private void CheckClickOK(object sender, RoutedEventArgs e)
        {
            string name = nameBox.Text;
            CheckName(name);
        }

        private void CheckName(string name)
        {
            if (name.Contains(','))
                Feedback("Имя не должно содержать знак запятой");
            else
            {
                Feedback("Здравствуйте, " + name);
                ThingsNeededToStart.Player = new Player(name);
                ThingsNeededToStart.Game = new Game(ThingsNeededToStart.Player);

                GameScreen Game = new GameScreen();
                
                Hide();
                Game.Owner = this;
                Game.Show();
            }
        }

        private void Feedback(string feedback) => MessageBox.Show(feedback);



        private void CheckClickCancel(object sender, 
            RoutedEventArgs e) => Hide();


    }
}

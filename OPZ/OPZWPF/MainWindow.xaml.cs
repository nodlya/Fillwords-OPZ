using System;
using System.Collections.Generic;
using System.IO;
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
using OPZ;

namespace OPZWPF
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

        private void GoCalculate(object sender, RoutedEventArgs e)
        {
            Menu.Visibility = Visibility.Hidden;
            OPZ.Visibility = Visibility.Hidden;
            Calculator.Visibility = Visibility.Visible;
        }

        private void GoMenu(object sender, RoutedEventArgs e)
        {
            Menu.Visibility = Visibility.Visible;
            OPZ.Visibility = Visibility.Hidden;
            Calculator.Visibility = Visibility.Hidden;
            hiddenAnswer.Visibility = Visibility.Hidden;
            hiddenAnswerС.Visibility = Visibility.Hidden;
        }
        private void GoOPZ(object sender, RoutedEventArgs e)
        {
            Menu.Visibility = Visibility.Hidden;
            Calculator.Visibility = Visibility.Hidden;
            OPZ.Visibility = Visibility.Visible;
        }

        private void Transform(object sender, RoutedEventArgs e)
        {
            var converter = new Converter();
            hiddenAnswer.Visibility = Visibility.Visible;
            hiddenAnswer.Content = equation.Text + ". Ответ : " + converter.ToString(converter.ToReversePolish(OptimizeString(equation.Text)));

            using (var writer = new StreamWriter(@"file.txt",true))
            {
                writer.WriteLine(hiddenAnswer.Content);
            }
        }

        private void Calculate(object sender, RoutedEventArgs e)
        {
            var calculater = new Calculator();
            hiddenAnswerС.Visibility = Visibility.Visible;
            hiddenAnswerС.Content = answer.Text + ". Ответ : " + calculater.Calculate(OptimizeString(answer.Text)).ToString();

            using (var writer = new StreamWriter(@"file.txt",true))
            {
                writer.WriteLine(hiddenAnswerС.Content);
            }
        }

        static char[] OptimizeString(string str)
        {
            return str
                .ToCharArray()
                .Where(x => x != ' ')
                .ToArray();
        }

        private void CloseProgramm(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

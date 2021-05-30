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
    /// Логика взаимодействия для GameScreen1.xaml
    /// </summary>
    public partial class GameScreen1 : Window
    {
        public GameScreen1()
        {
            InitializeComponent();
            
            var grid = new Grid();
            Player player = new Player("");
            FieldGeneration field = new FieldGeneration(player.Rank);
            grid.Children.Clear();
            SetDefinitionToGrid(grid, 2, 1);

            var canvas = new Canvas();
            canvas.Width = player.Rank * (30 + 5) + 5;
            canvas.Height = player.Rank * (30 + 5) + 5;
            canvas.Background = Brushes.LightGray;
            grid.Children.Add(canvas);
            Grid.SetColumn(canvas, 0);
            Grid.SetRow(canvas, 0);

            var spRightPanel = new StackPanel();
            grid.Children.Add(spRightPanel);
            Grid.SetColumn(spRightPanel, 1);
            Grid.SetRow(spRightPanel, 0);

            spRightPanel.Children.Add(CreateTextBlock("Очки: 0", 20, 20 * 15,
                                                      new Thickness(5, 5, 0, 0)));

            spRightPanel.Children.Add(CreateTextBlock(" ", 20, 20 * 15, new Thickness(5, 5, 0, 0)));

            spRightPanel.Children.Add(new StackPanel());

            //SetFieldOnCanvas(canvas);
        }

        private static void SetDefinitionToGrid(Grid grid, int x, int y)
        {
            for (int ii = 0; ii < x; ii++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            }
            for (int i = 0; i < y; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            }
        }
        private static TextBlock CreateTextBlock(string text, int fontSize, int width, Thickness margin)
        {
            return new TextBlock()
            {
                Text = text,
                FontSize = fontSize,
                Width = width,
                Margin = margin,
                Background = Brushes.Yellow
            };
        }
    }
}

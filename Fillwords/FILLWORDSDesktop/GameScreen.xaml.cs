using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для GameScreen.xaml
    /// </summary>
    public partial class GameScreen : Window
    {
        public static Cell[,] ArrayOfCells;
        private static List<Cell> SelectedCells = new List<Cell>();
        public GameScreen()
        {
            InitializeComponent();
            Field.ShowGridLines = false;
            NewField(false);
            ChangeText();
        }

       private void SetField(Grid Field, int rang)
        {
            for (int i=0;i<rang;i++)
            {
                Field.ColumnDefinitions.Add(new ColumnDefinition() { Width=GridLength.Auto} );
                Field.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            }
        }

        private void SetCells(int rang)
        {
            int i = 1;
            for (int x=0;x<rang;x++)
                for (int y=0;y<rang;y++)
                {
                    Rectangle temp = new Rectangle();
                    Label letter = new Label()
                    {
                        Content = i++,
                        FontSize = 30,
                        Foreground = Brushes.Black
                    };
                    temp.StrokeThickness = 2;
                    temp.Stroke = Brushes.Black;
                    temp.Height = 300 / rang;
                    temp.Width = 300 / rang;
                    Cell temp1 = new Cell(x,y,temp,letter,temp.Height);
                    ArrayOfCells[x, y] = temp1;
                    BasicStyle(x,y);
                    Grid.SetRow(letter,y);
                    Grid.SetColumn(letter,x);
                    Grid.SetRow(temp, y);
                    Grid.SetColumn(temp,x);

                    Field.Children.Add(temp);
                    Field.Children.Add(letter);
                    
                }
        }

        protected void BasicStyle(int x, int y)
        {
            Rectangle notSelected = ArrayOfCells[x,y].LabelHolder;
            notSelected.Fill = ThingsNeededToStart.Colors[0];
            Grid.SetRow(notSelected, y);
            Grid.SetColumn(notSelected, x);
        }

        private void SetLetters()
        {
            for (int i = 0; i < ThingsNeededToStart.Player.Rank; i++)
                for (int j = 0; j < ThingsNeededToStart.Player.Rank; j++)
                    ArrayOfCells[i, j].LetterHolder.Content = FieldGeneration.Field[j, i];
        }


        private void Exit(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow menu = new MainWindow();
            Hide();
            menu.Owner = this;
            menu.Show();
        }

        private static Cell FindCellByCoords(Point coord)
        {
            if (ArrayOfCells != null)
                foreach (Cell cell in ArrayOfCells)
                {
                    if (cell.CoordX <= coord.X && cell.CoordX + cell.Size >= coord.X)
                        if (cell.CoordY <= coord.Y && cell.CoordY + cell.Size >= coord.Y)
                            return cell;
                }
            return null;
        }

        private void StartSelect(object sender, MouseButtonEventArgs e)
        {
            Cell cell = FindCellByCoords(e.GetPosition((Window)sender));
            if (cell != null)
            {
                cell.ChangeStatus(1);
                MouseInfo.Pressed = true;
                Game.PlayersWord += cell.LetterHolder.Content;
                SelectedCells.Add(cell);
                Game.PlayersWordPattern += Convert.ToString(cell.X * 10 + cell.Y);
            }
        }

        private void Selecting(object sender, MouseEventArgs e)
        {
            Cell cell = FindCellByCoords(e.GetPosition((Window)sender));
            if (cell != null && !SelectedCells.Contains(cell) && MouseInfo.Pressed == true && cell != null)
            {
                if (cell.Status == CellStatus.Free)
                {
                    SelectedCells.Add(cell);
                    cell.ChangeStatus(1);
                    Game.PlayersWord += cell.LetterHolder.Content;
                    Game.PlayersWordPattern += Convert.ToString(cell.X * 10 + cell.Y);
                }
                else Warning(cell);
            }
        }

        private void Selected(object sender, MouseButtonEventArgs e)
        {
            Clean();
            ChangeText();
            if (GameWon())
            {
                GetFeedback(5);
                NewField();
            }
        }

        private void Clean(bool b=true)
        {
            MouseInfo.Pressed = false;
            int status = Game.CheckStatus();
            if (b) GetFeedback(status);
            else GetFeedback(0);
            SelectedCells.Clear();
        }

        private void GetFeedback(int status)
        {
            switch(status)
            {
                case 0: 
                    //MessageBox.Show("Таких слов нет и как-то не будет");
                    ChangeStatuses(status);
                    break;
                case 1:
                    MessageBox.Show("Не загадывали это слово, но оно есть в словаре");
                    ChangeStatuses(0);
                    break;
                case 2:
                    MessageBox.Show("Загадывали это слово, попробуйте собрать по-другому");
                    ChangeStatuses(0);
                    break;
                case 3:
                    //MessageBox.Show("Вы угадали!!!");
                    ChangeStatuses(2);
                    break;
                case 4: ChangeStatuses(0); break;
                case 5: MessageBox.Show("Уровень пройден"); break;
                default: break;
            }
        }
        private void ChangeStatuses(int status)
        {
            foreach (Cell cell in SelectedCells)
            {
                cell.ChangeStatus(status);
            }
        }

        private void Warning(Cell cell)
        {
            if (cell.Status == CellStatus.Selected) 
                MessageBox.Show("Вы не можете выбрать уже выбранную букву");
            if (cell.Status == CellStatus.Guessed)
                MessageBox.Show("Эта буква принадлежит угаданному слову");
            Clean();
        }

        private void ChangeText()
        {
            string text = "Ваш уровень " + Convert.ToString(ThingsNeededToStart.Player.Level)
                        + ", а количество очков - " 
                        + Convert.ToString(ThingsNeededToStart.Player.Points);
            GameInfo.Text = text;
        }

        private bool GameWon()
        {
            bool b = true;//ArrayOfCells.All(t => t.Status == CellStatus.Guessed);
            foreach (Cell a in ArrayOfCells)
                if (a.Status != CellStatus.Guessed) 
                    b = false;
            return b;
        }

        private void NewField(bool b = true)
        {
            if (b) Game.Win();
            ArrayOfCells = new Cell[ThingsNeededToStart.Player.Rank,
                                    ThingsNeededToStart.Player.Rank];
            Field.Children.Clear();
            Field.RowDefinitions.Clear();
            Field.ColumnDefinitions.Clear();
            SetField(Field, ThingsNeededToStart.Player.Rank);
            SetCells(ThingsNeededToStart.Player.Rank);
            SetLetters();
        }
    }


    public class Cell
    {
        public readonly int X;
        public readonly int Y;
        public readonly int CoordX;
        public readonly int CoordY;
        public readonly int Size;
        public readonly Rectangle LabelHolder;
        public readonly Label LetterHolder;
        public readonly char Letter;
        public CellStatus Status; 

        public Cell(int x,int y, Rectangle rectangle, Label letter, double size)
        {
            X = x;
            Y = y;
            LabelHolder = rectangle;
            LetterHolder = letter;
            Size = (int)size;
            CoordX = 20 + Size * X;
            CoordY = 60 + Size * Y;
            Status = CellStatus.Free;
            
            SetCellColor();
        }

        public void SetCellColor()
        {
            LabelHolder.Fill = ThingsNeededToStart.Colors[Status];
        }

        public void ChangeStatus(int status)
        {
            switch (status)
            {
                case 0: Status = CellStatus.Free; break;
                case 1: Status = CellStatus.Selected; break;
                case 2: Status = CellStatus.Guessed; break;
                default: break;
            }
            SetCellColor();
        } 
    }

    
    
}

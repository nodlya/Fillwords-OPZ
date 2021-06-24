using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using OPZ.Library;
using static OPZ.Desktop.MainWindow;

namespace OPZ.Desktop
{
    public static class Drawer
    {
        public static MainWindow MainWindow;
        public static Library.Point Offset = new Point();
        public static Calculation rpn;
        public static void DrawField()
        {
            AddArrow(0, MainWindow.GraphHolder.ActualHeight / 2 + Offset.Y, MainWindow.GraphHolder.ActualWidth, MainWindow.GraphHolder.ActualHeight / 2 + Offset.Y, MainWindow.GraphHolder);
            AddArrow(MainWindow.GraphHolder.ActualWidth / 2 + Offset.X, MainWindow.GraphHolder.ActualHeight, MainWindow.GraphHolder.ActualWidth / 2 + Offset.X, 0, MainWindow.GraphHolder);

            double minY = -MainWindow.GraphHolder.ActualHeight / 2 - 1;
            double maxY = MainWindow.GraphHolder.ActualHeight / 2 + 1;
            List<Library.Point> points = FunctionValues.GetPointsList(rpn, double.Parse(MainWindow.Beginning.Text), double.Parse(MainWindow.Ending.Text), minY, maxY, double.Parse(MainWindow.Step.Text), Offset, Zoom);
            AddLinesOnMainWindow(points);
        }

        private static void AddLinesOnMainWindow(List<Library.Point> pointsList)
        {
            for (int i = 1; i < pointsList.Count; i++)
            {
                MainWindow.GraphHolder.Children.Add(new Line()
                {
                    X1 = pointsList[i - 1].X + MainWindow.GraphHolder.ActualWidth / 2,
                    Y1 = -pointsList[i - 1].Y + MainWindow.GraphHolder.ActualHeight / 2,
                    X2 = pointsList[i].X + MainWindow.GraphHolder.ActualWidth / 2,
                    Y2 = -pointsList[i].Y + MainWindow.GraphHolder.ActualHeight / 2,
                    StrokeThickness = 1,
                    Stroke = Brushes.DarkSlateBlue
                });
            }
        }

        private static void AddArrow(double x1, double y1, double x2, double y2, Canvas canvas)
        {
            double width = 5;
            double length = 15;

            double d = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            double X = x2 - x1;
            double Y = y2 - y1;

            double X3 = x2 - (X / d) * length;
            double Y3 = y2 - (Y / d) * length;

            double Xp = y2 - y1;
            double Yp = x1 - x2;

            double X4 = X3 + (Xp / d) * width;
            double Y4 = Y3 + (Yp / d) * width;
            double X5 = X3 - (Xp / d) * width;
            double Y5 = Y3 - (Yp / d) * width;

            Line line = new Line
            {
                Stroke = Brushes.Black,
                X1 = x1,
                X2 = x2,
                Y1 = y1,
                Y2 = y2
            };

            if (line.Y1 > 0)
                canvas.Children.Add(line);

            line = new Line
            {
                Stroke = Brushes.Black,
                X1 = x2 - (X / d),
                X2 = X4,
                Y1 = y2 - (Y / d),
                Y2 = Y4
            };

            if (line.Y1 > 0)
                canvas.Children.Add(line);

            line = new Line
            {
                Stroke = Brushes.Black,
                X1 = x2 - (X / d),
                X2 = X5,
                Y1 = y2 - (Y / d),
                Y2 = Y5
            };

            if (line.Y1 > 0)
                canvas.Children.Add(line);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FILLWORDS
{
    public static class MouseInfo
    {
        public static bool Pressed { get; set; } = false;
    }

    /*public static class Extra
    {
        public static void UpdateItemsContext(Grid grid)
        {
            foreach (var control in grid.Children)
            {
                if (control is TextBox)
                {
                    TextBox tb = (TextBox)control;
                    tb.Text = Settings.Property[(int)tb.Tag].ToString();
                }
                else
                if (control is TextBlock)
                {
                    TextBlock tb = (TextBlock)control;
                    if (tb.Tag != null)
                    {
                        ((TextBlock)control).Foreground = ColorsSet.ColorsList[(int)Settings.Property[(int)tb.Tag], 1];
                        ((TextBlock)control).Background = ColorsSet.ColorsList[(int)Settings.Property[(int)tb.Tag], 0];
                    }
                }
            }
        }
    }*/
}

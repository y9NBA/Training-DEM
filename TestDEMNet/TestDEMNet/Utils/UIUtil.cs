using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TestDEMNet.Utils
{
    public class UIUtil
    {
        
        public static StackPanel concatDuoInHorizontal(UIElement e1, UIElement e2)
        {
            StackPanel stack = new StackPanel();
            stack.HorizontalAlignment = HorizontalAlignment.Center;
            stack.VerticalAlignment = VerticalAlignment.Center;
            stack.Orientation = Orientation.Horizontal;

            stack.Children.Add(e1);
            stack.Children.Add(e2);

            return stack;
        }

        public static StackPanel concatDuoInVertical(UIElement e1, UIElement e2)
        {
            StackPanel stack = new StackPanel();
            stack.HorizontalAlignment = HorizontalAlignment.Center;
            stack.VerticalAlignment = VerticalAlignment.Center;
            stack.Orientation = Orientation.Vertical;

            stack.Children.Add(e1);
            stack.Children.Add(e2);

            return stack;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TestDem.Utils
{
    public class Navigation
    {
        public static Frame CurrentFrame { get; set; }
        public static Window Root { get; set; }

        public void NavigateTo(Page page)
        {
            CurrentFrame.Navigate(page);
        }
    }
}

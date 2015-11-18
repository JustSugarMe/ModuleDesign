using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ComponentDesign
{
    public class TextBoxEx : TextBox
    {
        public Image Icon
        {
            get { return (Image)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(Image), typeof(TextBoxEx), null);


        public TextBoxEx()
        {
            this.DefaultStyleKey = typeof(TextBoxEx);
        }
    }
}

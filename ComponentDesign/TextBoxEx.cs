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
    [TemplatePart(Name = "txtWaterMark", Type = typeof(TextBlock))]
    public class TextBoxEx : TextBox
    {
        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(ImageSource), typeof(TextBoxEx), null);


        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(TextBoxEx), new PropertyMetadata("标题"));


        public string WaterMark
        {
            get { return (string)GetValue(WaterMarkProperty); }
            set { SetValue(WaterMarkProperty, value); }
        }

        public static readonly DependencyProperty WaterMarkProperty =
            DependencyProperty.Register("WaterMark", typeof(string), typeof(TextBoxEx), new PropertyMetadata("请输入内容"));


        private TextBlock _WaterMark;

        public TextBoxEx()
        {
            this.DefaultStyleKey = typeof(TextBoxEx);
        }

        public override void OnApplyTemplate()
        {
            _WaterMark = GetTemplateChild("txtWaterMark") as TextBlock;

            base.OnApplyTemplate();
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            _WaterMark.Visibility = Visibility.Collapsed;

            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.Text))
            {
                _WaterMark.Visibility = Visibility.Visible;
                this.Text = string.Empty;
            }
            base.OnLostFocus(e);
        }
    }
}
